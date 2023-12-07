using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Detalle_Mascota_HoraProgramada
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalle { get; set; }
        public int IdMascota1 { get; set; }
        public int IdHP1 { get; set; }
        [ForeignKey("IdMascota1")]
        public virtual Mascota Mascota { get; set; }
        [ForeignKey("IdHP1")]
        public virtual HoraProgramada HoraProgramada { get; set; } 
    }
}
