using DB;

namespace SDMYDA_API_AlvaresR_EncinasG_MendivilB.ViewModel
{
    public class MascotaViewModel
    {
        public string Nombre { get; set; }
        public string? Apodo { get; set; }
        public string Raza { get; set; }
        public DateTime Edad { get; set; }
        public List<int> Usuario { get; set; }
    }
    public class MascotasConHDCViewModel
    {
        public string Nombre { get; set; }
        public string? Apodo { get; set; }
        public string Raza { get; set; }
        public DateTime Edad { get; set; }
        public List<HoraProgramada> Horas { get; set; } 
    }
}
