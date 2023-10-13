using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Views.Setari.Persoane;


namespace SIGL_Cadastru.Views.Setari
{
    public partial class FormSetari : Form
    {
        private readonly IServiceManager _service;
        private readonly EventService _eventService;
        private static FormSetari? _form;

        private UC_PersoaneSetari uc_persoaneSetari = null;
        private UC_PagePersoanaNoua uc_persoanaNoua = null;

        public bool UpdateRequire = false;

        private FormSetari(IServiceManager service, EventService eventService)
        {
            _service = service;
            _eventService = eventService;

            InitializeComponent();
        }

        public static FormSetari Create(IServiceManager service, EventService eventService)
        {
            if (_form is null || _form.IsDisposed) 
            {
                _form = new FormSetari(service, eventService);
            }
            
            return _form;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uc_persoaneSetari is null) 
            {
                uc_persoaneSetari = UC_PersoaneSetari.Create(_service, _eventService, this);
                splitContainer1.Panel2.Controls.Add(uc_persoaneSetari);
            }

            uc_persoaneSetari.ShowUC();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (uc_persoanaNoua is null) 
            {
                uc_persoanaNoua = _service.FormFactory.CreatePersoanaNouaPage();
                splitContainer1.Panel2.Controls.Add(uc_persoanaNoua);
            }
            uc_persoanaNoua.ShowUC();
        }

        private void FormSetari_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UpdateRequire)
                _eventService.OnCereriUpdateRequire(EventArgs.Empty);

            foreach (Control control in splitContainer1.Panel2.Controls)
            {

                control.Dispose();
            }

            this.Dispose();
        }

    }
}
