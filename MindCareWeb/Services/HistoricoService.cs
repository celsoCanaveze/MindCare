using MindCareWeb.Models;
using MindCareWeb.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindCareWeb.Services
{
    public class HistoricoService : IHistoricoService
    {
        private readonly IUnitOfWork _uow;
        public HistoricoService(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<HistoricoMood>> GetAllAsync() => await _uow.Historicos.GetAllAsync();

        public async Task<HistoricoMood> CreateAsync(HistoricoMood h)
        {
            await _uow.Historicos.AddAsync(h);
            await _uow.SaveChangesAsync();
            return h;
        }
    }
}