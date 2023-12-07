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
                Email = nuevoUsuario.Email,
                Password = nuevoUsuario.Password
            };

            _context.Usuarios.Add(_usuario);
            _context.SaveChanges();
        }

        public List<Usuario> ListarUsuarios() => _context.Usuarios.ToList();

        public Usuario UpdateUser(int userId, UsuarioSinPasswordVM user)
        {
            var usuario = _context.Usuarios.FirstOrDefault(n => n.IdUsuario == userId);
            if (usuario != null) 
            {
                usuario.Nombre = user.Nombre;
                usuario.Apellido = user.Apellido;
                usuario.Telefono = user.Telefono;
                usuario.Email = user.Email;
                usuario.Password = usuario.Password;
                _context.SaveChanges();
            }
            return usuario;
        }

        //public async Task<List<Mascota>> ListaDeMascotasPorUsuario(int userId)
        //{
        //    var mascotas = await _context.Mascotas
        //        .Where(m => m.IdUsuario1 == userId)
        //        .ToListAsync();

        //    return mascotas;
        //}

        public UsuarioConMascotasVM ListaDeMascotasPorUsuario(int idUsuario)
        {
            var mascotas = _context.Mascotas.Where(n => n.IdUsuario1 == idUsuario).ToList();
            var _usuario = _context.Usuarios.Where(n => n.IdUsuario == idUsuario).Select(
                n => new UsuarioConMascotasVM
                {
                    IdUsuario = idUsuario,
                    Nombre = n.Nombre,
                    Apellido = n.Apellido,
                    Telefono = n.Telefono,
                    Email = n.Email,
                    Mascotas = mascotas
                }).FirstOrDefault();
            return _usuario;
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
