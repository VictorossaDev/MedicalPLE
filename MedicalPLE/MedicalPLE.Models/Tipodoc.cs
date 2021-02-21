// Independiente -- Tipodoc
using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MedicalPLE.Models.Enums;

namespace MedicalPLE.Models
{
    public class Tipodoc
    {
        [Key]
       [Column("TipodocId")]
       public int TipodocId { get; set; }

        [Required(ErrorMessage = "El NombreTipodoc es obligatorio")]
        [Display(Name = "NombreTipodoc")]
        [StringLength(200)]
        public string NombreTipodoc { get; set; }

 // ...

    }



}

