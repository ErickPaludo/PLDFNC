using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories.UnitWork;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitoController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly ILogger<DebitoController> _logger;

        public DebitoController(IUnitOfWork unit, ILogger<DebitoController> logger)
        {
            _unit = unit;
            _logger = logger;
        }

        [HttpGet("/retornadebitos")]
        public ActionResult<IEnumerable<Debito>> RetornaDebito()
        {
            var debitos = _unit.DebitoRepository.Get();
            if (debitos.Count() == 0) { return NoContent(); }
            return Ok(debitos);
        }

        [HttpGet("/selecionadebito/{id:int}",Name = "ObterDebito")]
        public ActionResult<IEnumerable<Credito>> RetornaDebitos(int id)
        {
            var credito = _unit.CreditoRepository.GetObjects(x => x.CreditoId == id);
            if (credito is null)
            {
                return NoContent();
            }

            return Ok(credito);
        }

        [HttpPost("/cadastradebito")]
        public IActionResult CadastraDebito([FromBody] Debito debito)
        {
            if (debito is null)
            {
                return BadRequest("Body is null");
            }
            _unit.DebitoRepository.Create(debito);
            _unit.Commit();
            return new CreatedAtRouteResult("ObterDebito", new { id = debito.DebitoId }, debito);
        }
        [HttpPatch("/alterdebito")]
        public IActionResult AlterarDebito([FromBody] Debito debito)
        {
            if(debito is null)
            {
                return BadRequest("Body is null");
            }
            if (!_unit.DebitoRepository.ObjectAny(x => x.DebitoId == debito.DebitoId))
            {
                return NotFound();
            }

            _unit.DebitoRepository.Update(debito);
            _unit.Commit();
            return Ok(debito);
        }
    }
}
