// Independiente -- Tipodoc
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalPLE.Models
{
    public class Tipodoc
    {
        [Key]
        [Column("TipodocId")]
        public int TipodocId { get; set; }

        [Required(ErrorMessage = "El Tipo de Documento es obligatorio")]
        [Display(Name = "Tipo de Documento")]
        [StringLength(500)]
        public string NombreTipodoc { get; set; }
        // ...

    }
}

