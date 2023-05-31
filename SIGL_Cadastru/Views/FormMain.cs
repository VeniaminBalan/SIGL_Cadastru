using SIGL_Cadastru.AppConfigurations;
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
    public partial class FormMain : Form
    {
        private readonly IRepository<Dosar> _repository;
        public FormMain(IRepository<Dosar> repository)
        {
            _repository = repository;
            InitializeComponent();
            this.userControl11.ParentForm = this;

        }

        public IRepository<Dosar> GetRepository() 
        {
            return _repository;
        }

        private void button_cerere_noua_Click(object sender, EventArgs e)
        {
            var form_cerere = new FormFactory().CreateCerere();
            form_cerere.Show();
        }
    }
}
