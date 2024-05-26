
using Models;
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Tests.Mock;

namespace SIGL_Cadastru.Tests.CerereTests;

public class CreateCerereTests
{

    DateTime referenceDateTime = DateTime.Parse("05/05/2023");

    [Fact]
    public async Task GivenRightInput_CreateCerere_ReturnsNewCerere() 
    {

        var cerere = await Cerere.Create(
            Guid.NewGuid(),
            client: Helper.GetClient(),
            executant: Helper.GetExecutant(),
            responsabil: Helper.GetResponsabil(),
            referenceDateTime,
            20,
            "124-53-61-124",
            0,
            "",
            Helper.GetPortofoliu(),
            new MockCerereRepository()
            );


        Assert.NotNull( cerere );
        Assert.Equal(cerere.CerereNr.Year, DateTime.Now.Year);
        Assert.Equal(cerere.StatusList.Count, 1);
    } 
    
    [Fact]
    public async Task GivenInvalidResponsabil_ThrowsError() 
    {

        var repository = new MockCerereRepository();
        var client = Helper.GetClient();
        var executant = Helper.GetExecutant();
        var portofoliu = Helper.GetPortofoliu();



        await Assert.ThrowsAsync<Exception>( async () => await Cerere.Create(
            Guid.NewGuid(),
            client: client,
            executant: executant,
            responsabil: executant,
            referenceDateTime,
            20,
            "124-53-61-124",
            0,
            "",
            portofoliu,
            repository));
    }
    
    [Fact]
    public async Task GivenInvalidResponsabilAsExecutant_ReturnNewCerere() 
    {

        var repository = new MockCerereRepository();
        var client = Helper.GetClient();
        var executant = Helper.GetExecutant();
        var portofoliu = Helper.GetPortofoliu();



        await Assert.ThrowsAsync<Exception>( async () => await Cerere.Create(
            Guid.NewGuid(),
            client: client,
            executant: executant,
            responsabil: executant,
            referenceDateTime,
            20,
            "124-53-61-124",
            0,
            "",
            portofoliu,
            repository));
    }


    [Fact]
    public async Task GivenEmptyNrCadastal_ThrowsError()
    {

        var repository = new MockCerereRepository();
        var client = Helper.GetClient();
        var executant = Helper.GetExecutant();
        var portofoliu = Helper.GetPortofoliu();
        var nrCadastral = ""; // invalid field



        await Assert.ThrowsAsync<Exception>(async () => await Cerere.Create(
            Guid.NewGuid(),
            client: client,
            executant: executant,
            responsabil: executant,
            referenceDateTime,
            20,
            nrCadastral,
            0,
            "",
            portofoliu,
            repository));
    }   
    
    
    [Fact]
    public async Task GivenInvalidPrice_ThrowsError()
    {

        var repository = new MockCerereRepository();
        var client = Helper.GetClient();
        var executant = Helper.GetExecutant();
        var portofoliu = Helper.GetPortofoliu();
        var nrCadastral = "13-531-412";
        var adaos = -10_000;



        await Assert.ThrowsAsync<Exception>(async () => await Cerere.Create(
            Guid.NewGuid(),
            client: client,
            executant: executant,
            responsabil: executant,
            referenceDateTime,
            20,
            nrCadastral,
            adaos,
            "",
            portofoliu,
            repository));
    } 
    

}
