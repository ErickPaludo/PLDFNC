using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.DTOs.Debito;
using WebApiFinanc.Repositories.UnitWork;
using WebApiFinanc.Services;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitoController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IGerenciaGastos _gerenciamento;
        private readonly IMapper _mapper;

     
        [HttpGet("/debito/retorno")]
        public ActionResult<IEnumerable<Debito>> RetornaDebito()
        {
            var gasto = _unit.DebitoRepository.Get();
            return Ok(gasto);
        }

        [HttpGet("/debito/retornafiltrado/{id:int}", Name = "ObterDebito")]
        public ActionResult<IEnumerable<Debito>> RetornaDebitos(int id)
        {
            var gasto = _unit.DebitoRepository.GetObjects(x => x.Id == id);
            if (gasto is null)
            {
                return NoContent();
            }

            return Ok(gasto);
        }
  
        [HttpPost("/debito/cadastro")]
        public ActionResult<IEnumerable<Debito>> CadastraDebito([FromBody] Debito debito)
        {
            if (debito is null)
            {
                return BadRequest("Body is null");
            }
            var obj = _gerenciamento.RegistraDebito(debito);

            return new CreatedAtRouteResult("ObterDebito", new { id = debito.Id }, debito);
        }

        [HttpDelete("/debito/deleta/{id:int}")]
        public IActionResult Deletar(int id)
        {
            if (!_unit.DebitoRepository.ObjectAny(x => x.Id == id))
            {
                return NotFound();
            }
            _gerenciamento.Excluir(id, "D");
            _unit.Commit();
            return Ok();
        }

        //Fazer update
    }
}
