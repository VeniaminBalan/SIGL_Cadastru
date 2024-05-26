using Mappers;
using Models;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities.DataTransferObjects;
using SIGL_Cadastru.App.Mappers;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Utils;
using System.Data;


namespace SIGL_Cadastru.Views
{
    public partial class FormViewCerere : Form
    {
        public event EventHandler<EventArgs> DataChenged;

        private readonly IServiceManager _service;
        private readonly IPdfGeneratorService _pdfService;
        private readonly EventService _eventService;
        private readonly Guid _cererId;
        private UC_DocumentsView uc_documents;

        private Cerere? cerere;

        private HashSet<StatusItem> statusItems = new();

        public FormViewCerere(IServiceManager service, IPdfGeneratorService pdfService, EventService eventService, Guid cererId)
        {
            _service = service;
            _pdfService = pdfService;
            _eventService = eventService;
            _cererId = cererId;

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

            textBox_Comment.Text = cerere!.Comment;

            ResetViewStatusList();

            UpdateClientData();
            UpdateCerereData();

            UpdateViewStatusList();
            UpdateLucrariList();
            UpdateDocumenteList();
        }
        private async Task GetCerere() 
        {
            cerere = await _service.CerereService.GetByIdAsync(_cererId, false);
        }

        private void UpdateDocumenteList() 
        {
            uc_documents = new UC_DocumentsView(cerere!.Portofoliu.Documente.ToList());
            panel_uc_doc.Controls.Add(uc_documents);
        }

        private void UpdateClientData() 
        {
            var client = PersoanaMapper.Map(cerere!.Client);

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

            label_Nr.Text = cerereDto.Nr;

            label_valabilDeLa.Text = cerereDto.ValabilDeLa.ToString();
            label_ValabilPanaLa.Text = $"{cerereDto.ValabilPanaLa}";


            label_pretTotal.Text = cerereDto.CostTotal.ToString();
            label_StareCererii.Text = cerereDto.StareaCererii.ToString();
            label_pretTotal.Text = cerereDto.CostTotal.ToString();


            if (cerereDto.StareaCererii == Status.Eliberat)
                return;

            int valabil;
            if (cerereDto.Prelungit is not null)
                valabil = cerereDto.Prelungit.Value.DayNumber;
            else
                valabil = cerereDto.ValabilPanaLa.DayNumber;

                var days = valabil - DateOnly.FromDateTime(DateTime.Now).DayNumber;

            if (days <= 5)
            {
                label_ValabilPanaLa.ForeColor = Color.Red;
            }
            else if (days <= 10)
            {
                label_ValabilPanaLa.ForeColor = Color.DarkOrange;
            }
        }
        private void UpdateViewStatusList() 
        {
            var items = statusItems.Where(x => x.State == EntityState.Added || x.State == EntityState.Original)
                .Select(x => CerereStatusMapper.Map(x.CerereStatus)).ToList();

            dataGridViewStatus.DataSource = items;
        }
        private void UpdateLucrariList() 
        {
            var data = cerere!.Portofoliu.Lucrari.ToList();
            dataGridView1.DataSource = data;
        }
        private void ResetViewStatusList() 
        {
            statusItems = cerere!.StatusList.Select(c => new StatusItem(c, EntityState.Original)).ToHashSet();
            UpdateViewStatusList();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _service.DetachAll();
            _service.CerereService.UpdateCerere(cerere!);
            cerere!.SetComment(textBox_Comment.Text);
            cerere!.Portofoliu.AddDocumentsSource(uc_documents.GetDocumente());

            foreach (var item in statusItems) 
            {
                if (item.State == EntityState.Added)
                {
                    try
                    {
                        cerere!.AddStatus(item.CerereStatus);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                        continue;
                    }
                    
                }
                else if (item.State == EntityState.Removed) 
                {
                    var itemToRemove = cerere!.StatusList.FirstOrDefault(s => s.Id == item.CerereStatus.Id);
                    if(itemToRemove is not null)
                        _service.CerereStatus.DeleteCerere(item.CerereStatus);
                }
            }


            await _service.SaveAsync();

            _eventService.OnCereriUpdateRequire(EventArgs.Empty);

            await GetCerere();
            _service.DetachAll();

            UpdateCerereData();
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

            if (form.Date < cerere!.ValabilDeLa)
            {
                MessageBox.Show($" 1111 data starii ({form.Date}) nu poate fi mai devreme de data de cand e valabila cererea");
                return;
            }

            if (form.Status == Status.Eliberat && this.statusItems.Any(s => s.CerereStatus.Starea == Status.Eliberat)) 
            {
                MessageBox.Show(" Cererea poate fi eliberata doar o singura data");
                return;
            }

            if (form.Status == Status.Prelungit && form.Date < cerere!.ValabilPanaLa) 
            {
                MessageBox.Show($"Starea \"Prelungit\" poate fi setata dupa data {cerere!.ValabilPanaLa}");
                return;
            }

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
                    MessageBox.Show("Object not selected error");
                }


            }
            UpdateViewStatusList();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Doriti sa stergeti Cererea ? \n (Aceasta actiune nu este reversibila)", "Stergere", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                await _service.CerereService.DeleteCerere(_cererId);
                _eventService.OnCereriUpdateRequire(e);
                this.Dispose();

            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var path = _pdfService.GeneratePdf(cerere!);

                StartProcess.Run(path);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void FormViewCerere_FormClosed(object sender, FormClosedEventArgs e)
        {
            _service.DetachAll();
        }
    }

}
