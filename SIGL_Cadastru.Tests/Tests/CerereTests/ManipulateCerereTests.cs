using Models;
using SIGL_Cadastru.Repo.Models;

namespace SIGL_Cadastru.Tests.Tests.CerereTests;

public class ManipulateCerereTests
{

    [Fact]
    public void GivenValidStatus_UpdatesTheObject()
    {

        var referenceDate = DateTime.Now;

        Cerere cerere = Helper.GetCerere(referenceDate);

        var status = new CerereStatus
        {
            Id = Guid.NewGuid(),
            Created = DateOnly.FromDateTime(referenceDate.AddDays(2)),
            Starea = Status.LaReceptie
        };


        cerere.AddStatus(status);

        Assert.Equal(2, cerere.StatusList.Count());
        Assert.Equal(Status.LaReceptie, cerere.Starea);

    } 
    
    
    [Fact]
    public void GivenNewStatus_AfterEliberat_ThrowsException()
    {

        var referenceDate = DateTime.Now;

        Cerere cerere = Helper.GetCerere(referenceDate);

        var status = new CerereStatus
        {
            Id = Guid.NewGuid(),
            Created = DateOnly.FromDateTime(referenceDate.AddDays(2)),
            Starea = Status.Eliberat
        };

        cerere.AddStatus(status);


        var invalidStatus = new CerereStatus
        {
            Id = Guid.NewGuid(),
            Created = DateOnly.FromDateTime(referenceDate.AddDays(4)),
            Starea = Status.Respins // invalid
        };


        Assert.ThrowsAny<Exception>(() => cerere.AddStatus(invalidStatus));

    }
    
    
    
    [Fact]
    public void GivenNewStatus_BeforeAvailableDate_ThrowsException()
    {

        var referenceDate = DateTime.Now;

        Cerere cerere = Helper.GetCerere(referenceDate);

        var status = new CerereStatus
        {
            Id = Guid.NewGuid(),
            Created = DateOnly.FromDateTime(referenceDate.AddDays(-2)),
            Starea = Status.Eliberat
        };


        Assert.ThrowsAny<Exception>(() => cerere.AddStatus(status));
    }



}
