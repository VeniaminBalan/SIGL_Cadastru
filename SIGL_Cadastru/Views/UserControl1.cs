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
    public partial class UserControl1 : UserControl
    {
        List<Dosar> dosare;
        private IRepository<Dosar> _repository;
        public FormMain ParentForm { get; set; }
        public UserControl1()
        {
            InitializeComponent();
            dosare = new List<Dosar>();

        }


        private void UpdateDataGrid()
        {
            dosare = _repository.Get().ToList();
            dataGridView_dosare.DataSource = dosare;
            dataGridView_dosare.Update();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this._repository = ParentForm.GetRepository();
            UpdateDataGrid();
        }
    }
}
