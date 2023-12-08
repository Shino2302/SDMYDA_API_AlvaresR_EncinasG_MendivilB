namespace SDMYDA_API_AlvaresR_EncinasG_MendivilB.Excepciones
{
    public class ExcepcionesNombresDeUsuario : Exception
    {
        public string NombreUsuario { get; set; }
        public ExcepcionesNombresDeUsuario()
        {
            
        }
        public ExcepcionesNombresDeUsuario(string mensaje) : base(mensaje)
        {
            
        }
        public ExcepcionesNombresDeUsuario(string mensaje, Exception inner) : base(mensaje,inner)
        {

        }
        public ExcepcionesNombresDeUsuario( string mensaje, string nombreDelUsuario) : this(mensaje)
        {
            NombreUsuario = nombreDelUsuario;
        }
    }
}
