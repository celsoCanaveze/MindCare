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
    public class HistoricoController : ControllerBase
    {
        private readonly IHistoricoService _service;
        public HistoricoController(IHistoricoService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HistoricoCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var h = new HistoricoMood { UsuarioId = dto.UsuarioId, Humor = dto.Humor, Observacao = dto.Observacao };
            var created = await _service.CreateAsync(h);
            return CreatedAtAction(nameof(Create), new { id = created.Id, version = "1.0" }, created);
        }
    }
}
