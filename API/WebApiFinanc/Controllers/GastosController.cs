using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories.UnitWork;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly ILogger<GastosController> _logger;

        public GastosController(IUnitOfWork unit, ILogger<GastosController> logger)
        {
            _unit = unit;
            _logger = logger;
        }

        [HttpGet("/retornogastos")]
        public ActionResult<IEnumerable<Gastos>> RetornaCredito()
        {
            var credito = _unit.GastosRepository.Get();
            if (credito.Count() == 0) { return NoContent(); }
            return Ok(credito);
        }

        [HttpGet("/selecionagasto/{id:int}", Name = "ObterGasto")]
        public ActionResult<IEnumerable<Gastos>> RetornaCreditos(int id)
        {
            var credito = _unit.GastosRepository.GetObjects(x => x.Id == id);
            if (credito is null)
            {
                return NoContent();
            }

            return Ok(credito);
        }
    }
}
