using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Repository;
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
    public partial class FormCerere : Form
    {
        private readonly IRepository<Dosar> _repository;
        public List<Dosar> dosare;

        public FormCerere(IRepository<Dosar> repository)
        {
            this._repository = repository;
            InitializeComponent();
            dosare= new List<Dosar>();
        }

        private async void button_Add_Click(object sender, EventArgs e)
        {

            var dosar = new Dosar
            {
                
            };


            var d = await _repository.AddAsync(dosar);

        }

        private async Task<IEnumerable<Dosar>> GetData() 
        {
            return await _repository.GetAsync();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
