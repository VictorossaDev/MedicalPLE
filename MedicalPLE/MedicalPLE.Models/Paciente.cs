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

        [Required(ErrorMessage = "El NumeroDocumento es obligatorio")]
        [Display(Name = "NumeroDocumento")]
        [StringLength(200)]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El NombresApellidos es obligatorio")]
        [Display(Name = "NombresApellidos")]
        [StringLength(500)]
        public string NombresApellidos { get; set; }
        [Required(ErrorMessage = "El TiposangreId es obligatorio")]
        [Display(Name = "TiposangreId")]
        public int TiposangreId { get; set; }

        [Required(ErrorMessage = "El EstadocivilId es obligatorio")]
        [Display(Name = "EstadocivilId")]
        public int EstadocivilId { get; set; }

        [Display(Name = "Fechanacimiento")]
        public DateTime? Fechanacimiento { get; set; }

        [Required(ErrorMessage = "El Edad es obligatorio")]
        [Display(Name = "Edad")]
        [Column("Datanumeric_18_0", TypeName = "numeric(18, 0)")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El Lugarnacimiento es obligatorio")]
        [Display(Name = "Lugarnacimiento")]
        [StringLength(500)]
        public string Lugarnacimiento { get; set; }
        [Required(ErrorMessage = "El Nacionalidad es obligatorio")]
        [Display(Name = "Nacionalidad")]
        [StringLength(500)]
        public string Nacionalidad { get; set; }
        [Required(ErrorMessage = "El GeneroId es obligatorio")]
        [Display(Name = "GeneroId")]
        public int GeneroId { get; set; }

        [Required(ErrorMessage = "El Embarazo es obligatorio")]
        [Display(Name = "Embarazo")]
        public bool Embarazo { get; set; }

        [Display(Name = "UltimaMestruacion")]
        public DateTime? UltimaMestruacion { get; set; }

        [Required(ErrorMessage = "El Semanaembarazo es obligatorio")]
        [Display(Name = "Semanaembarazo")]
        [Column("Datanumeric_18_0", TypeName = "numeric(18, 0)")]
        public int Semanaembarazo { get; set; }

        [Required(ErrorMessage = "El Numeroembarazo es obligatorio")]
        [Display(Name = "Numeroembarazo")]
        [Column("Datanumeric_18_0", TypeName = "numeric(18, 0)")]
        public int Numeroembarazo { get; set; }

        [Required(ErrorMessage = "El EpsId es obligatorio")]
        [Display(Name = "EpsId")]
        public int EpsId { get; set; }

        [Required(ErrorMessage = "El CiudadId es obligatorio")]
        [Display(Name = "CiudadId")]
        public int CiudadId { get; set; }

        [Required(ErrorMessage = "El Direccion es obligatorio")]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Barrio es obligatorio")]
        [Display(Name = "Barrio")]
        [StringLength(300)]
        public string Barrio { get; set; }

        [Required(ErrorMessage = "El Correo es obligatorio")]
        [Display(Name = "Correo")]
        public int Correo { get; set; }

        [Required(ErrorMessage = "El Fijo es obligatorio")]
        [Display(Name = "Fijo")]
        [StringLength(100)]
        public string Fijo { get; set; }
        [Required(ErrorMessage = "El Celular es obligatorio")]
        [Display(Name = "Celular")]
        [StringLength(300)]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El NombreResponsable es obligatorio")]
        [Display(Name = "NombreResponsable")]
        [StringLength(500)]
        public string NombreResponsable { get; set; }
        [Required(ErrorMessage = "El FijoResponsable es obligatorio")]
        [Display(Name = "FijoResponsable")]
        [StringLength(100)]
        public string FijoResponsable { get; set; }
        [Required(ErrorMessage = "El CelularResponsable es obligatorio")]
        [Display(Name = "CelularResponsable")]
        [StringLength(200)]
        public string CelularResponsable { get; set; }

        [Required(ErrorMessage = "El ParentescoResponsable es obligatorio")]
        [Display(Name = "ParentescoResponsable")]
        [StringLength(200)]
        public string ParentescoResponsable { get; set; }

        [Required(ErrorMessage = "El NombreReferida es obligatorio")]
        [Display(Name = "NombreReferida")]
        [StringLength(500)]
        public string NombreReferida { get; set; }
        [Required(ErrorMessage = "El FijoReferido es obligatorio")]
        [Display(Name = "FijoReferido")]
        [StringLength(100)]
        public string FijoReferido { get; set; }
        [Required(ErrorMessage = "El CelularReferido es obligatorio")]
        [Display(Name = "CelularReferido")]
        [StringLength(200)]
        public string CelularReferido { get; set; }

        [Required(ErrorMessage = "El ReferidoPor es obligatorio")]
        [Display(Name = "ReferidoPor")]
        public string ReferidoPor { get; set; }

        [Required(ErrorMessage = "El NombreAcompanante es obligatorio")]
        [Display(Name = "NombreAcompanante")]
        [StringLength(500)]
        public string NombreAcompanante { get; set; }
        [Required(ErrorMessage = "El FijoAcompanante es obligatorio")]
        [Display(Name = "FijoAcompanante")]
        [StringLength(100)]
        public string FijoAcompanante { get; set; }
        [Required(ErrorMessage = "El CelularAcompanante es obligatorio")]
        [Display(Name = "CelularAcompanante")]
        [StringLength(200)]
        public string CelularAcompanante { get; set; }

        [Required(ErrorMessage = "El ParentescoAcompanante es obligatorio")]
        [Display(Name = "ParentescoAcompanante")]
        [StringLength(500)]
        public string ParentescoAcompanante { get; set; }
        [Required(ErrorMessage = "El NombreMadreMenor es obligatorio")]
        [Display(Name = "NombreMadreMenor")]
        [StringLength(500)]
        public string NombreMadreMenor { get; set; }
        [Required(ErrorMessage = "El CedulaMadreMenor es obligatorio")]
        [Display(Name = "CedulaMadreMenor")]
        [StringLength(100)]
        public string CedulaMadreMenor { get; set; }
        [Required(ErrorMessage = "El TelefonoMadreMenor es obligatorio")]
        [Display(Name = "TelefonoMadreMenor")]
        [StringLength(200)]
        public string TelefonoMadreMenor { get; set; }

        [Required(ErrorMessage = "El OcupacionMadreMenor es obligatorio")]
        [Display(Name = "OcupacionMadreMenor")]
        [StringLength(300)]
        public string OcupacionMadreMenor { get; set; }

        [Required(ErrorMessage = "El NombrePadreCuidadorMenor es obligatorio")]
        [Display(Name = "NombrePadreCuidadorMenor")]
        [StringLength(500)]
        public string NombrePadreCuidadorMenor { get; set; }
        [Required(ErrorMessage = "El CedulaPadreCuidadorMenor es obligatorio")]
        [Display(Name = "CedulaPadreCuidadorMenor")]
        [StringLength(200)]
        public string CedulaPadreCuidadorMenor { get; set; }

        [Required(ErrorMessage = "El TelefonoPadreCuidadorMenor es obligatorio")]
        [Display(Name = "TelefonoPadreCuidadorMenor")]
        [StringLength(200)]
        public string TelefonoPadreCuidadorMenor { get; set; }

        [Required(ErrorMessage = "El OcupacionPadreCuidadorMenor es obligatorio")]
        [Display(Name = "OcupacionPadreCuidadorMenor")]
        [StringLength(200)]
        public string OcupacionPadreCuidadorMenor { get; set; }

        [Required(ErrorMessage = "El ParentescoPadreCuidador es obligatorio")]
        [Display(Name = "ParentescoPadreCuidador")]
        [StringLength(500)]
        public string ParentescoPadreCuidador { get; set; }
         [ForeignKey("TipodocId")]
        public Tipodoc Tipodoc { get; set; }
        [ForeignKey("TiposangreId")]
        public Tiposangre Tiposangre { get; set; }
        [ForeignKey("EstadocivilId")]
        public Estadocivil Estadocivil { get; set; }
        [ForeignKey("GeneroId")]
        public Genero Genero { get; set; }
        [ForeignKey("EpsId")]
        public Eps Eps { get; set; }

   }
}

