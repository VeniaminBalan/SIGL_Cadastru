
using SIGL_Cadastru.Repo.Models;
using SIGL_Cadastru.Tests.Mock;

namespace SIGL_Cadastru.Tests.Tests.PerosanaTests;

public class CreatePersoanaTests
{

    [Fact]
    public void GivenValidInput_ReturnsNewPerson() 
    {
        var id = Guid.NewGuid();
        var nume = "nume";
        var prenume = "prenume";
        var idnp = "14567252441";
        var domiciliu = "domiciliu";
        var dataNasterii = DateOnly.Parse("10/10/2000");
        var mockRepo = new MockPersoanaRepository();


        Assert.NotNull(Persoana.Create(id, nume, prenume, domiciliu, dataNasterii, domiciliu, null, null, Role.Client, mockRepo).Result);
    } 
    
    [Fact]
    public async Task GivenInvalidEmail_ThrowsError() 
    {
        var id = Guid.NewGuid();
        var nume = "nume";
        var prenume = "prenume";
        var idnp = "14567252441";
        var domiciliu = "domiciliu";
        var dataNasterii = DateOnly.Parse("10/10/2000");
        var mockRepo = new MockPersoanaRepository();
        var email = "email"; // invalid filed


        await Assert.ThrowsAnyAsync<Exception>(async () => 
        await Persoana.Create(id, nume, prenume, domiciliu, dataNasterii, domiciliu, email, null, Role.Client, mockRepo));
    }
    
    [Fact]
    public async Task GivenEmptyName_ThrowsError() 
    {
        var id = Guid.NewGuid();
        var nume = ""; // invalid filed
        var prenume = "prenume";
        var idnp = "14567252441";
        var domiciliu = "domiciliu";
        var dataNasterii = DateOnly.Parse("10/10/2000");
        var mockRepo = new MockPersoanaRepository();
        var email = "email";


        await Assert.ThrowsAnyAsync<Exception>(async () =>
        await Persoana.Create(id, nume, prenume, domiciliu, dataNasterii, domiciliu, email, null, Role.Client, mockRepo));
    } 
    
    [Fact]
    public async Task GivenEmptyPrenume_ThrowsError() 
    {
        var id = Guid.NewGuid();
        var nume = "nume"; 
        var prenume = ""; // invalid filed
        var idnp = "14567252441";
        var domiciliu = "domiciliu";
        var dataNasterii = DateOnly.Parse("10/10/2000");
        var mockRepo = new MockPersoanaRepository();
        var email = "email";


        await Assert.ThrowsAnyAsync<Exception>(async () =>
        await Persoana.Create(id, nume, prenume, domiciliu, dataNasterii, domiciliu, email, null, Role.Client, mockRepo));
    }

}
