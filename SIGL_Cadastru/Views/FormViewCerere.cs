using AutoMapper;
using Mappers;
using Models;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities.DataTransferObjects;
using SIGL_Cadastru.App.Mappers;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Utils;
using System.Data;


namespace SIGL_Cadastru.Views
{
    public partial class FormViewCerere : Form
    {
        public event EventHandler<EventArgs> DataChenged;

        private readonly IServiceManager _service;
        private readonly IMapper _mapper;
        private readonly Guid _cererId;

        private Cerere? cerere;

        private List<StatusItem> statusItems = new();

        public FormViewCerere(IServiceManager service, IMapper mapper, Guid cerereId)
        {
            _service = service;
            _mapper = mapper;
            _cererId = cerereId;

            InitializeComponent();
        }

        private async void FormViewCerere_Load(object sender, EventArgs e)
        {
            try
            {
                await GetCerere();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Dispose();          
            }

            ResetViewStatusList();

            UpdateClientData();
            UpdateCerereData();

            UpdateViewStatusList();
            UpdateLucrariList();
        }
        private async Task GetCerere() 
        {
            cerere = await _service.CerereService.GetByIdAsync(_cererId, false);
        } 

        private void UpdateClientData() 
        {
            var client = PersoanaMapper.Map(cerere.Client);

            label_Nume.Text = client.Nume;
            label_prenume.Text = client.Prenume;
            label_idnp.Text = client.IDNP;
            label_domiciliu.Text = client.Domiciliu;
            label_email.Text = client.Email;
            label_telefon.Text = client.Telefon;
        }
        private void UpdateCerereData() 
        {
            var cerereDto = CerereMapper.Map(cerere!);
            label_executant.Text = cerereDto.Executant;
            label_responsabil.Text = cerereDto.Responsabil;

            label_valabilDeLa.Text = cerereDto.ValabilDeLa.ToString();
            label_ValabilPanaLa.Text = cerereDto.ValabilPanaLa.ToString();
            label_pretTotal.Text = cerereDto.CostTotal.ToString();
            label_StareCererii.Text = cerereDto.StareaCererii.ToString();
            label_pretTotal.Text = cerereDto.CostTotal.ToString();
        }
        private void UpdateViewStatusList() 
        {
            var items = statusItems.Where(x => x.State == EntityState.Added || x.State == EntityState.Original)
                .Select(x => CerereStatusMapper.Map(x.CerereStatus)).ToList();

            dataGridViewStatus.DataSource = items;
        }
        private void UpdateLucrariList() 
        {
            dataGridView1.DataSource = cerere!.Lucrari.Select(LucrareMapper.Map).ToList();
        }

        private void ResetViewStatusList() 
        {
            statusItems = cerere!.StatusList.Select(c => new StatusItem(c, EntityState.Original)).ToList();
            UpdateViewStatusList();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _service.DetachAll();
            _service.CerereService.UpdateCerere(cerere!);

            foreach (var item in statusItems) 
            {
                if (item.State == EntityState.Added)
                {
                    cerere!.StatusList.Add(item.CerereStatus);
                }
                else if (item.State == EntityState.Removed) 
                {
                    var itemToRemove = cerere!.StatusList.FirstOrDefault(s => s.Id == item.CerereStatus.Id);
                    if(itemToRemove is not null)
                        _service.CerereStatus.DeleteCerere(item.CerereStatus);
                }
            }


            await _service.SaveAsync();
            _service.DetachAll();

            DataChenged!.Invoke(sender, new EventArgs());

        }

        private void button_adaugareStare_Click(object sender, EventArgs e)
        {
            var form = new FormAddState();
            form.AdaugareButtonClicked += OnAdaugareCerereStatus;
            form.ShowDialog();
        }

        private void OnAdaugareCerereStatus(object sender, EventArgs e)
        {
            var form = (FormAddState)sender;

            var cerereStatus = new CerereStatus
            {
                Id = new Guid(),
                Created = form.Date,
                Starea = form.Status,
                Cerere = cerere!
            };

            statusItems.Add(new StatusItem(cerereStatus, EntityState.Added));

            UpdateViewStatusList();
            form.Dispose();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            ResetViewStatusList();
        }

        private void dataGridViewStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewStatus.SelectedRows)
            {

                CerereStatusDto? cerereStatus = row.DataBoundItem as CerereStatusDto;
                if (cerereStatus is not null)
                {
                    var itemToRemove = statusItems.FirstOrDefault(s => s.CerereStatus.Id == cerereStatus.Id);

                    if (itemToRemove is not null)
                        itemToRemove.State = EntityState.Removed;
                }
                else
                {
                    MessageBox.Show("Object not selected Werror");
                }


            }
            UpdateViewStatusList();
        }

        private void FormViewCerere_FormClosed(object sender, FormClosedEventArgs e)
        {
            _service.DetachAll();
        }
    }

}
