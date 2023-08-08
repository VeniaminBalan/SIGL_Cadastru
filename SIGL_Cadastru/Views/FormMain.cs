using AutoMapper;
using Contracts;
using SIGL_Cadastru.AppConfigurations;


namespace SIGL_Cadastru.Views
{
    public partial class FormMain : Form
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly UC_Main uc_Main;

        public FormMain(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            InitializeComponent();
            uc_Main = Add_UC_Main();
        }

        public UC_Main Add_UC_Main() 
        {
            var uc_main = new FormFactory().CreateUC_Main();
            panel_content.Controls.Add(uc_main);
            uc_main.Dock = DockStyle.Fill;
            uc_main.BringToFront();

            return uc_main;
        }

        private void button_cerere_noua_Click(object sender, EventArgs e)
        {
            var form_cerere = new FormFactory().CreateCerere();
            form_cerere.CreateButtonPressed += Form_cerere_CreateButtonPressed;
            form_cerere.Show();
        }

        private async void Form_cerere_CreateButtonPressed(object? sender, EventArgs e)
        {
            await uc_Main.UpdateTable();
            ((Form)sender).Dispose();
        }

    }
}
