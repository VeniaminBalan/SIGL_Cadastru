using Contracts;
using SIGL_Cadastru.Repo.Contracts;
using SIGL_Cadastru.Repo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGL_Cadastru.Views
{
    public partial class FormCerere : Form
    {
        private readonly IRepositoryManager _repo;
        private List<Lucrare> Lucrari = new List<Lucrare>();


        public FormCerere(IRepositoryManager repo)
        {
            _repo = repo;
            InitializeComponent();

            listBoxLucrari.SelectionMode = SelectionMode.MultiExtended;
        }

        private async void button_Add_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("Error!");
                return;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            FormAdaugareLucrare formAdaugareLucrare = new FormAdaugareLucrare();
            formAdaugareLucrare.Show();
            formAdaugareLucrare.SubmitButtonPressed += OnFormAdaugareSubmit;
        }


        private void OnFormAdaugareSubmit(object sender, AdaugareLucrareEventArgs e) 
        {            
            AddLucrare(new Lucrare(e));

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
                listBoxLucrari.Items.Add(item.lucrare);
            }
        }

        private void UpdateSuma()
        {
            int suma = 0;
            foreach (var item in Lucrari)
            {
                suma += item.suma;
            }

            label_suma.Text = suma.ToString();
        }

    }

    class Lucrare
    {
        public string lucrare;
        public int suma;

        public Lucrare() { }

        public Lucrare(AdaugareLucrareEventArgs adaugareLucrare) 
        {
            this.lucrare = adaugareLucrare.lucrare;
            this.suma = adaugareLucrare.suma;
        }
    }
}
