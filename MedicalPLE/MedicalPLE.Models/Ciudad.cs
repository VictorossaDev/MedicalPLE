// Dependiente -- Ciudad
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalPLE.Models
{
    public class Ciudad
    {
        [Key]
       [Column("CiudadId")]
       public int CiudadId { get; set; }

        [Required(ErrorMessage = "El NombreCiudad es obligatorio")]
        [Display(Name = "NombreCiudad")]
        [StringLength(300)]
        public string NombreCiudad { get; set; }

        [Required(ErrorMessage = "El DepartamentoId es obligatorio")]
        [Display(Name = "DepartamentoId")]
        public int DepartamentoId { get; set; }

         [ForeignKey("DepartamentoId")]
        public Departamento Departamento { get; set; }


   }
}

