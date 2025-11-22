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
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaService _service;
        public TarefasController(ITarefaService service) => _service = service;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var t = await _service.GetByIdAsync(id);
            if (t == null) return NotFound();
            return Ok(t);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TarefaCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var tarefa = new Tarefa { NomeTarefa = dto.NomeTarefa, Descricao = dto.Descricao, CriadorId = dto.CriadorId };
            var created = await _service.CreateAsync(tarefa);
            return CreatedAtAction(nameof(Get), new { id = created.Id, version = "1.0" }, created);
        }
    }
}
