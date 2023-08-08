using AutoMapper;
using Contracts;
using Models;
using SIGL_Cadastru.App.Contracts;
using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.App.Entities.DataTransferObjects;
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
    public partial class FormViewCerere : Form
    {
        public event EventHandler<EventArgs> DataChenged;

        private readonly IServiceManager _service;
        private readonly IMapper _mapper;
        private readonly Guid _cererId;

        private CerereDto? cerere = null;
        private List<LucrareDto> lucrari = new();
        private List<CerereStatusDto> cerereStatusLsit = new();
        private PersoanaDto Client = null;

        public FormViewCerere(IServiceManager service, IMapper mapper, Guid cerereId)
        {
            _service = service;
            _mapper = mapper;
            _cererId = cerereId;
            InitializeComponent();
        }

        private async void FormViewCerere_Load(object sender, EventArgs e)
        {
            await Update();
        }

        private async Task Update() 
        {
            this.cerere = await _service.CerereService.GetByIdAsync(_cererId, false);
            lucrari = (await _service.LucrareService.GetAllByIdAsync(_cererId, false)).ToList();
            cerereStatusLsit = (await _service.CerereStatus.GetByIdAsync(_cererId, false)).ToList();
            Client = await _service.PersoanaService.GetByIdAsync(cerere.ClientId, false);

            SetView(cerere);
        }

        private void SetView(CerereDto cerere) 
        {
            label_executant.Text = cerere.Executant;
            label_responsabil.Text = cerere.Responsabil;

            label_valabilDeLa.Text = cerere.ValabilDeLa.ToString();
            label_ValabilPanaLa.Text = cerere.ValabilPanaLa.ToString();
            label_pretTotal.Text = cerere.CostTotal.ToString();
            label_StareCererii.Text = cerere.StareaCererii.ToString();
            label_pretTotal.Text = cerere.CostTotal.ToString();

            dataGridView1.DataSource = lucrari;
            dataGridViewStatus.DataSource = cerereStatusLsit;

           
            label_Nume.Text = Client.Nume;
            label_prenume.Text = Client.Prenume;
            label_idnp.Text = Client.IDNP;
            label_domiciliu.Text = Client.Domiciliu;
            label_email.Text = Client.Email;
            label_telefon.Text = Client.Telefon;

            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            await _service.SaveAsync();
            DataChenged!.Invoke(sender, new EventArgs());
        }
    }
}
