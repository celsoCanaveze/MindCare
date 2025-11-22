using MindCareWeb.Models;
using System;
using System.Threading.Tasks;

namespace MindCareWeb.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Usuario> Usuarios { get; }
        IGenericRepository<Tarefa> Tarefas { get; }
        IGenericRepository<UsuarioTarefa> UsuarioTarefas { get; }
        IGenericRepository<HistoricoMood> Historicos { get; }

        Task<int> SaveChangesAsync();
    }
}
