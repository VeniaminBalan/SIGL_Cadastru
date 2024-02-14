using Query;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Services;




namespace SIGL_Cadastru.Views
{
    public partial class UC_Main : UserControl
    {
        private readonly IServiceManager _service;
        private readonly EventService _eventService;

        private CerereQueryParams cerereQuery = new();

        public UC_Main(IServiceManager service, EventService eventService)
        {
            _service = service;
            _eventService = eventService;

            _eventService.CereriUpdateRequire += _eventService_CereriUpdateRequire;

            InitializeComponent();
            SetQuery();
        }

        private async void UC_Main_Load(object sender, EventArgs e)
        {
            await UpdateTable();
        }

        private async void _eventService_CereriUpdateRequire(object? sender, EventArgs e)
        {
            await UpdateTable();
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                CerereDto? cerere = row.DataBoundItem as CerereDto;

                if (cerere is not null)
                {

                    var id = cerere.Id;
                    var form_cerereView = new FormFactory().CreateFromViewCerere(id);
                    form_cerereView.Show();

                    return;
                }
            }

        }

        // Query -->
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

            SetQuery();
            await UpdateTable();
        }

        private void SetQuery()
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
                maskedTextBox_inceput.ForeColor = Color.Red;
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
        // <--


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "stareaCererii")
            {
                if (e.Value is not null)
                {
                    string stringValue = e.Value.ToString().ToLower();
                    if ((stringValue.IndexOf(Status.Respins.ToString().ToLower()) > -1))
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                    else if ((stringValue.IndexOf(Status.Eliberat.ToString().ToLower()) > -1))
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                    else if ((stringValue.IndexOf(Status.LaReceptie.ToString().ToLower()) > -1))
                    {
                        e.CellStyle.ForeColor = Color.DarkBlue;
                        e.Value = "La Receptie";
                    }
                    else if ((stringValue.IndexOf(Status.Inlucru.ToString().ToLower()) > -1))
                    {
                        e.Value = "In Lucru";
                    }
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "valabilPanaLa")
            {

                var cerereDto = dataGridView1.Rows[e.RowIndex].DataBoundItem as CerereDto;

                if (cerereDto!.StareaCererii == Status.Eliberat)
                    return;

                int valabil;
                if (cerereDto.Prelungit is not null)
                    valabil = cerereDto.Prelungit.Value.DayNumber;
                else
                    valabil = cerereDto.ValabilPanaLa.DayNumber;

                var days = valabil - DateOnly.FromDateTime(DateTime.Now).DayNumber;

                if (days <= 5)
                {
                    e.CellStyle!.ForeColor = Color.Red;
                }
                else if (days <= 10)
                {
                    e.CellStyle!.ForeColor = Color.DarkOrange;
                }
            }
        }

        private async void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //var cell = dataGridView1.Columns[e.ColumnIndex].HeaderCell.Value.ToString().Replace(" ", "");


            //cerereQuery.SortParams = new Repo.Query.SortQueryParams { SortingColumn = cell, SortingDirection = 0 };

            //await UpdateTable();
        }
    }
}
