using AutoMapper;
using Contracts;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.AppConfigurations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGL_Cadastru.Views
{
    public partial class UC_Main : UserControl
    {

        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public UC_Main(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

            InitializeComponent();
        }



        public async Task UpdateTable() 
        {
            var cereri = await _repo.Cerere.GetAllAync(false);

            var response = _mapper.Map<List<CerereDto>>(cereri);

            dataGridView1.DataSource = response;           
            
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
            form_cerereView.Show();
        }
    }
}
