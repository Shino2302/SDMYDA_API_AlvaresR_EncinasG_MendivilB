using DB;
using Microsoft.EntityFrameworkCore;
using SDMYDA_API_AlvaresR_EncinasG_MendivilB.ViewModel;

namespace SDMYDA_API_AlvaresR_EncinasG_MendivilB.Services
{
    public class UsuarioService
    {
        private SDMYDAContext _context;

        public UsuarioService(SDMYDAContext context)
        {
            _context = context;
        }

        public void AgregarUsuario(UsuarioVM nuevoUsuario)
        {
            var _usuario = new Usuario
            {
                Nombre = nuevoUsuario.Nombre,
                Apellido = nuevoUsuario.Apellido,
                Telefono = nuevoUsuario.Telefono,
                Email = nuevoUsuario.Email
            };

            _context.Usuarios.Add(_usuario);
            _context.SaveChanges();
        }

        public List<Usuario> ListarUsuarios() => _context.Usuarios.ToList();

        public Usuario UpdateUser(int userId, UsuarioVM user)
        {
            var usuario = _context.Usuarios.FirstOrDefault(n => n.IdUsuario == userId);
            if (usuario != null) 
            {
                usuario.Nombre = user.Nombre;
                usuario.Apellido = user.Apellido;
                usuario.Telefono = user.Telefono;
                usuario.Email = user.Email;
                _context.SaveChanges();
            }
            return usuario;
        }

        public async Task<List<Mascota>> ListaDeMascotasPorUsuario(int userId)
        {
            var mascotas = await _context.Mascotas
                .Where(m => m.IdUsuario1 == userId)
                .ToListAsync();

            return mascotas;
        }

        public void EliminarUsuario(int userId)
        {
            var _usuario = _context.Usuarios.FirstOrDefault(n => n.IdUsuario == userId);
            if(_usuario != null)
            {
                _context.Usuarios.Remove(_usuario);
                _context.SaveChanges();
            }
        }

    }
}
