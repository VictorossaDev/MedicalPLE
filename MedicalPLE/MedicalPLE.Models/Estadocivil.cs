// Independiente -- Estadocivil
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalPLE.Models
{
    public class Estadocivil
    {
        [Key]
       [Column("EstadocivilId")]
       public int EstadocivilId { get; set; }

        [Required(ErrorMessage = "El NombreEstadocivil es obligatorio")]
        [Display(Name = "NombreEstadocivil")]
        [StringLength(300)]
        public string NombreEstadocivil { get; set; }

 // ...

    }
}

