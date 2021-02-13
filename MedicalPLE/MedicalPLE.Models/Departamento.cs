// Independiente -- Departamento
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalPLE.Models
{
    public class Departamento
    {
        [Key]
       [Column("DepartamentoId")]
       public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "El NombreDepartamento es obligatorio")]
        [Display(Name = "NombreDepartamento")]
        [StringLength(300)]
        public string NombreDepartamento { get; set; }

 // ...

    }
}

