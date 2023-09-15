using AutoMapper.Execution;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Utils;
using SIGL_Cadastru.Views.Adaugare_Lucrare;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SIGL_Cadastru.Views
{
    public partial class FormAdaugareLucrare : Form
    {
        public event EventHandler<AdaugareLucrareEventArgs> SubmitButtonPressed;


        private readonly UC_Tree uc_tree = new UC_Tree();
        private readonly UC_Custom uc_custom = new UC_Custom();

        private ILucrareaAddView selected_uc;

        public FormAdaugareLucrare()
        {
            InitializeComponent();

            panel.Controls.Add(uc_custom);
            panel.Controls.Add(uc_tree);
            SetSelectedUC(uc_tree);
        }

        void SetSelectedUC(ILucrareaAddView uc)
        {
            this.selected_uc = uc;
            uc.ShowUC();
        }
        ILucrareaAddView GetSelectedUC()
        {
            return selected_uc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lucrare lucrare;

            try
            {
                lucrare = selected_uc.GetLucrare();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            var text = lucrare.TipLucrare;
            var pret = lucrare.Pret;

            DialogResult dialogResult = MessageBox.Show($"{text} \n Suma:{pret}", "Adaugare Lucrare", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SubmitButtonPressed?.Invoke(this, new AdaugareLucrareEventArgs
                {
                    Lucrare = lucrare
                });
            } 

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                SetSelectedUC(uc_custom);
            }
            else
            {
                SetSelectedUC(uc_tree);
            }
        }
    }

    public class AdaugareLucrareEventArgs : EventArgs
    {
        public Lucrare Lucrare { get; init; }
    }
}
