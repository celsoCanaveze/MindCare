using Microsoft.AspNetCore.Mvc;
using MindCareWeb.Models;
using MindCareWeb.Services;

namespace MindCareWeb.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        // GET v1/usuarios
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _service.GetAllAsync();
            return Ok(usuarios);
        }

        // GET v1/usuarios/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        // POST v1/usuarios
        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            var novo = await _service.CreateAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = novo.Id }, novo);
        }
    }
}
