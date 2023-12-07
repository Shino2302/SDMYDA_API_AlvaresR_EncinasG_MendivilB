using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Mascota
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMascota { get; set; }
        public string Nombre { get; set; }
        public string? Apodo { get; set; }
        public string Raza { get; set; }
        public DateTime Edad { get; set; }
        public int IdUsuario1 { get; set; }
        [ForeignKey("IdUsuario1")]
        public virtual Usuario Usuario { get; set; }

    }
}
