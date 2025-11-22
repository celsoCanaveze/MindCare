using MindCareWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindCareWeb.Services
{
    public interface ITarefaService
    {
        Task<Tarefa?> GetByIdAsync(int id);
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<Tarefa> CreateAsync(Tarefa tarefa);
    }
}
