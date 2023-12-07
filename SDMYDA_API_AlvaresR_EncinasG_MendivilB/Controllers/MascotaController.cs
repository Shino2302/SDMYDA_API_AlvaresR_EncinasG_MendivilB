using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDMYDA_API_AlvaresR_EncinasG_MendivilB.Services;

namespace SDMYDA_API_AlvaresR_EncinasG_MendivilB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        public MascotaService _mascotaService;
        public DetalleMascotaHoraProgramadaService _detalleService;
        public HoraProgramadaService _programadaService;

        public MascotaController(MascotaService usuarioService,
               DetalleMascotaHoraProgramadaService detalleService,
               HoraProgramadaService horaProgramadaService)
        {
            _mascotaService = usuarioService;
            _detalleService = detalleService;
            _programadaService = horaProgramadaService;
        }

        [HttpPost("agregar-mascota")]
        public IActionResult AgregarMascota(Mascota nuevaMascota)
        {
            _mascotaService.AgregarMascota(nuevaMascota);
            return Ok($"mascota: {nuevaMascota.Nombre} agregada");
        }

        [HttpPut("editar-mascota")]
        public IActionResult EditarMascota(int idMascota ,[FromBody]Mascota mascotaActualizada)
        {
            _mascotaService.ActualizarMascota(idMascota, mascotaActualizada);
            return Ok($"mascota: {mascotaActualizada.Nombre} actualizada");
        }


        [HttpDelete("eliminar-mascota-por-id")]
        public IActionResult EliminarMascotaPorId(int idMascota)
        {
            _mascotaService.EliminarMascota(idMascota);
            return Ok("Mascota Eliminada");
        }
        /*
        [HttpGet("{idMascota}/comidas")]
        public IActionResult ObtenerComidasProgramadasDeMascota(int idMascota)
        {
            var comidasProgramadas = _mascotaService.ObtenerComidasProgramadasDeMascota(idMascota);

            if (comidasProgramadas == null)
            {
                return NotFound($"No se encontraron comidas programadas para la mascota con ID {idMascota}");
            }

            return Ok(comidasProgramadas);
        }*/
        /*
        [HttpPost("{idMascota}/agregar-hora-programada")]
        public async Task<ActionResult> AgregarHoraProgramada(int idMascota, HoraProgramada nuevaHoraProgramada)
        {
            // Primero, crea la hora programada
            int idNuevaHoraProgramada =  await _programadaService.CrearHoraProgramada(nuevaHoraProgramada);

            // Luego, crea el detalle asociando la mascota con la nueva hora programada
            _detalleService.CrearDetalleMascotaHoraProgramada(idMascota, idNuevaHoraProgramada);

            return Ok();
        }*/
    }
}
