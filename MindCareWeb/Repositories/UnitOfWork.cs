using MindCareWeb.Data;
using MindCareWeb.Models;
using System.Threading.Tasks;

namespace MindCareWeb.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MindCareDbContext _ctx;
        public IGenericRepository<Usuario> Usuarios { get; }
        public IGenericRepository<Tarefa> Tarefas { get; }
        public IGenericRepository<UsuarioTarefa> UsuarioTarefas { get; }
        public IGenericRepository<HistoricoMood> Historicos { get; }

        public UnitOfWork(MindCareDbContext ctx)
        {
            _ctx = ctx;
            Usuarios = new GenericRepository<Usuario>(_ctx);
            Tarefas = new GenericRepository<Tarefa>(_ctx);
            UsuarioTarefas = new GenericRepository<UsuarioTarefa>(_ctx);
            Historicos = new GenericRepository<HistoricoMood>(_ctx);
        }

        public async Task<int> SaveChangesAsync() => await _ctx.SaveChangesAsync();

        public void Dispose() => _ctx.Dispose();
    }
}
