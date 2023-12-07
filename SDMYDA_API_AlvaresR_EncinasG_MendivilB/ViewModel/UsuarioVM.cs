using DB;

namespace SDMYDA_API_AlvaresR_EncinasG_MendivilB.ViewModel
{
    public class UsuarioVM
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioSinPasswordVM
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }

    public class UsuarioConMascotasVM
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<Mascota> Mascotas { get; set; }
    }
}
