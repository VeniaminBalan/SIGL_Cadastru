using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Services;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Middlewares.AutoUpdate;
using SIGL_Cadastru.Middlewares.Database;
using SIGL_Cadastru.Repo.DataBase;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Service;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Views;
using SIGL_Cadastru.Views.Setari;
using SIGL_Cadastru.Views.Setari.Persoane;
using Squirrel;

namespace SIGL_Cadastru;

public static class Program
{
    private static IHost host;
    public static string Version = "0.0.0";
    private static readonly string MutexId = "SIGL_App";

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main()
    {
        using (Mutex mutex = new Mutex(true, MutexId, out bool createdNew))
        {
            if (createdNew)
            {

                SquirrelAwareApp.HandleEvents(
                    onInitialInstall: OnAppInstall,
                    onAppUninstall: OnAppUninstall,
                    onEveryRun: OnAppRun);


                var hostBuilder = CreateHostBuilder();
                host = hostBuilder.Build();


                await host.CheckForUpdatesAsync();
                host.MigrateIfNeeded();


                var formFactory = new FormFactoryImpl(host.Services);
                FormFactory.SetProvider(formFactory);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                ApplicationConfiguration.Initialize();


                Application.Run(formFactory.CreateMain());
            }
            else
            {
                MessageBox.Show("Another instance of the application is already running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 
    }


    static IHostBuilder CreateHostBuilder()
    {

        string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string sFile = $"{sCurrentDirectory}Resources\\Nomenclatura.xml";


        return Host.CreateDefaultBuilder()

            .ConfigureServices((context, services) => {
                services.AddDbContext<AppDbContext>(options => options.UseSqlite(DatabaseOptions.ConnectionString, b => 
                b.MigrationsAssembly( typeof(AppDbContext).Assembly.ToString() )));

                services.AddScoped(typeof(IRepositoryManager), typeof(RepositoryManager));
                services.AddScoped(typeof(IServiceManager), typeof(ServiceManager));
                services.AddSingleton<EventService>();
                services.AddScoped(typeof(IPdfGeneratorService), typeof(QuestPdfGeneratorService));


                services.AddScoped<Func<Guid, FormViewCerere>>(container =>
                        Id =>
                        {
                            var service = container.GetRequiredService<IServiceManager>();
                            var eventService = container.GetRequiredService<EventService>();
                            var pdfService = container.GetRequiredService<IPdfGeneratorService>();
                            return new FormViewCerere(service, pdfService, eventService, Id);
                        });

                services.AddTransient<FormMain>(container => FormMain.Create());

                services.AddTransient<FormCerere>(container =>
                {
                    var repository = container.GetRequiredService<IRepositoryManager>();
                    var pdfService = container.GetRequiredService<IPdfGeneratorService>();
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

    //moved to main
    static IFormFactory CompositionRoot()
    {
        // host
        var hostBuilder = CreateHostBuilder();
        host = hostBuilder.Build();

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

    private static void OnAppInstall(SemanticVersion version, IAppTools tools)
    {
        tools.CreateShortcutForThisExe(ShortcutLocation.StartMenu | ShortcutLocation.Desktop);
    }
    private static void OnAppUninstall(SemanticVersion version, IAppTools tools)
    {
        tools.RemoveShortcutForThisExe(ShortcutLocation.StartMenu | ShortcutLocation.Desktop);
    }
    private static void OnAppRun(SemanticVersion version, IAppTools tools, bool firstRun)
    {
        tools.SetProcessAppUserModelId();
        // show a welcome message when the app is first installed
        if (firstRun) MessageBox.Show("Thanks for installing my application!");
    }
}