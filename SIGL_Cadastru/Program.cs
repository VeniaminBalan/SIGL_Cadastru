using AutoMapper;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Views;
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
            var connectionString = ConfigurationManager.ConnectionStrings["SQlite"].ConnectionString;
            var varstring = @"Data Source=E:\PC\Projects\consult-trading\SIGL_Cadastru\DB\SIGLDB.db";



            return Host.CreateDefaultBuilder()

                .ConfigureServices((context, services) => {
                    services.AddDbContext<AppDbContext>(options => options.UseSqlite(varstring));
                    services.AddScoped(typeof(IRepositoryManager), typeof(RepositoryManager));
                    services.AddAutoMapper(typeof(Program));

                    //services.AddTransient<IHelloWorldService, HelloWorldServiceImpl>();
                    /*
                    services.AddTransient<Func<string, Form2>>(
                        container =>
                            something =>
                            {
                                var helloWorldService =
                                    container.GetRequiredService<IHelloWorldService>();
                                return new Form2(helloWorldService, something);
                            });

                    */

                    services.AddTransient<FormMain>(container => 
                    {
                        var repository = container.GetRequiredService<IRepositoryManager>();
                        var mapper = container.GetRequiredService<IMapper>();
                        var formCerere = new FormMain(repository, mapper);
                        return formCerere;
                    });
                    services.AddTransient<FormCerere>(container =>
                    {
                        var repository = container.GetRequiredService<IRepositoryManager>();
                        var mapper = container.GetRequiredService<IMapper>();
                        var formCerere = new FormCerere(repository, mapper);
                        return formCerere;
                    });

                    services.AddTransient<UC_Main>(container => 
                    {
                        var repository = container.GetRequiredService<IRepositoryManager>();
                        var mapper = container.GetRequiredService<IMapper>();
                        var uc_main = new UC_Main(repository, mapper);
                        return uc_main;
                    });

                    services.AddTransient<UC_PersoanaExistenta>(container =>
                    {
                        var repository = container.GetRequiredService<IRepositoryManager>();
                        var mapper = container.GetRequiredService<IMapper>();
                        var uc_PE = new UC_PersoanaExistenta(repository, mapper);
                        return uc_PE;
                    });

                    services.AddTransient<UC_PersoanaNoua>(container =>
                    {
                        var repository = container.GetRequiredService<IRepositoryManager>();
                        var mapper = container.GetRequiredService<IMapper>();
                        var uc_PNoua = new UC_PersoanaNoua(repository, mapper);
                        return uc_PNoua;
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

            public UC_PersoanaNoua CreateUC_PersoanaNoua()
            {
                return _serviceProvider.GetRequiredService<UC_PersoanaNoua>();
            }

            /* 
            public Form2 CreateForm2(string something)
            {
                var _form2Factory = _serviceProvider.GetRequiredService<Func<string, Form2>>();
                return _form2Factory(something);
            }
            */


        }

    }
}