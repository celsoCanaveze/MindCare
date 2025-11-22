using MindCareWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindCareWeb.Services
{
    public interface IUsuarioTarefaService
    {
        Task<IEnumerable<UsuarioTarefa>> GetAllAsync();
        Task<UsuarioTarefa> CreateAsync(UsuarioTarefa ut);
    }
}