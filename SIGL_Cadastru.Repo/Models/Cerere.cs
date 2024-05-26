using Contracts;
using Models;
using SIGL_Cadastru.Repo.Contracts;
using SIGL_Cadastru.Repo.ValueObjects;
using FluentDateTime;
using SIGL_Cadastru.Repo.Exceptions.CerereException;

namespace SIGL_Cadastru.Repo.Models;


public enum Status
{
    Inlucru,
    LaReceptie,
    Eliberat,
    Respins,
    Prelungit
}
public class Cerere : IModel
{
    public Guid Id { get;private set; }
    public Guid ClientId { get; private set; }
    public Persoana Client { get; private set; }

    public Guid ExecutantId { get; private set; }
    public Persoana Executant { get; private set; }

    public Guid ResponsabilId { get; private set; }
    public Persoana Responsabil { get; private set; }

    public string Nr { get; private set; }
    public NrCerere? CerereNr { get; private set; }
    public DateOnly ValabilDeLa { get; private set; }
    public DateOnly ValabilPanaLa { get; private set; }

    public string NrCadastral { get; private set; }
    public int Adaos { get; private set; }
    public string Comment { get; private set; }
    public Status Starea { get; set; }
    public Portofoliu Portofoliu { get; private set; }


    private readonly List<CerereStatus> _stateList = new();
    public IReadOnlyList<CerereStatus> StatusList => _stateList;


    private Cerere(Guid id, Persoana client, Persoana executant, Persoana responsabil,string nr ,DateOnly valabilDeLa, DateOnly valabilPanaLa, string nrCadastral, int adaos, string comment, List<CerereStatus> stateList, Portofoliu portofoliu, NrCerere nrCerere)
    {
        Id = id;
        ClientId = client.Id;
        Client = client;
        ExecutantId = executant.Id;
        Executant = executant;
        ResponsabilId = responsabil.Id;
        Responsabil = responsabil;
        ValabilDeLa = valabilDeLa;
        ValabilPanaLa = valabilPanaLa;
        NrCadastral = nrCadastral;
        Adaos = adaos;
        Comment = comment;
        Portofoliu = portofoliu;
        _stateList = stateList;
        Nr = nr;
        CerereNr = nrCerere;
        Starea = Status.Inlucru;
    }

    private Cerere() { }


    public async static Task<Cerere> Create(
        Guid id, 
        Persoana client, 
        Persoana executant, 
        Persoana responsabil, 
        DateTime valabilDeLa, 
        int termen, 
        string nrCadastral, 
        int adaos,          string comment, 
        Portofoliu portofoliu,
        ICerereRepository _repo) 
    {


        VerifyRoles(responsabil, executant);
        VerifynrCadastral(nrCadastral);
        VerifyTotalPrice(adaos, portofoliu.Lucrari);

        NrCerere nextNumber = await _repo.GetNextNumber();

        var cerere = new Cerere 
        {
            Id = id,
            Client = client,
            Executant = executant,
            Responsabil = responsabil,
            Nr = nextNumber.ToString('/'),
            ValabilDeLa = DateOnly.FromDateTime(valabilDeLa),
            ValabilPanaLa = GetValabilPanaLa(valabilDeLa, termen),
            NrCadastral = nrCadastral,
            Adaos = adaos,
            Comment = comment,
            Portofoliu = portofoliu,
            CerereNr = nextNumber,
        };

        cerere.AddStatus(new CerereStatus
        {
            Id = Guid.NewGuid(),
            Created = DateOnly.FromDateTime(DateTime.Now),
            CerereId = cerere.Id,
            Starea = Status.Inlucru
        });

        return cerere;   
    }

    public void AddStatus(CerereStatus cerereStatus)
    {
        if (this.Starea == Status.Eliberat)
            throw new InvalidOperationException("Cererea deja a fost eliberata !");

        if (cerereStatus.Created < this.ValabilDeLa)
            throw new InvalidOperationException($"data starii ({cerereStatus.Created}) nu poate fi mai devreme de data de cand e valabila cererea");

        if (cerereStatus.Starea == Status.Prelungit && cerereStatus.Created < ValabilPanaLa)
            throw new InvalidOperationException($"Starea \"Prelungit\" poate fi setata dupa data {ValabilPanaLa}");

        _stateList.Add(cerereStatus);
        Starea = SetStatus(_stateList);
    }

    public void SetComment(string _comment) 
    {
        this.Comment = _comment;
    }

    private Status SetStatus(List<CerereStatus> stari)
    {

        if (stari.Any(c => c.Starea == Status.Eliberat))
            return Status.Eliberat;

        var state = stari
            .Where(s => s.Starea != Status.Prelungit)
            .OrderByDescending(x => x.Created)
            .FirstOrDefault();

        if (state is null)
            return Status.Inlucru;

        return state.Starea;
    }

    private static void VerifyTotalPrice(int adaos, IEnumerable<Lucrare> lurari) 
    {
        int costTotal = adaos + lurari.Sum(l => l.Pret);


        if (costTotal <= 0)
            throw new InvalidPriceException("Costul total nu poate fi mai mic sau egal cu 0");
    }

    private static void VerifyRoles(Persoana responsabil, Persoana executant) 
    {
        if (responsabil.Rol != Role.Responsabil)
            throw new InvalidRoleException(Role.Responsabil, responsabil);

        if (executant.Rol != Role.Executant && executant.Rol != Role.Responsabil)
            throw new InvalidRoleException(Role.Executant ,executant);
    }

    private static DateOnly GetValabilPanaLa(DateTime valabilDeLa, int termen) 
    {
        if (termen <= 0)
            throw new InvalidDateException("Termen invalid");

        return DateOnly.FromDateTime(valabilDeLa.AddBusinessDays(termen));
    }

    private static void VerifynrCadastral(string nrCadastral) 
    {
        if (string.IsNullOrEmpty(nrCadastral))
            throw new EmptyFieldException(nameof(NrCadastral), "Nr cadastral nu poate fi gol");
    }
}
