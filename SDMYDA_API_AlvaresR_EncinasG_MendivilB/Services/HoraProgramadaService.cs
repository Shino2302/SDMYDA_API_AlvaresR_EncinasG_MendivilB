using DB;
using Microsoft.EntityFrameworkCore;

namespace SDMYDA_API_AlvaresR_EncinasG_MendivilB.Services
{
    public class HoraProgramadaService
    {
        private SDMYDAContext _context;

        public DetalleMascotaHoraProgramadaService detalleMascotaHoraProgramada;
        public HoraProgramadaService(SDMYDAContext context)
        {
            detalleMascotaHoraProgramada = new DetalleMascotaHoraProgramadaService(context);
            _context = context;
        }

        public async Task<int> CrearHoraProgramada(HoraProgramada nuevaHoraProgramada)
        {
            _context.HorasProgramadas.Add(nuevaHoraProgramada);
            await _context.SaveChangesAsync();
            return nuevaHoraProgramada.IdHP;
        }

        public void EliminarHoraProgramada(int idHora)
        {
            var horaProgramada = _context.HorasProgramadas.FirstOrDefault(n => n.IdHP == idHora);

            if(horaProgramada != null)
            {
                detalleMascotaHoraProgramada.EliminarDetalle(idHora);
                _context.HorasProgramadas.Remove(horaProgramada);
                _context.SaveChanges();
            }
        }
        public HoraProgramada ActualizarHora(int idHora, HoraProgramada hora)
        {
            var horaProgramada = _context.HorasProgramadas.FirstOrDefault(n => n.IdHP == idHora);

            if(horaProgramada != null) 
            {
                horaProgramada.HoraP = hora.HoraP;
                horaProgramada.TodaLaSemana = hora.TodaLaSemana;
                _context.SaveChanges();
            }
            return horaProgramada;
        }
    }
}
