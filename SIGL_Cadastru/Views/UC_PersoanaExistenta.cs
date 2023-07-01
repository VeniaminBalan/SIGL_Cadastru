using AutoMapper;
using Contracts;
using SIGL_Cadastru.Repo.Models;
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
        private List<Persoana> clienti;

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
            var client = comboBox1.SelectedItem as ComboItem;
            return clienti.FirstOrDefault(c => c.Id == client.ID);
        }

        public void SetView()
        {
            this.Visible= true;
            this.BringToFront();
        }

        private async void UC_PersoanaExistenta_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            clienti = await GetClientiAsync() as List<Persoana>;
            comboBox1.DataSource = clienti.Select(r => new ComboItem
            {
                ID = r.Id,
                Text = string.Join(' ', r.Nume, r.Prenume)
            }).ToList();
        }

        private async Task<IEnumerable<Persoana>> GetClientiAsync() 
        {
            var pers = await _repo.Persoana.GetAllClientiAync(true);
            return pers;
        }
    }
}
