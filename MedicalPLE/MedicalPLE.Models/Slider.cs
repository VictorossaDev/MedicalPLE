using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicalPLE.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese un Titulo para el slider")]
        [Display(Name = "Titulo Slider")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Ingrese un Contenido para el slider")]
        [Display(Name = "Contenido Slider")]
        public string Contenido { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
    }
}