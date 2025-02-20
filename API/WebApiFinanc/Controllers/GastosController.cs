using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories.UnitWork;
using WebApiFinanc.Services;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly ILogger<GastosController> _logger;
        private readonly IGerenciaGastos _gerenciamento;
        public GastosController(IUnitOfWork unit, ILogger<GastosController> logger,IGerenciaGastos gerenciamento)
        {
            _unit = unit;
            _logger = logger;
            _gerenciamento = gerenciamento;
        }

        [HttpGet("/retornagastos")]
        public ActionResult<IEnumerable<Gastos>> RetornaCredito()
        {
            var gasto = _unit.GastosRepository.Get();
            if (gasto.Count() == 0) { return NoContent(); }
            return Ok(gasto);
        }

        [HttpGet("/selecionagasto/{id:int}", Name = "ObterGasto")]
        public ActionResult<IEnumerable<Gastos>> RetornaCreditos(int id)
        {
            var gasto = _unit.GastosRepository.GetObjects(x => x.Id == id);
            if (gasto is null)
            {
                return NoContent();
            }

            return Ok(gasto);
        }

        [HttpPost("/cadastragasto")]
        public ActionResult<IEnumerable<Gastos>> CadastraDebito([FromBody] Gastos gasto)
        {
            if (gasto is null)
            {
                return BadRequest("Body is null");
            }
            var obj = _gerenciamento.Registra(gasto);
            
            return new CreatedAtRouteResult("ObterGasto", new { id = gasto.Id }, gasto);
        }
        [HttpPatch("/alterargasto")]
        public IActionResult AlterarDebito([FromBody] Gastos gasto)
        {
            if (gasto is null)
            {
                return BadRequest("Body is null");
            }
            if (!_unit.GastosRepository.ObjectAny(x => x.Id == gasto.Id))
            {
                return NotFound();
            }

            _unit.GastosRepository.Update(gasto);
            _unit.Commit();
            return Ok(gasto);
        }

        [HttpDelete("/deletagasto/{id:int}")]
        public IActionResult Deletar(int id)
        {
            if (!_unit.GastosRepository.ObjectAny(x => x.Id == id))
            {
                return NotFound();
            }
            _unit.GastosRepository.Delete(x => x.Id == id);
            _unit.Commit();
            return Ok();
        }
    }
}
