using Models;
using SIGL_Cadastru.Repo.Models;
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
    public partial class FormAddState : Form
    {
        public event EventHandler AdaugareButtonClicked;
        public FormAddState()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(Status));
        }

        public DateOnly Date
        {
            get
            {
                return DateOnly.FromDateTime(dateTimePicker1.Value);
            }
        }

        public Status Status { get 
            {
                return (Status)comboBox1.SelectedItem;
            } 
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            AdaugareButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void button_Anulare_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
