using Contracts;
using Models;
using SIGL_Cadastru.Repo.Contracts;
using SIGL_Cadastru.Repo.ValueObjects;
using FluentDateTime;

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
        int adaos, 
        string comment, 
        Portofoliu portofoliu, 
        List<CerereStatus> stateList,
        ICerereRepository _repo) 
    {
        if (stateList.Count() == 0)
            stateList.Add(new CerereStatus
            {
                Id = Guid.NewGuid(),
                Created = DateOnly.FromDateTime(DateTime.Now),
                CerereId = id,
                Starea = Status.Inlucru
            }) ;

        if (string.IsNullOrEmpty(nrCadastral))
            throw new Exception("Nr cadastral gresit");

        if (termen <= 0)
            throw new Exception("Termen invalid");


        DateOnly valabilPanaLa = DateOnly.FromDateTime(valabilDeLa.AddBusinessDays(termen));

        int costTotal = adaos;

        foreach (var item in portofoliu.Lucrari)
        {
            costTotal += item.Pret;
        }

        if (costTotal < 0)
            throw new Exception("Costul total nu poate fi mai mic de 0");

        NrCerere? last = await _repo.GetLastNr();

        if (last is null)
        {
            last = new NrCerere(DateTime.Now.Year, 1);
        }
        else 
        {
            last.Index++;
        }

        string nr = $"{last.Year}/{last.Index.ToString("0000")}";

        return new Cerere(id, 
            client,
            executant,
            responsabil,
            nr, 
            DateOnly.FromDateTime(valabilDeLa),
            valabilPanaLa, 
            nrCadastral, 
            adaos, 
            comment, 
            stateList, 
            portofoliu, 
            last);
    }

    public void AddStatus(CerereStatus cerereStatus)
    {
        if (cerereStatus.Created < this.ValabilDeLa)
            throw new Exception($"data starii ({cerereStatus.Created}) nu poate fi mai devreme de data de cand e valabila cererea");

        if (cerereStatus.Starea == Status.Eliberat && this.StatusList.Any(c => c.Starea == Status.Eliberat))
            throw new Exception($"Cererea poate fi eliberata doar o singura data");

        if (cerereStatus.Starea == Status.Prelungit && cerereStatus.Created < ValabilPanaLa)
            throw new Exception($"Starea \"Prelungit\" poate fi setata dupa data {ValabilPanaLa}");

        _stateList.Add(cerereStatus);
        Starea = SetStatus(_stateList);

    }

    public void SetComment(string _comment) 
    {
        this.Comment = _comment;
    }

    private static Status SetStatus(List<CerereStatus> stari)
    {
        if (stari.Any(c => c.Starea == Status.Eliberat))
            return Status.Eliberat;

        var state = stari
            .Where(s => s.Starea != Status.Prelungit)
            .OrderByDescending(x => x.Created).FirstOrDefault();

        if (state is null)
            return Status.Inlucru;

        return state.Starea;
    }
}
