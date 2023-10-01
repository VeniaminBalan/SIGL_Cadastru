using Contracts;
using Services;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Utils;


namespace SIGL_Cadastru.Views.Setari.Persoane
{
    public partial class UC_PagePersoanaNoua : UserControl, IUserControl
    {
        private readonly UC_PersoanaNoua uc_persoanaNoua;
        private readonly IServiceManager _serviceManager;
        private readonly EventService _eventService;
        public UC_PagePersoanaNoua(IServiceManager serviceManager, EventService eventService)
        {
            _serviceManager = serviceManager;
            _eventService = eventService;
            InitializeComponent();
        }

        public void ShowUC()
        {
            this.Visible = true;
            this.BringToFront();
        }

        public void HideUC()
        {
            this.Visible = false;
        }
    }
}
