using AutoMapper;
using Contracts;
using Exceptions;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.Query;
using SIGL_Cadastru.Services;
using SIGL_Cadastru.Utils;
using System.Data;


namespace SIGL_Cadastru.Views
{
    public partial class UC_PersoanaExistenta : UserControl, IUCPersoana
    {
        private readonly IRepositoryManager _repo;
        private readonly EventService _eventService;
        private List<Persoana> clienti = new();
        private ComboItem? selectedItem;
        private string search = string.Empty;

        private void SetSelectedItem(ComboItem? item) 
        {
            selectedItem = item;

            if (item is not null)
                label_selectedPerson.Text = item.Text;
            else label_selectedPerson.Text = "";
        }

        public UC_PersoanaExistenta(IRepositoryManager repo, EventService eventService)
        {
            _repo = repo;
            _eventService = eventService;
            eventService.PersoaneUpdateRequire += EventService_PersoaneUpdateRequire;
            InitializeComponent();
        }

        private async void EventService_PersoaneUpdateRequire(object? sender, EventArgs e)
        {
            UC_PersoanaExistenta_Load(this, EventArgs.Empty);
        }

        public void HideUC()
        {
            this.Visible= false;
        }
        public void ShowUC()
        {
            this.Visible = true;
            this.BringToFront();
        }

        public Task<Result<Persoana>> GetPersoana()
        {
            if (selectedItem is null)
                throw new PersonNotFoundException("persoana nu este selectata");
            var p = clienti.First(c => c.Id == selectedItem.ID);

            return Task.FromResult(new Result<Persoana>(ResultState.ExistingObject, p));
        }


        private async void UC_PersoanaExistenta_Load(object sender, EventArgs e)
        {       
            await GetQuariablePeopleAsync(new PeopleQueryParams());
            SetSelectedItem(listBox_persoane.SelectedItem as ComboItem);
            await UpdateListBox();
        }

        private async Task UpdateListBox() 
        {
            await GetQuariablePeopleAsync(new PeopleQueryParams(search, null));
            listBox_persoane.DataSource = clienti!.Select(r => new ComboItem
            {
                ID = r.Id,
                Text = string.Join(' ', r.Nume, r.Prenume, $"({r.IDNP})")
            }).ToList();

            SetSelectedItem(listBox_persoane.SelectedItem as ComboItem);

        }

        private async Task GetQuariablePeopleAsync(PeopleQueryParams peopleQuery) 
        {
            clienti = await _repo.Persoana.GetAllAync(peopleQuery, true) as List<Persoana>;
        }
        private void listBox_persoane_Click(object sender, EventArgs e)
        {
            SetSelectedItem(listBox_persoane.SelectedItem as ComboItem);
        }

        private async void textBox_search_TextChanged(object sender, EventArgs e)
        {
            search = textBox_search.Text;
            await UpdateListBox();
        }

        private void UC_PersoanaExistenta_ControlRemoved(object sender, ControlEventArgs e)
        {
            _eventService.PersoaneUpdateRequire -= EventService_PersoaneUpdateRequire;
            this.Dispose();
        }
    }
}
