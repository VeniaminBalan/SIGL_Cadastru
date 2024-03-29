﻿using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter;
using SIGL_Cadastru.AppConfigurations;
using System.Reflection;

namespace SIGL_Cadastru.Views
{
    public partial class FormMain : Form
    {
        private readonly FormFactory _factory = new();
        private readonly UC_Main uc_Main;

        private static FormMain _form;

        private FormMain()
        {
            InitializeComponent();
            AppCenter.Start("53a47c06-b695-4143-96f2-88d4bfa05d15", typeof(Analytics), typeof(Crashes));
            uc_Main = Add_UC_Main();

            label_version.Text = $"Version: {Program.Version}";
        }

        public static FormMain Create() 
        {
            if (_form is null || _form.IsDisposed) 
            {
                _form = new FormMain();
            }

            return _form;
        }

        public UC_Main Add_UC_Main() 
        {
            var uc_main = _factory.CreateUC_Main();
            panel_content.Controls.Add(uc_main);
            uc_main.Dock = DockStyle.Fill;
            uc_main.BringToFront();

            return uc_main;
        }

        private void button_cerere_noua_Click(object sender, EventArgs e)
        {
            var form_cerere = _factory.CreateCerere();
            form_cerere.Show();
        }

        private void button_setari_Click(object sender, EventArgs e)
        {
            var form = _factory.CreateFormSetari();
            form.ShowDialog();
        }
    }
}
