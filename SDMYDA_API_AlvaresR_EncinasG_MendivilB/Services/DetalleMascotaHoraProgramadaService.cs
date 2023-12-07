using DB;
using Microsoft.EntityFrameworkCore;

namespace SDMYDA_API_AlvaresR_EncinasG_MendivilB.Services
{
    public class DetalleMascotaHoraProgramadaService
    {
        private SDMYDAContext _context;

        public DetalleMascotaHoraProgramadaService(SDMYDAContext context)
        {
            _context = context;
        }

        public void CrearDetalleMascotaHoraProgramada(int idMascota, int nuevaHoraProgramada)
        {
        var detalle = new Detalle_Mascota_HoraProgramada
        {
            IdMascota1 = idMascota,
            IdHP1 = nuevaHoraProgramada
        };
            _context.Detalles.Add(detalle);
        }
        public void EliminarDetalle(int idHoraProgramada)
        {
            var detalle = _context.Detalles.FirstOrDefault(n => n.IdHP1 == idHoraProgramada);

            if(detalle != null)
            {
                _context.Detalles.Remove(detalle);
                _context.SaveChanges();
            }
        }
    }
}
