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

        public Persoana GetPersoana() 
        {
            var nume = textBoxNume.Text;
            var prenume = textBoxPrenume.Text;
            var idnp = textBoxIDNP.Text;
            var email = textBoxEmail.Text;
            var telefon = textBoxTelefon.Text;
            var domicilul = textBoxAdresa.Text;
            DateOnly dataNasterii = DateOnly.FromDateTime(dateTimePicker.Value.Date);

            return new Persoana
            {
                Nume= nume,
                Prenume= prenume,
                IDNP= idnp,
                Email = email,
                Telefon= telefon,
                Domiciliu= domicilul,
                DataNasterii= dataNasterii,
                Rol = _rol
            };
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
