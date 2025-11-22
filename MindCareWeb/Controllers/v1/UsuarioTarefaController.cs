using Microsoft.AspNetCore.Mvc;
using MindCareWeb.DTOs;
using MindCareWeb.Models;
using MindCareWeb.Services;
using System.Threading.Tasks;

namespace MindCareWeb.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuarioTarefaController : ControllerBase
    {
        private readonly IUsuarioTarefaService _service;
        public UsuarioTarefaController(IUsuarioTarefaService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioTarefaCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var ut = new UsuarioTarefa { UsuarioId = dto.UsuarioId, TarefaId = dto.TarefaId, Conquista = dto.Conquista ?? "0", ProgressoPercentual = dto.ProgressoPercentual };
            var created = await _service.CreateAsync(ut);
            return CreatedAtAction(nameof(Create), new { id = created.Id, version = "1.0" }, created);
        }
    }
}
