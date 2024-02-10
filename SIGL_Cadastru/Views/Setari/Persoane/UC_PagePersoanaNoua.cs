using Contracts;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Utils;
using System.Windows.Forms;


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
            uc_persoanaNoua = _serviceManager.FormFactory.CreateUC_PersoanaNoua();
            InitializeComponent();

            this.panel_persoanaNoua.Controls.Add(uc_persoanaNoua);
            uc_persoanaNoua.ShowUC();
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

        private async void button_save_Click(object sender, EventArgs e)
        {
            Role rol;
            if (!Enum.TryParse(comboBox_rols.Text, true, out rol)) 
            {
                MessageBox.Show("indicati ce rol are Persoana");
                return;
            }

            Persoana p;
            try
            {
                var result = await uc_persoanaNoua.GetPersoana(rol);
                p = result.Value;               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
                
            }
            
            DialogResult dialogResult = MessageBox.Show($"Doriți sa salvați persoana? \n{p}", "Salvare", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _serviceManager.PersoanaService.CreatePersoana(p);
                await _serviceManager.SaveAsync();
                _eventService.OnPersoaneUpdateRequire(EventArgs.Empty);
                uc_persoanaNoua.ClearData();

            }
            else if (dialogResult == DialogResult.No)
            {
                
            }            
        }
    }
}
