using MindCareWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindCareWeb.Services
{
    public interface IHistoricoService
    {
        Task<IEnumerable<HistoricoMood>> GetAllAsync();
        Task<HistoricoMood> CreateAsync(HistoricoMood h);
    }
}