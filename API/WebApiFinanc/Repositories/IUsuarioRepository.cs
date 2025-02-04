using WebApiFinanc.Models;

namespace WebApiFinanc.Repositories
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuarios> GetUsuario();
        Usuarios GetUsers(int id);
        Usuarios Create(Usuarios usuarios);
        Usuarios Update(Usuarios usuarios);
        Usuarios Delete(int id);
        bool UserAny(Usuarios usuarios);
    }
}
