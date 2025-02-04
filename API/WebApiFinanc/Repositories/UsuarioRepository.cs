using Microsoft.EntityFrameworkCore;
using WebApiFinanc.Context;
using WebApiFinanc.Models;

namespace WebApiFinanc.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }
        public Usuarios GetUsers(int id)
        {
            return _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.UserId == id);
        }

        public IEnumerable<Usuarios> GetUsuario()
        {
            return _context.Usuarios.ToList();
        }
        public Usuarios Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Usuarios Update(Usuarios usuarios)
        {
            throw new NotImplementedException();
        }

        public Usuarios Create(Usuarios usuarios)
        {
             _context.AddAsync(usuarios);
             _context.SaveChangesAsync();
            return usuarios;
        }

        public bool UserAny(Usuarios usuarios)
        {
            return _context.Usuarios.AsNoTracking().Any(x => x.UserName == usuarios.UserName || x.Email == usuarios.Email);
        }
    }
}
