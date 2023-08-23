using AutoMapper;
using Contracts;
using Exceptions;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;
using SIGL_Cadastru.Utils;
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
    public partial class UC_PersoanaExistenta : UserControl, IUCPersoana
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private List<Persoana> clienti = new();
        private ComboItem? selectedItem;
        private string search = string.Empty;

        private void SetSelectedItem(ComboItem? item) 
        {
            selectedItem = item;

            if (item is not null)
                label_selectedPerson.Text = item.Text;
        }

        public UC_PersoanaExistenta(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            InitializeComponent();
        }

        public void CloseView()
        {
            this.Visible= false;
        }

        public Persoana GetPersoana()
        {
            if (selectedItem is null)
                throw new PersonNotFoundException("persoana nu este selectata");
            return clienti.First(c => c.Id == selectedItem.ID);
        }

        public void SetView()
        {
            this.Visible= true;
            this.BringToFront();
        }

        private async void UC_PersoanaExistenta_Load(object sender, EventArgs e)
        {
            listBox_persoane.Items.Clear();          

            await GetQuariablePeopleAsync(new PeopleQueryParams());
            SetSelectedItem(listBox_persoane.SelectedItem as ComboItem);
            await UpdateListBox();

        }

        private async Task UpdateListBox() 
        {
            await GetQuariablePeopleAsync();
            listBox_persoane.DataSource = clienti!.Select(r => new ComboItem
            {
                ID = r.Id,
                Text = string.Join(' ', r.Nume, r.Prenume, $"({r.IDNP})")
            }).ToList();

            SetSelectedItem(listBox_persoane.SelectedItem as ComboItem);

        }

        private async Task GetQuariablePeopleAsync(PeopleQueryParams peopleQuery) 
        {
            clienti = await _repo.Persoana.GetAllAync(peopleQuery, false) as List<Persoana>;
        }
        private void listBox_persoane_Click(object sender, EventArgs e)
        {
            SetSelectedItem(listBox_persoane.SelectedItem as ComboItem);
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            search = textBox_search.Text;
        }
    }
}
