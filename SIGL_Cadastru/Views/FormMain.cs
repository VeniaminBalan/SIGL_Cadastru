using AutoMapper;
using Contracts;
using SIGL_Cadastru.AppConfigurations;


namespace SIGL_Cadastru.Views
{
    public partial class FormMain : Form
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public FormMain(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            InitializeComponent();
            Add_UC_Main();
        }

        public void Add_UC_Main() 
        {
            var uc_main = new FormFactory().CreateUC_Main();
            panel_content.Controls.Add(uc_main);
            uc_main.Dock = DockStyle.Fill;
            uc_main.BringToFront();
        }

        /*
        public IRepository<Dosar> GetRepository() 
        {
            return _repository;
        }
        */

        private void button_cerere_noua_Click(object sender, EventArgs e)
        {
            var form_cerere = new FormFactory().CreateCerere();
            form_cerere.Show();
        }
    }
}
