// Independiente -- TratamientosEsteticos
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MedicalPLE.Models.Enums;

namespace MedicalPLE.Models
{
    public class TratamientosEsteticos
    {
        [Key]
       [Column("TratamientoEsteticoId")]
       public int TratamientoEsteticoId { get; set; }

        [Required(ErrorMessage = "El NombreTratamientoEstetico es obligatorio")]
        [Display(Name = "NombreTratamientoEstetico")]
        [StringLength(400)]
        public string NombreTratamientoEstetico { get; set; }

        [Required(ErrorMessage = "El ObservacionesTratamiento es obligatorio")]
        [Display(Name = "ObservacionesTratamiento")]
        public string ObservacionesTratamiento { get; set; }

 // ...

    }



}

