// Independiente -- Eps
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MedicalPLE.Models.Enums;

namespace MedicalPLE.Models
{
    public class Eps
    {
        [Key]
       [Column("EpsId")]
       public int EpsId { get; set; }

        [Required(ErrorMessage = "El NombreEps es obligatorio")]
        [Display(Name = "NombreEps")]
        [StringLength(300)]
        public string NombreEps { get; set; }

 // ...

    }



}

