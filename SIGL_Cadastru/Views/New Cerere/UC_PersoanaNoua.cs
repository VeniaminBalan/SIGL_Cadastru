using Contracts;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Utils;
using System.Data;


namespace SIGL_Cadastru.Views
{
    public partial class UC_PersoanaNoua : UserControl, IUCPersoana
    {
        private readonly IRepositoryManager _repo;
        private readonly EventService _eventService;

        public UC_PersoanaNoua(IRepositoryManager repo, EventService eventService)
        {
            _repo = repo;
            _eventService = eventService;
            InitializeComponent();
        }

        public async Task<Result<Persoana>> GetPersoana(Role rol) 
        {
            var nume = textBoxNume.Text;
            var prenume = textBoxPrenume.Text; 
            var idnp = textBoxIDNP.Text;
            var email = textBoxEmail.Text;
            var telefon = textBoxTelefon.Text;
            var domicilul = textBoxAdresa.Text; 
            DateOnly dataNasterii = DateOnly.FromDateTime(dateTimePicker.Value.Date);

            try
            {
                var p =  await Persoana.Create(
                    Guid.NewGuid(), 
                    nume,
                    prenume,
                    idnp, 
                    dataNasterii,
                    domicilul, 
                    email, 
                    telefon,
                    rol,
                    _repo.Persoana);

                return new Result<Persoana>(ResultState.NewObject, p);
            }
            catch (Exception)
            {

                throw;
            }

            
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

        public void ClearData() 
        {
            textBoxNume.Text = "";
            textBoxPrenume.Text = "";
            textBoxIDNP.Text = "";
            textBoxEmail.Text = "";
            textBoxTelefon.Text = "";
            textBoxAdresa.Text = "";
        }
    }
}
