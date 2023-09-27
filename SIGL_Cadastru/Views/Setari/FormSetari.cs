using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIGL_Cadastru.Views.Setari
{
    public partial class FormSetari : Form
    {
        private readonly IServiceManager _service;
        private readonly EventService _eventService;
        private static FormSetari? _form;

        public bool UpdateRequire = false;

        private FormSetari(IServiceManager service, EventService eventService)
        {
            _service = service;
            _eventService = eventService;

            InitializeComponent();
        }

        public static FormSetari Create(IServiceManager service, EventService eventService)
        {
            if (_form is null || _form.IsDisposed) 
            {
                _form = new FormSetari(service, eventService);
            }
            
            return _form;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            splitContainer1.Panel2.Controls.Add(UC_PersoaneSetari.Create(_service, _eventService, this));
        }

        private void FormSetari_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UpdateRequire)
                _eventService.OnCereriUpdateRequire(EventArgs.Empty);

            foreach (Control control in splitContainer1.Panel2.Controls)
            {

                control.Dispose();
            }

            this.Dispose();
        }
    }
}
