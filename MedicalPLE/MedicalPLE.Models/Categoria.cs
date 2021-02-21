using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalPLE.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingresa un nombre para la categoría")]
        [Display(Name ="Nombre Categoría")]
        public string Nombre { get; set; }

    }
}
