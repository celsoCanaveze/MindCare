using Microsoft.EntityFrameworkCore;
using MindCareWeb.Data;
using MindCareWeb.Models;
using MindCareWeb.Repositories;
using MindCareWeb.Services;
using System.Threading.Tasks;
using Xunit;

public class UsuarioServiceTests
{
    private MindCareDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<MindCareDbContext>()
            .UseInMemoryDatabase(databaseName: "test_db")
            .Options;
        return new MindCareDbContext(options);
    }

    [Fact]
    public async Task CreateUsuario_Works()
    {
        using var ctx = CreateInMemoryContext();
        var uow = new UnitOfWork(ctx);
        var svc = new UsuarioService(uow);
        var usuario = new Usuario { Nome = "Teste", Email = "t@t.com", DataInscricao = System.DateTime.Now };
        var created = await svc.CreateAsync(usuario);
        Assert.True(created.Id >= 0);
    }
}
