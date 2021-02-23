// Dependiente -- ImagenesSesion
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalPLE.Models
{
    public class ImagenesSesion
    {
        [Key]
       [Column("ImagenesSesionId")]
       public int ImagenesSesionId { get; set; }

        [Required(ErrorMessage = "El DescripcionImagen es obligatorio")]
        [Display(Name = "DescripcionImagen")]
        public string DescripcionImagen { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "El SesionTratamientoEsteticoId es obligatorio")]
        [Display(Name = "SesionTratamientoEsteticoId")]
        public int SesionTratamientoEsteticoId { get; set; }

         [ForeignKey("SesionTratamientoEsteticoId")]
        public SesionTratamientoEstetico SesionTratamientoEstetico { get; set; }


   }




}

