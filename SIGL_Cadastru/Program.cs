using AutoMapper;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Services;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Service;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Views;
using SIGL_Cadastru.Views.Setari;
using SIGL_Cadastru.Views.Setari.Persoane;
using System.Configuration;

namespace SIGL_Cadastru
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var formFactory = CompositionRoot();

            ApplicationConfiguration.Initialize();
            Application.Run(formFactory.CreateMain());
        }

        static IHostBuilder CreateHostBuilder()
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Resources\Nomenclatura.xml");
            string sPdf = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\Resources");
            string sPdfFilePath = Path.GetFullPath(sPdf);


            var connectionString = ConfigurationManager.ConnectionStrings["SQlite"].ConnectionString;
            var varstring = @"Data Source=E:\PC\Projects\consult-trading\SIGL_Cadastru\DB\SIGLDB.db";


            return Host.CreateDefaultBuilder()

                .ConfigureServices((context, services) => {
                    services.AddDbContext<AppDbContext>(options => options.UseSqlite(varstring, b => 
                    b.MigrationsAssembly( typeof(AppDbContext).Assembly.ToString() )));

                    services.AddScoped(typeof(IRepositoryManager), typeof(RepositoryManager));
                    services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
                    services.AddSingleton<EventService>();

                   // services.AddScoped(typeof(IPdfGeneratorService), typeof(QuestPdfGeneratorService));


                    services.AddScoped<Func<Guid, FormViewCerere>>(container =>
                            Id =>
                            {
                                var service = container.GetRequiredService<IServiceManager>();
                                var eventService = container.GetRequiredService<EventService>();
                                var pdfService = new QuestPdfGeneratorService(sPdfFilePath);
                                return new FormViewCerere(service, pdfService, eventService, Id);
                            });

                    services.AddTransient<FormMain>(container => FormMain.Create());

                    services.AddTransient<FormCerere>(container =>
                    {
                        var repository = container.GetRequiredService<IRepositoryManager>();
                        var pdfService = new QuestPdfGeneratorService(sPdfFilePath);
                        var eventService = container.GetRequiredService<EventService>();

                        var formCerere = new FormCerere(repository, pdfService, eventService);
                        return formCerere;
                    });
                    services.AddTransient<FormSetari>(container =>
                    {
                        var service = container.GetRequiredService<IServiceManager>();
                        var eventService = container.GetRequiredService<EventService>();

                        return FormSetari.Create(service, eventService); ;
                    });
                    services.AddScoped<UC_Main>(container => 
                    {
                        var service = container.GetRequiredService<IServiceManager>();
                        var eventService = container.GetRequiredService<EventService>();

                        var uc_main = new UC_Main(service, eventService);
                        return uc_main;
                    });
                    services.AddTransient<UC_PersoanaExistenta>(container =>
                    {
                        var repository = container.GetRequiredService<IRepositoryManager>();
                        var eventService = container.GetRequiredService<EventService>();
                        var uc_PE = new UC_PersoanaExistenta(repository, eventService);
                        return uc_PE;
                    });
                    services.AddTransient<UC_PersoanaNoua>(container =>
                    {
                        var repository = container.GetRequiredService<IRepositoryManager>();
                        var eventService = container.GetRequiredService<EventService>();
                        var uc_PNoua = new UC_PersoanaNoua(repository, eventService);
                        return uc_PNoua;
                    });
                    services.AddTransient<Func<Persoana, UC_EditPersoana>>(container => 
                        persoana => 
                        {
                            var service = container.GetRequiredService<IServiceManager>();
                            var eventService = container.GetRequiredService<EventService>();
                            var formSetari = container.GetRequiredService<FormSetari>();
                            var uc_pEdit = new UC_EditPersoana(service, eventService, formSetari, persoana);

                            return uc_pEdit;
                        });
                    services.AddTransient<UC_PagePersoanaNoua>(container => 
                    {
                        var eventService = container.GetRequiredService<EventService>();
                        var service = container.GetRequiredService<IServiceManager>();
                        return new UC_PagePersoanaNoua(service, eventService);

                    });
                });
        }

        static IFormFactory CompositionRoot()
        {
            // host
            var hostBuilder = CreateHostBuilder();
            var host = hostBuilder.Build();

            // container
            var serviceProvider = host.Services;

            // form factory
            var formFactory = new FormFactoryImpl(serviceProvider);
            FormFactory.SetProvider(formFactory);

            return formFactory;
        }

        public class FormFactoryImpl : IFormFactory
        {
            private IServiceProvider _serviceProvider;

            public FormFactoryImpl(IServiceProvider serviceProvider)
            {
                this._serviceProvider = serviceProvider;
            }

            public FormCerere CreateCerere()
            {
                return _serviceProvider.GetRequiredService<FormCerere>();
            }

            public FormMain CreateMain()
            {
                return _serviceProvider.GetRequiredService<FormMain>();
            }

            public UC_Main CreateUC_Main()
            {
                return _serviceProvider.GetRequiredService<UC_Main>();
            }

            public UC_PersoanaExistenta CreateUC_PersoanaExistenta()
            {
                return _serviceProvider.GetRequiredService<UC_PersoanaExistenta>();
            }

            public UC_EditPersoana CreateUC_PersoanaEdit(Persoana persoana)
            {
                var _form2Factory = _serviceProvider.GetRequiredService<Func<Persoana, UC_EditPersoana>>();
                return _form2Factory(persoana);
            }

            public UC_PersoanaNoua CreateUC_PersoanaNoua()
            {
                var _form2Factory = _serviceProvider.GetRequiredService<UC_PersoanaNoua>();
                return _form2Factory;
            }

            public FormViewCerere CreateFromViewCerere(Guid Id)
            {
                var _form2Factory = _serviceProvider.GetRequiredService<Func<Guid, FormViewCerere>>();
                return _form2Factory(Id);
            }

            public FormSetari CreateFormSetari()
            {
                return _serviceProvider.GetRequiredService<FormSetari>();
            }

            public UC_PagePersoanaNoua CreatePersoanaNouaPage()
            {
                return _serviceProvider.GetRequiredService<UC_PagePersoanaNoua>();
            }
        }

    }
}