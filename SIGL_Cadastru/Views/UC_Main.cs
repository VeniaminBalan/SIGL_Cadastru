using AutoMapper;
using Query;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.App.Entities.DataTransferObjects;
using SIGL_Cadastru.App.Mappers;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Utils;
using System.Data;




namespace SIGL_Cadastru.Views
{
    public partial class UC_Main : UserControl
    {

        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        private CerereQueryParams cerereQuery = new();

        public UC_Main(IServiceManager service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;

            InitializeComponent();
        }



        public async Task UpdateTable() 
        {
            
            try
            {
                var cereri = await _service.CerereService.GetAllAsync(cerereQuery, false);           
                dataGridView1.DataSource = cereri.ToList();
                

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private async void UC_Main_Load(object sender, EventArgs e)
        {
            await UpdateTable();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                CerereDto? cerere = row.DataBoundItem as CerereDto;

                if (cerere is not null)
                {

                    var id = cerere.Id;
                    var form_cerereView = new FormFactory().CreateFromViewCerere(id);
                    form_cerereView.DataChenged += ActualizareButtonPressed;
                    form_cerereView.Show();

                    return;
                }
            }

        }

        public async void ActualizareButtonPressed(object sender, EventArgs e) 
        {
            await UpdateTable();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            var text = textBox1.Text;
            var column = comboBox1.Text;

            var search = SearchQuery.Create(text, column);

            this.cerereQuery.Search = search;

            await UpdateTable();

        }

        private async void checkBox_Eliberat_CheckedChanged(object sender, EventArgs e)
        {
            var statefilter = new StateFilter();

            if (checkBox_inLucru.Checked)
                statefilter.states.Add(Repo.Models.Status.Inlucru);

            if (checkBox_Eliberat.Checked)
                statefilter.states.Add(Repo.Models.Status.Eliberat);

            if (checkBox_Respins.Checked)
                statefilter.states.Add(Repo.Models.Status.Respins);

            if (checkBox_laReceptie.Checked)
                statefilter.states.Add(Repo.Models.Status.LaReceptie);


            this.cerereQuery.StateFilter = statefilter;

            await UpdateTable();
        }

        private async void maskedTextBox_inceput_TextChanged(object sender, EventArgs e)
        {
            maskedTextBox_inceput.ForeColor = Color.Black;

            if (!maskedTextBox_inceput.MaskCompleted) 
            {
                if (this.cerereQuery.TimeFilter is null)
                    return;

                this.cerereQuery.TimeFilter = null;
                await UpdateTable();
                return;
            }


            var date = new DateOnly();

            try
            {
                date = DateOnly.Parse(maskedTextBox_inceput.Text);
            }
            catch (Exception)
            {
                maskedTextBox_inceput.ForeColor= Color.Red;
                return;
                
            }

            cerereQuery.TimeFilter = TimeSpanFilter.Create(TimeFilterMode.StartDate, date);
            await UpdateTable();

        }

        private async void maskedTextBox_panaLa_TextChanged(object sender, EventArgs e)
        {
            maskedTextBox_panaLa.ForeColor = Color.Black;

            if (!maskedTextBox_panaLa.MaskCompleted)
            {
                if (this.cerereQuery.TimeFilter is null)
                    return;

                this.cerereQuery.TimeFilter = null;
                await UpdateTable();
                return;
            }


            var date = new DateOnly();

            try
            {
                date = DateOnly.Parse(maskedTextBox_panaLa.Text);
            }
            catch (Exception)
            {
                maskedTextBox_panaLa.ForeColor = Color.Red;
                return;
                
            }

            cerereQuery.TimeFilter = TimeSpanFilter.Create(TimeFilterMode.EndDate, date);
            await UpdateTable();
        }

    }
}
