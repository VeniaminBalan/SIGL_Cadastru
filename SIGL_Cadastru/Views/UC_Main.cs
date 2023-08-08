using AutoMapper;
using Contracts;
using SIGL_Cadastru.App.Contracts;
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
            var cereri = await _service.CerereService.GetAllAsync(false);

            dataGridView1.DataSource = cereri;                      
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
            //MessageBox.Show("Update");
        }
    }
}
