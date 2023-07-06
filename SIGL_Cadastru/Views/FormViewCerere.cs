using AutoMapper;
using Contracts;
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
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly Guid _cererId;

        public FormViewCerere(IRepositoryManager repo, IMapper mapper, Guid cerereId)
        {
            _repo = repo;
            _mapper = mapper;
            _cererId = cerereId;
            InitializeComponent();
        }

        private async void FormViewCerere_Load(object sender, EventArgs e)
        {
            var cerere = await _repo.Cerere.GetByIdAsync(_cererId, true);
            SetView(cerere);
        }

        private void SetView(Cerere cerere) 
        {
            var cerereDto = _mapper.Map<CerereDto>(cerere);

            label_executant.Text = cerereDto.Executant;
            label_responsabil.Text = cerereDto.Responsabil;

            switch (cerereDto.StareaCererii)
            {
                case Status.Inlucru:
                    label_stareaCererii.Text = "In Lucru";
                    break;
                case Status.LaReceptie:
                    label_stareaCererii.Text = "La Receptie";
                    break;
                case Status.Eliberat:
                    label_stareaCererii.Text = "Eliberat";
                    break;
                case Status.Respins:
                    label_stareaCererii.Text = "Respins";
                    label_stareaCererii.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }

            label_valabilDeLa.Text = cerereDto.ValabilDeLa.ToString();
            label_ValabilPanaLa.Text = cerereDto.ValabilPanaLa.ToString();
            label_pretTotal.Text = cerere.CostTotal.ToString();

            dataGridView1.DataSource =  _mapper.Map<List<LucrareDto>>(cerere.Lucrari);

            //label_pretTotal.Text = cerereDto.


            label_Nume.Text = cerere.Client.Nume;
            label_prenume.Text = cerere.Client.Prenume;
            label_idnp.Text = cerere.Client.IDNP;
            label_domiciliu.Text = cerere.Client.Domiciliu;
            label_email.Text = cerere.Client.Email;
            label_telefon.Text = cerere.Client.Telefon;
        }

    }
}
