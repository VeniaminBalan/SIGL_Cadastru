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

namespace SIGL_Cadastru.Views.Adaugare_Lucrare
{
    public partial class UC_Custom : UserControl, ILucrareaAddView
    {
        public UC_Custom()
        {
            InitializeComponent();
        }


        public Lucrare GetLucrare()
        {
            var text = textBox_lucrare.Text;
            var pret = -1;

            try
            {
                pret = int.Parse(textBox_pret.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Lucrare.Create(text, pret);
        }

        public void HideUC()
        {
            this.Visible = false;
        }
        public void ShowUC()
        {
            this.Visible = true;
            this.BringToFront();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
