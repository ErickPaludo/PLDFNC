using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiFinanc.Context;
using WebApiFinanc.Models;

namespace WebApiFinanc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/retornausers")]
        public async Task<ActionResult<IEnumerable<Usuarios>>> RetornaUsers()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        [HttpGet("/selecionauser/{id:int}")]
        public async Task<ActionResult<IEnumerable<Usuarios>>> SelecionaUsers(int id)
        {
            var user = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == id);
            if (user is not null)
            {
                return Ok(user);
            }
            else { return NotFound(); }
          
        }

        [HttpPost("cadastrauser")]
        public async Task<IActionResult> CadastraUser([FromBody] Usuarios usuarios)
        {
            await _context.AddAsync(usuarios);
            await _context.SaveChangesAsync();
            return Ok(usuarios);
        }
    }
}
