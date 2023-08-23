using AutoMapper;
using Query;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Mappers;
using SIGL_Cadastru.AppConfigurations;
using System.Data;


namespace SIGL_Cadastru.Views
{
    public partial class UC_Main : UserControl
    {

        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public UC_Main(IServiceManager service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

            InitializeComponent();
        }



        public async Task UpdateTable() 
        {
            var data = await _service.CerereService.GetAllAsync(new CerereQueryParams(),false);

            var cereri = data.Select(CerereMapper.Map);

            dataGridView1.DataSource = cereri.ToList();
        }

        private async void UC_Main_Load(object sender, EventArgs e)
        {
            await UpdateTable();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0) return;


            var id = (Guid)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            var form_cerereView = new FormFactory().CreateFromViewCerere(id);
            form_cerereView.DataChenged += ActualizareButtonPressed;
            form_cerereView.Show();
        }

        public async void ActualizareButtonPressed(object sender, EventArgs e) 
        {
            await UpdateTable();
        }
    }
}
