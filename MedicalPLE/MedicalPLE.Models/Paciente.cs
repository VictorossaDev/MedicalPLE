// Dependiente -- Paciente
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalPLE.Models
{
    public class Paciente
    {
        [Key]
       [Column("PacienteId")]
       public int PacienteId { get; set; }

        [Required(ErrorMessage = "El TipodocId es obligatorio")]
        [Display(Name = "TipodocId")]
        public int TipodocId { get; set; }

        [Required(ErrorMessage = "El NumeroDoc es obligatorio")]
        [Display(Name = "NumeroDoc")]
        [Column(TypeName = "numeric(18, 0)")]
        public int NumeroDoc { get; set; }

        [Required(ErrorMessage = "El NombreApellido es obligatorio")]
        [Display(Name = "NombreApellido")]
        [StringLength(400)]
        public string NombreApellido { get; set; }

        [Required(ErrorMessage = "El TiposangreId es obligatorio")]
        [Display(Name = "TiposangreId")]
        public int TiposangreId { get; set; }

        [Required(ErrorMessage = "El EstadocivilId es obligatorio")]
        [Display(Name = "EstadocivilId")]
        public int EstadocivilId { get; set; }

        [Required(ErrorMessage = "El Edad es obligatorio")]
        [Display(Name = "Edad")]
        [Column("Datanumeric_18_0", TypeName = "numeric(18, 0)")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El CiudadId es obligatorio")]
        [Display(Name = "CiudadId")]
        public int CiudadId { get; set; }

        [Required(ErrorMessage = "El Nacionalidad es obligatorio")]
        [Display(Name = "Nacionalidad")]
        [StringLength(300)]
        public string Nacionalidad { get; set; }

        [Required(ErrorMessage = "El GeneroId es obligatorio")]
        [Display(Name = "GeneroId")]
        public int GeneroId { get; set; }

         [ForeignKey("TipodocId")]
        public Tipodoc Tipodoc { get; set; }

        [ForeignKey("TiposangreId")]
        public Tiposangre Tiposangre { get; set; }

        [ForeignKey("EstadocivilId")]
        public Estadocivil Estadocivil { get; set; }

        [ForeignKey("GeneroId")]
        public Genero Genero { get; set; }

        [ForeignKey("CiudadId")]
        public Ciudad Ciudad { get; set; }


   }
}

