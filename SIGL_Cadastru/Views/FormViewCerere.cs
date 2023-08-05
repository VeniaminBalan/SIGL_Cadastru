using AutoMapper;
using Contracts;
using Models;
using SIGL_Cadastru.App.Entities;
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

        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly Guid _cererId;
        private Cerere cerere = null;

        public FormViewCerere(IRepositoryManager repo, IMapper mapper, Guid cerereId)
        {
            _repo = repo;
            _mapper = mapper;
            _cererId = cerereId;
            InitializeComponent();
        }

        private async void FormViewCerere_Load(object sender, EventArgs e)
        {
            this.cerere = await _repo.Cerere.GetByIdAsync(_cererId, true);
            SetView(cerere);
        }

        private void SetView(Cerere cerere) 
        {
            var cerereDto = _mapper.Map<CerereDto>(cerere);

            label_executant.Text = cerereDto.Executant;
            label_responsabil.Text = cerereDto.Responsabil;

            comboBox_stareaCererii.DataSource = Enum.GetValues(typeof(Status));
            comboBox_stareaCererii.SelectedItem = cerereDto.StareaCererii;

            label_valabilDeLa.Text = cerereDto.ValabilDeLa.ToString();
            label_ValabilPanaLa.Text = cerereDto.ValabilPanaLa.ToString();
            label_pretTotal.Text = cerere.CostTotal.ToString();

            dataGridView1.DataSource =  _mapper.Map<List<LucrareDto>>(cerere.Lucrari);

            label_pretTotal.Text = cerere.CostTotal.ToString();


            label_Nume.Text = cerere.Client.Nume;
            label_prenume.Text = cerere.Client.Prenume;
            label_idnp.Text = cerere.Client.IDNP;
            label_domiciliu.Text = cerere.Client.Domiciliu;
            label_email.Text = cerere.Client.Email;
            label_telefon.Text = cerere.Client.Telefon;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var status = (Status)comboBox_stareaCererii.SelectedItem;

            var statusList = cerere.StatusList;

 

            switch (status) 
            {
                case Status.Eliberat:
                    statusList.Add(CerereStatus.NewStatusEliberat(cerere, DateOnly.FromDateTime(DateTime.Now.AddDays(10))) );
                    break;
            }


            cerere.StatusList = statusList;
            await _repo.SaveAsync();
            DataChenged!.Invoke(sender, new EventArgs());
        }
    }
}
