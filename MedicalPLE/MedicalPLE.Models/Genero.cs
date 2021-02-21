// Independiente -- Genero
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MedicalPLE.Models.Enums;

namespace MedicalPLE.Models
{
    public class Genero
    {
        [Key]
       [Column("GeneroId")]
       public int GeneroId { get; set; }

        [Required(ErrorMessage = "El NombreGenero es obligatorio")]
        [Display(Name = "NombreGenero")]
        [StringLength(200)]
        public string NombreGenero { get; set; }

 // ...

    }



}

