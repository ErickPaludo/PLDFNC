using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Migrations;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories.UnitWork;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly ILogger<CreditoController> _logger;

        public CreditoController(IUnitOfWork unit, ILogger<CreditoController> logger)
        {
            _unit = unit;
            _logger = logger;
        }

        [HttpGet("/retornacreditos")]
        public ActionResult<IEnumerable<Credito>> RetornaCredito()
        {
            var credito = _unit.CreditoRepository.Get();
            if (credito.Count() == 0) { return NoContent(); }
            return Ok(credito);
        }

        [HttpGet("/selecionacredito/{id:int}", Name = "ObterCredito")]
        public ActionResult<IEnumerable<Credito>> RetornaCreditos(int id)
        {
            var credito = _unit.CreditoRepository.GetObjects(x => x.CreditoId == id);
            if (credito is null)
            {
                return NoContent();
            }

            return Ok(credito);
        }

        [HttpPost("/cadastracredito")]
        public IActionResult CadastraDebito([FromBody] Credito credito)
        {
            if (credito is null)
            {
                return BadRequest("Body is null");
            }
            _unit.CreditoRepository.Create(credito);
            _unit.Commit();
            return new CreatedAtRouteResult("ObterCredito", new { id = credito.CreditoId }, credito);
        }
        [HttpPatch("/altercredito")]
        public IActionResult AlterarDebito([FromBody] Credito credito)
        {
            if (credito is null)
            {
                return BadRequest("Body is null");
            }
            if (!_unit.CreditoRepository.ObjectAny(x => x.CreditoId == credito.CreditoId))
            {
                return NotFound();
            }

            _unit.CreditoRepository.Update(credito);
            _unit.Commit();
            return Ok(credito);
        }

        [HttpDelete("/deletecredito/{id:int}")]
        public IActionResult Deletar(int id)   
        {
            if (!_unit.CreditoRepository.ObjectAny(x => x.CreditoId == id))
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
