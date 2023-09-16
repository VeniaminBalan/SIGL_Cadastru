using SIGL_Cadastru.App.Contracts;
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
        private static FormSetari _form;
        private FormSetari(IServiceManager service)
        {
            _service = service;
            InitializeComponent();
        }

        public static FormSetari Create(IServiceManager service)
        {
            if (_form is null || _form.IsDisposed) 
            {
                _form = new FormSetari(service);
            }
            
            return _form;
        }
    }
}
