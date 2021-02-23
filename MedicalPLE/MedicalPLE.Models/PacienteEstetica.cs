// Dependiente -- PacienteEstetica
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalPLE.Models
{
    public class PacienteEstetica
    {
        [Key]
       [Column("PacienteEsteticaId")]
       public int PacienteEsteticaId { get; set; }

        [Required(ErrorMessage = "El TipodocId es obligatorio")]
        [Display(Name = "TipodocId")]
        public int TipodocId { get; set; }

        [Required(ErrorMessage = "El No. Documento es obligatorio")]
        [Display(Name = "NumeroDocumento")]
        [Column(TypeName = "int")]
        public int NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El NombreApellido es obligatorio")]
        [Display(Name = "NombreApellido")]
        [StringLength(400)]
        public string NombreApellido { get; set; }

        [Required(ErrorMessage = "El Edad Paciente es obligatorio")]
        [Display(Name = "Edad")]
        [Column(TypeName = "int")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El GeneroId es obligatorio")]
        [Display(Name = "GeneroId")]
        public int GeneroId { get; set; }

         [ForeignKey("TipodocId")]
        public Tipodoc Tipodoc { get; set; }

        [ForeignKey("GeneroId")]
        public Genero Genero { get; set; }


   }




}

