using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Repository;
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
                    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
                        var repository = container.GetRequiredService<IRepository<Dosar>>();
                        var formCerere = new FormMain(repository);
                        return formCerere;
                    });
                    services.AddTransient<FormCerere>(container =>
                    {
                        var repository = container.GetRequiredService<IRepository<Dosar>>();
                        var formCerere = new FormCerere(repository);
                        return formCerere;
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