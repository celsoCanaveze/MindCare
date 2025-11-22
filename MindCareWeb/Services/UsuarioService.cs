using Microsoft.EntityFrameworkCore;
using MindCareWeb.Data;
using MindCareWeb.Models;
using MindCareWeb.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MindCareWeb.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uow;
        public UsuarioService(IUnitOfWork uow) => _uow = uow;

        public async Task<Usuario?> GetByIdAsync(int id) =>
            await _uow.Usuarios.GetByIdAsync(id);

        public async Task<IEnumerable<Usuario>> GetAllAsync() =>
            await _uow.Usuarios.GetAllAsync();

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            await _uow.Usuarios.AddAsync(usuario);
            await _uow.SaveChangesAsync();
            return usuario;
        }
    }
}
