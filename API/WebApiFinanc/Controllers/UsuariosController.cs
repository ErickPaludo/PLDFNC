using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFinanc.Context;
using WebApiFinanc.Models;
using WebApiFinanc.Repositories;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/retornausers")]
        public ActionResult<IEnumerable<Usuarios>> RetornaUsers()
        {
            return Ok(_repository.GetUsuario());
        }

        [HttpGet("/selecionauser/{id:int}")]
        public ActionResult<IEnumerable<Usuarios>> SelecionaUsers(int id)
        {
            var user = _repository.GetUsers(id);
            if (user is not null)
            {
                return Ok(user);
            }
            else { return NotFound(); }
        }

        [HttpPost("cadastrauser")]
        public IActionResult CadastraUser([FromBody] Usuarios usuarios)
        {
            if (_repository.UserAny(usuarios))
            {
                return Conflict("Usuário já cadastrado");
            }
           _repository.Create(usuarios);
            return Ok(usuarios);
        }
    }
}
