﻿using AutoMapper;
using Contracts;
using FluentDateTime;
using Models;
using SIGL_Cadastru.AppConfigurations;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;
using SIGL_Cadastru.Utils;
using System.Data;


namespace SIGL_Cadastru.Views
{
    public partial class FormCerere : Form
    {
        public event EventHandler CreateButtonPressed;

        private readonly IRepositoryManager _repo;
        private HashSet<Lucrare> Lucrari = new();
        private UC_PersoanaExistenta persoanaExistenta;
        private UC_PersoanaNoua persoanaNoua;
        private int suma;

        private IUCPersoana selected_uc_persoana;

        public FormCerere(IRepositoryManager repo)
        {
            _repo = repo;
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
            uc.SetView();
        }
        IUCPersoana GetSelectedUC() 
        {
            return this.selected_uc_persoana;
        }


        private async void button_Add_Click(object sender, EventArgs e)
        {
            var id = Guid.NewGuid();
            var nrCadastral = maskedTextBox_NrCadasrtral.Text;
            var adaos = int.Parse(textBox_adaos.Text);
            var comment = textBox_comment.Text;

            try
            {

                var executantItem = (ComboItem)comboBox_Executant.SelectedItem;
                var responsabilItem = (ComboItem)comboBox_Responsabil.SelectedItem;

                var valabilDeLa = DateOnly.FromDateTime(dateTimePicker_dataSolicitarii.Value);
                var valabilPanaLa = DateOnly.FromDateTime(dateTimePicker_dataSolicitarii.Value.AddBusinessDays(int.Parse(textBox_termen.Text)));

                var responsabil = await _repo.Persoana.GetByIdAsync(responsabilItem.ID, true);
                var executant = await _repo.Persoana.GetByIdAsync(executantItem.ID, true);

                var result = await GetSelectedUC().GetPersoana();
                Persoana client = result.Value;


                Cerere newCerere = Cerere.Create(
                    id,
                    client.Id,
                    client,
                    executant.Id,
                    executant,
                    responsabil.Id,
                    responsabil,
                    valabilDeLa,
                    valabilPanaLa,
                    nrCadastral,
                    adaos,
                    comment,
                    this.Lucrari.ToList(),
                    new());


                _repo.Cerere.CreateCerere(newCerere);
                await _repo.SaveAsync();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error!" + ex.Message);
                return;
            }

            MessageBox.Show("Cererea a fost creata!");
            CreateButtonPressed?.Invoke(this, EventArgs.Empty);

        }


        private void button_AdaugareServiciu_Click(object sender, EventArgs e)
        {
            FormAdaugareLucrare formAdaugareLucrare = new FormAdaugareLucrare();
            formAdaugareLucrare.Show();
            formAdaugareLucrare.SubmitButtonPressed += OnFormAdaugareSubmit;
        }


        private void OnFormAdaugareSubmit(object sender, AdaugareLucrareEventArgs e) 
        {            
            AddLucrare(new Lucrare 
            {
                Id = new Guid(),
                Pret = e.suma,
                TipLucrare = e.lucrare
                
            });

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
        private void FormCerere_FormClosed(object sender, FormClosedEventArgs e)
        {
            _repo.DetachAll();
        }
    }

}
