// Independiente -- TipoSangre
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MedicalPLE.Models.Enums;

namespace MedicalPLE.Models
{
    public class TipoSangre
    {
        [Key]
       [Column("TipoSangreId")]
       public int TipoSangreId { get; set; }

        [Required(ErrorMessage = "El NombreTipoSangre es obligatorio")]
        [Display(Name = "NombreTipoSangre")]
        [StringLength(100)]
        public string NombreTipoSangre { get; set; }

 // ...

    }



}

