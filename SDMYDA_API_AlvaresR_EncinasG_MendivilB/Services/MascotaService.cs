using DB;
using Microsoft.EntityFrameworkCore;
using SDMYDA_API_AlvaresR_EncinasG_MendivilB.ViewModel;

namespace SDMYDA_API_AlvaresR_EncinasG_MendivilB.Services
{
    public class MascotaService
    {
        private static SDMYDAContext _context;

        public MascotaService(SDMYDAContext context)
        {
            _context = context;
        }

        public void AgregarMascota(MascotaViewModel nuevaMascota)
        {
            var _mascota = new Mascota
            {
                Nombre = nuevaMascota.Nombre,
                Apodo = nuevaMascota.Apodo,
                Edad = nuevaMascota.Edad,
                Raza = nuevaMascota.Raza,
                IdUsuario1 = nuevaMascota.IdUsuario1
            };

            _context.Mascotas.Add(_mascota);
            _context.SaveChanges();
        }

        public Mascota ActualizarMascota(int idMascota, Mascota mascota)
        {
            var _mascota = _context.Mascotas.FirstOrDefault(n => n.IdMascota == idMascota);

            if (_mascota != null)
            {
                _mascota.Nombre = mascota.Nombre;
                _mascota.Apodo = mascota.Apodo;
                _mascota.Raza = mascota.Raza;
                _mascota.Edad = mascota.Edad;
                _context.SaveChanges();
            }
            return _mascota;
        }
        public void EliminarMascota (int idMascota)
        {
            var _mascota = _context.Mascotas.FirstOrDefault(n => n.IdMascota == idMascota);
            if (_mascota != null)
            {
                _context.Mascotas.Remove(_mascota);
                _context.SaveChanges();
            }
        }
        public async Task<List<HoraProgramada>> ObtenerComidasProgramadasDeMascota(int idMascota)
        {
            var comidasProgramadas = await _context.Detalles
                .Where(detalle => detalle.IdMascota1 == idMascota)
                .Select(detalle => detalle.HoraProgramada)
                .ToListAsync();

            return comidasProgramadas;
        }
    }
}
