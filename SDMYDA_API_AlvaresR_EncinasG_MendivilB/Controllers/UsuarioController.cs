using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDMYDA_API_AlvaresR_EncinasG_MendivilB.Services;
using SDMYDA_API_AlvaresR_EncinasG_MendivilB.ViewModel;

namespace SDMYDA_API_AlvaresR_EncinasG_MendivilB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioService _userService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _userService = usuarioService;
        }

        [HttpGet("listar-usuarios")]
        public IActionResult ListarUsuarios()
        {
            var allUsers = _userService.ListarUsuarios();
            return Ok(allUsers);
        }

        [HttpPost("agregar-usuario")]
        public IActionResult AgregarUsuario(UsuarioVM nuevoUsuario)
        {
            _userService.AgregarUsuario(nuevoUsuario);
            return Ok();
        }

        [HttpPut("editar-usuario")]
        public IActionResult EditaUsuario(int idUsuario, [FromBody]UsuarioVM userUpdate)
        {
            _userService.UpdateUser(idUsuario,userUpdate);
            return Ok($"Usuario {userUpdate} actualizado");
        }
        /*
        [HttpGet("lista-mascotas/{userId}/mascotas}")]
        public IActionResult ListarMascotasDeUsuario(int userId)
        {
            var mascotas = _userService.ListaDeMascotasPorUsuario(userId);

            if(mascotas == null)
            {
                return NotFound("No cuenta con mascotas registradas");
            }

            return Ok(mascotas);
        }
        */
        [HttpDelete("eliminar-usuario")]
        public IActionResult EliminarUsuario(int userId) 
        {
            _userService.EliminarUsuario(userId);
            return Ok("Usuario Eliminado");
        }
    }
}
