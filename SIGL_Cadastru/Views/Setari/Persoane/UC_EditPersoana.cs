using Microsoft.EntityFrameworkCore;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Utils;

namespace SIGL_Cadastru.Views.Setari
{
    public partial class UC_EditPersoana : UserControl, IUserControl
    {
        private readonly IServiceManager _service;
        private readonly EventService _eventService;
        private readonly FormSetari _formSetari;
        private Persoana _persoana;
        public UC_EditPersoana(IServiceManager service, EventService eventService, FormSetari formSetari,Persoana persoana)
        {
            _persoana = persoana;
            _service = service;
            _eventService = eventService;
            _formSetari = formSetari;

            InitializeComponent();
            Upload(_persoana);
        }

        public void Upload(Persoana persoana)
        {
            textBoxNume.Text = persoana.Nume;
            textBoxPrenume.Text = persoana.Prenume;
            textBoxEmail.Text = persoana.Email;
            textBoxIDNP.Text = persoana.IDNP;
            textBoxAdresa.Text = persoana.Domiciliu;
            textBoxTelefon.Text = persoana.Telefon;
            dateTimePicker.Value = persoana.DataNasterii.ToDateTime(TimeOnly.MinValue);
        }

        public void HideUC()
        {
            this.Visible = false;
        }
        public void ShowUC()
        {
            this.Visible = true;
            this.BringToFront();
        }

        private async void button_save_Click(object sender, EventArgs e)
        {
            string nume = textBoxNume.Text;
            string prenume = textBoxPrenume.Text;
            string email = textBoxEmail.Text;
            string idnp = textBoxIDNP.Text;
            string telefon = textBoxTelefon.Text;
            string domiciliu = textBoxAdresa.Text;
            DateOnly dataNasterii = DateOnly.FromDateTime(dateTimePicker.Value);


            try
            {
                if (_persoana.Nume != nume)
                {                   
                    _persoana.SetNume(nume);
                }
                if (_persoana.Prenume != prenume)
                {
                    _persoana.SetPrenume(prenume);
                }
                if (_persoana.Email != email)
                {
                    _persoana.SetEmail(email);
                }
                if (_persoana.IDNP != idnp)
                {
                    _persoana.SetIDNP(_service.RepositoryManager.Persoana, idnp);
                }
                if (_persoana.Telefon != telefon)
                {
                    _persoana.SetTelefon(telefon);
                }
                if (_persoana.DataNasterii != dataNasterii)
                {
                    _persoana.SetDataNasterii(dataNasterii);
                }               
                if (_persoana.Domiciliu != domiciliu)
                {
                    _persoana.SetDomiciliu(domiciliu);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            var state = _service.RepositoryManager.context.Entry(_persoana).State;

            if (state == Microsoft.EntityFrameworkCore.EntityState.Modified) 
            {
                await _service.SaveAsync();
                MessageBox.Show("Modificarile au fost salvate");
                _eventService.OnPersoaneUpdateRequire(EventArgs.Empty);
                _formSetari.UpdateRequire = true;
            }

        }
    }
}
