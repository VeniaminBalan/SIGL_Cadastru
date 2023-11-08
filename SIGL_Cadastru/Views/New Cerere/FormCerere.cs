using AutoMapper;
using Contracts;
using FluentDateTime;
using Models;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Utils;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace SIGL_Cadastru.Views
{
    public partial class FormCerere : Form
    {
        private readonly IRepositoryManager _repo;
        private readonly IPdfGeneratorService _pdfService;
        private readonly EventService _eventService;

        private HashSet<Lucrare> Lucrari = new();

        private UC_PersoanaExistenta persoanaExistenta;
        private UC_PersoanaNoua persoanaNoua;

        private UC_DocumentsView UC_documente;
        private int suma;

        private IUCPersoana selected_uc_persoana;

        public FormCerere(IRepositoryManager repo, IPdfGeneratorService pdfService, EventService eventService)
        {
            _repo = repo;
            _pdfService = pdfService;
            _eventService = eventService;
           
            InitializeComponent();
            SetUC();
        }

        private async void FormCerere_Load(object sender, EventArgs e)
        {
            var responsabili = await GetPersoane(Role.Responsabil);
            comboBox_Responsabil.DataSource = responsabili;

            var executanti = await GetPersoane(Role.Executant);
            foreach (var ex in responsabili) 
            {
                executanti.Add(ex);
            }

            comboBox_Executant.DataSource = executanti;
        }

        private async Task<List<ComboItem>> GetPersoane(Role rol)
        {
            var pers = new List<Persoana>();

            switch (rol)
            {
                case Role.Executant:
                    pers = await _repo.Persoana.GetAllAync(new PeopleQueryParams(Role.Executant), false) as List<Persoana>;
                    break;
                case Role.Responsabil:
                    pers = await _repo.Persoana.GetAllAync(new PeopleQueryParams(Role.Responsabil), false) as List<Persoana>;
                    break;
                default:
                    break;
            }

            return pers.Select(r => new ComboItem
            {
                ID = r.Id,
                Text = string.Join(' ', r.Nume, r.Prenume)
            }).ToList();

        }

        void SetSelectedUC(IUCPersoana uc) 
        {
            this.selected_uc_persoana= uc;
            uc.ShowUC();
        }
        IUCPersoana GetSelectedUC() 
        {
            return this.selected_uc_persoana;
        }

        private void button_AdaugareServiciu_Click(object sender, EventArgs e)
        {
            FormAdaugareLucrare formAdaugareLucrare = new FormAdaugareLucrare();
            formAdaugareLucrare.Show();
            formAdaugareLucrare.SubmitButtonPressed += OnFormAdaugareSubmit;
        }

        private void OnFormAdaugareSubmit(object sender, AdaugareLucrareEventArgs e) 
        {
            AddLucrare(e.Lucrare);

            ((FormAdaugareLucrare)sender).Dispose();
        }


        private void AddLucrare(Lucrare lucrare) 
        {
            Lucrari.Add(lucrare);
            UpdateListBox();
            UpdateSuma();
        }

        private void UpdateListBox() 
        {
            listBoxLucrari.Items.Clear();
            foreach (var item in Lucrari)
            {
                listBoxLucrari.Items.Add(item.TipLucrare);
            }
        }

        private void UpdateSuma()
        {
            int suma = 0;
            foreach (var item in Lucrari)
            {
                suma += item.Pret;
            }
            this.suma = suma;
            label_suma.Text = suma.ToString();
        }
        private void buttonPNoua_Click(object sender, EventArgs e)
        {
            SetSelectedUC(persoanaNoua);
        }
        private void buttonPExistenta_Click(object sender, EventArgs e)
        {
            SetSelectedUC(persoanaExistenta);
        }
        private void SetUC() 
        {
            this.UC_documente = new UC_DocumentsView(new List<Document>());
            this.panel_UC_Documente.Controls.Add(UC_documente);

            var factory = new FormFactory();

            var uc_PNoua = factory.CreateUC_PersoanaNoua();
            this.persoanaNoua = uc_PNoua;
            panelUC.Controls.Add(uc_PNoua);


            var uc_PExistenta = factory.CreateUC_PersoanaExistenta();
            this.persoanaExistenta = uc_PExistenta;
            panelUC.Controls.Add(uc_PExistenta);

            SetSelectedUC(uc_PNoua);
        }
        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private async Task<Cerere> CreateCerere() 
        {
            if (!maskedTextBox_NrCadasrtral.MaskCompleted) 
            {
                throw new Exception("Introduceti Numarul cadastral");
            }

            if (string.IsNullOrWhiteSpace(textBox_termen.Text)) 
            {
                throw new Exception("Introduceti Termenul");
            }


            var nrCadastral = maskedTextBox_NrCadasrtral.Text;
            var id = Guid.NewGuid();
            var adaos = int.Parse(textBox_adaos.Text);
            var comment = textBox_comment.Text;

            var executantItem = (ComboItem)comboBox_Executant.SelectedItem;
            var responsabilItem = (ComboItem)comboBox_Responsabil.SelectedItem;

            var valabilDeLa = DateOnly.FromDateTime(dateTimePicker_dataSolicitarii.Value);
            var valabilPanaLa = DateOnly.FromDateTime(dateTimePicker_dataSolicitarii.Value.AddBusinessDays(int.Parse(textBox_termen.Text)));

            var responsabil = await _repo.Persoana.GetByIdAsync(responsabilItem.ID, true);
            var executant = await _repo.Persoana.GetByIdAsync(executantItem.ID, true);

            var result = await GetSelectedUC().GetPersoana();
            Persoana client = result.Value;

            return await Cerere.Create(
                id,
                client,
                executant,
                responsabil,
                valabilDeLa,
                valabilPanaLa,
                nrCadastral,
                adaos,
                comment,
                new Portofoliu(UC_documente.GetDocumente() , this.Lucrari.ToList()),
                new(),
                _repo.Cerere);

        }
        private async void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                var newCerere = await CreateCerere();
                
                _repo.Cerere.CreateCerere(newCerere);
                await _repo.SaveAsync();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("Cererea a fost creata!");

            _eventService.OnCereriUpdateRequire(EventArgs.Empty);
            this.Dispose();
        }
        private async void Button_vizualizare_Click(object sender, EventArgs e)
        {
            try
            {
                var newCerere = await CreateCerere();

                string path = _pdfService.GeneratePdf(newCerere);

                StartProcess.Run(path);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }


        }
        private void listBoxLucrari_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;


            var index = listBoxLucrari.SelectedIndex;

            try
            {
                var item = Lucrari.ToList()[index];
                Lucrari.Remove(item);

                UpdateListBox();
                UpdateSuma();
                UpdateSuma();
            }
            catch (Exception)
            {

                return;
            }

        }

        private void FormCerere_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Control control in panelUC.Controls)
            {

                control.Dispose();
            }
            _repo.DetachAll();
        }
    }

}
