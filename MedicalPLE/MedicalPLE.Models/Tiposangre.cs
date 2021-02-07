// Independiente -- Tiposangre
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalPLE.Models
{
    public class Tiposangre
    {
        [Key]
       [Column("TiposangreId")]
       public int TiposangreId { get; set; }

        [Required(ErrorMessage = "El NombreTiposangre es obligatorio")]
        [Display(Name = "NombreTiposangre")]
        [StringLength(100)]
        public string NombreTiposangre { get; set; }

 // ...

    }
}

