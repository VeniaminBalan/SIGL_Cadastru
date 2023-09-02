using AutoMapper;
using Contracts;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Utils;


namespace SIGL_Cadastru.Views
{
    public partial class UC_PersoanaNoua : UserControl, IUCPersoana
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly Role _rol;


        public UC_PersoanaNoua(IRepositoryManager repo, IMapper mapper, Role rol)
        {
            _repo = repo;
            _mapper = mapper;
            _rol = rol;

            InitializeComponent();
        }
        public UC_PersoanaNoua(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            InitializeComponent();
        }

        public async Task<Result<Persoana>> GetPersoana() 
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
                    new Guid(), 
                    nume,
                    prenume,
                    idnp, 
                    dataNasterii,
                    domicilul, 
                    email, 
                    telefon,
                    _rol,
                    _repo.Persoana);

                return new Result<Persoana>(ResultState.NewObject, p);
            }
            catch (Exception)
            {

                throw;
            }

            
        }
        public void SetView()
        {
            this.Visible = true;
            this.BringToFront();
        }

        public void CloseView()
        {
            this.Visible = false;
        }
    }
}
