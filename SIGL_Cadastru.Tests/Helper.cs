
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Repo.ValueObjects;
using SIGL_Cadastru.Tests.Mock;

namespace SIGL_Cadastru.Tests;

internal static class Helper
{
    internal static Persoana GetClient() 
    {
        return Persoana.Create(
            Guid.NewGuid(),
            "John",
            "Doe",
            "2003516234234",
            DateOnly.Parse("01/01/2000"),
            "pamant",
            "johndoe@email.com",
            null,
            Role.Client,
            new MockPersoanaRepository()
            ).Result;
    }

    internal static Persoana GetResponsabil() 
    {
        return Persoana.Create(
            Guid.NewGuid(),
            "nume responsabil",
            "prenume responsabil",
            "200351615435",
            DateOnly.Parse("02/02/2002"),
            "pamant",
            "responsabil@email.com",
            null,
            Role.Responsabil,
            new MockPersoanaRepository()
            ).Result;
    }

    internal static Persoana GetExecutant() 
    {
        return Persoana.Create(
            Guid.NewGuid(),
            "nume executant",
            "prenume executant",
            "20035164532",
            DateOnly.Parse("03/03/2003"),
            "pamant",
            "executant@email.com",
            null,
            Role.Executant,
            new MockPersoanaRepository()
            ).Result;
    }

    internal static Portofoliu GetPortofoliu() 
    {
        var portofoliu = new Portofoliu();

        portofoliu.AddLucrare(new Lucrare 
        {
            TipLucrare = "Lucrare tip 1",
            Pret = 1000
        });
        
        portofoliu.AddLucrare(new Lucrare 
        {
            TipLucrare = "Lucrare tip 2",
            Pret = 2000
        });

        portofoliu.AddDocument(new Document
        {
            Data = DateOnly.Parse("01/01/2001"),
            Denumirea = "Document",
            Exemplare = 1,
            Mentiuni = "",
            Nr = "42"

        }) ;

        return portofoliu;
    }

    internal static Cerere GetCerere(DateTime reference)
    {

        return Cerere.Create(
            Guid.NewGuid(),
            client: Helper.GetClient(),
            executant: Helper.GetExecutant(),
            responsabil: Helper.GetResponsabil(),
            reference,
            20,
            "124-53-61-124",
            0,
            "",
            Helper.GetPortofoliu(),
            new MockCerereRepository()
            ).Result;

    }
}
