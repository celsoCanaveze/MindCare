using MindCareWeb.Models;
using MindCareWeb.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindCareWeb.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly IUnitOfWork _uow;
        public TarefaService(IUnitOfWork uow) => _uow = uow;

        public async Task<Tarefa?> GetByIdAsync(int id) => await _uow.Tarefas.GetByIdAsync(id);
        public async Task<IEnumerable<Tarefa>> GetAllAsync() => await _uow.Tarefas.GetAllAsync();
        public async Task<Tarefa> CreateAsync(Tarefa tarefa)
        {
            await _uow.Tarefas.AddAsync(tarefa);
            await _uow.SaveChangesAsync();
            return tarefa;
        }
    }
}
