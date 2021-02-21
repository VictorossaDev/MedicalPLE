// Independiente -- EstadoCivil
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MedicalPLE.Models.Enums;

namespace MedicalPLE.Models
{
    public class EstadoCivil
    {
        [Key]
       [Column("EstadoCivilId")]
       public int EstadoCivilId { get; set; }

        [Required(ErrorMessage = "El NombreEstadoCivil es obligatorio")]
        [Display(Name = "NombreEstadoCivil")]
        [StringLength(100)]
        public string NombreEstadoCivil { get; set; }

 // ...

    }



}

