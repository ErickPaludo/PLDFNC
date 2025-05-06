using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.TemporarioFSG;
using WebApiFinanc.Repositories.UnitWork;
using WebApiFinanc.Services;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancCreditoController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IGerenciaGastos _gerenciamento;
        private readonly IMapper _mapper;

        public FinancCreditoController(IUnitOfWork unit, ILogger<CreditoController> logger, IGerenciaGastos gerenciamento, IMapper mapper)
        {
            _unit = unit;
            _gerenciamento = gerenciamento;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost("cadastro")]
        public ActionResult<IEnumerable<CreditoFSG>> CadastraCredito([FromBody] CreditoFSG credito)
        {
            //_gerenciamento.RegistraCredito(credito);
            //return CreatedAtAction(nameof(CadastraCredito), new { id = credito.Id }, credito);
            return Ok();
        }
    }
}
