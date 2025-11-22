using MindCareWeb.Models;
using MindCareWeb.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindCareWeb.Services
{
    public class UsuarioTarefaService : IUsuarioTarefaService
    {
        private readonly IUnitOfWork _uow;
        public UsuarioTarefaService(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<UsuarioTarefa>> GetAllAsync() => await _uow.UsuarioTarefas.GetAllAsync();

        public async Task<UsuarioTarefa> CreateAsync(UsuarioTarefa ut)
        {
            await _uow.UsuarioTarefas.AddAsync(ut);
            await _uow.SaveChangesAsync();
            return ut;
        }
    }
}