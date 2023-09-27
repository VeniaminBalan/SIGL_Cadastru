using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGL_Cadastru.Views.Setari
{
    public partial class UC_PersoaneSetari : UserControl, IUserControl
    {

        private static UC_PersoaneSetari _uc;
        private readonly FormFactory _factory = new();

        private readonly IServiceManager _service;
        private readonly EventService _eventService;
        private readonly FormSetari _formsetari;

        private UC_EditPersoana uc_Edit;
        private UC_PersoanaExistenta uc_PExistenta;

        private UC_PersoaneSetari(IServiceManager service, EventService eventService, FormSetari formsetari)
        {
            InitializeComponent();
            _service = service;
            _eventService = eventService;

            uc_PExistenta = _factory.CreateUC_PersoanaExistenta();
            panel_persoane.Controls.Add(uc_PExistenta);
            uc_PExistenta.ShowUC();
            _formsetari = formsetari;
        }

        public static UC_PersoaneSetari Create(IServiceManager service, EventService eventService, FormSetari formsetari)
        {
            if (_uc is null || _uc.IsDisposed)
            {
                _uc = new UC_PersoaneSetari(service, eventService, formsetari);
            }

            return _uc;
        }

        public void HideUC()
        {
            throw new NotImplementedException();
        }
        public void ShowUC()
        {
            throw new NotImplementedException();
        }

        private async void button_edit_Click(object sender, EventArgs e)
        {
            panel_edit.Controls.Clear();
            Persoana p;

            try
            {
                var result = await uc_PExistenta.GetPersoana();
                p = result.Value;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

            if (p is null)
                return;

            panel_edit.Controls.Add(_factory.CreateUC_PersoanaEdit(p));
        }

        private async void button_delete_Click(object sender, EventArgs e)
        {
            Persoana p;
            try
            {
                var result = await uc_PExistenta.GetPersoana();
                p = result.Value;

                DialogResult dialogResult = MessageBox.Show("Doriti sa stergeti Persoana ? \n (Aceasta actiune nu este reversibila)", "Stergere", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (await _service.RepositoryManager.Persoana.HasDependencies(p.Id))
                    {
                        MessageBox.Show("Persoana data nu poate fi stearsa\nexista cereri inregistrate pe acest nume");
                        return;
                    }
                    else 
                    {
                        _service.PersoanaService.DeletePersoana(p);
                        await _service.SaveAsync();
                    }

                }
                else 
                {
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            _eventService.OnPersoaneUpdateRequire(e);
            _formsetari.UpdateRequire = true;
            
        }

        private void UC_PersoaneSetari_ControlRemoved(object sender, ControlEventArgs e)
        {
            panel_edit.Controls.Clear();

            this.Dispose();
        }
    }
}
