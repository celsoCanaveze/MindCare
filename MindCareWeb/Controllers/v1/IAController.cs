using Microsoft.AspNetCore.Mvc;
using MindCareWeb.Services;
using System.Threading.Tasks;

namespace MindCareWeb.Controllers.V1
{
    [Route("v1/[controller]")]
    public class IAController : Controller
    {
        private readonly IAService _iaService;

        public IAController(IAService iaService)
        {
            _iaService = iaService;
        }

        [HttpGet("Mensagem/{id}")]
        public async Task<IActionResult> Mensagem(int id)
        {
            string msg = await _iaService.ObterMensagemIA(id);
            ViewBag.Mensagem = msg;
            ViewBag.IdUsuario = id;

            return View();
        }
    }
}
