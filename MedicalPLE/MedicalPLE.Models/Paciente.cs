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

        [Required(ErrorMessage = "El No. Documento es obligatorio")]
        [Display(Name = "NumeroDocumento")]
        [Column(TypeName = "int")]
        public int NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El NombreApellido es obligatorio")]
        [Display(Name = "NombreApellido")]
        [StringLength(400)]
        public string NombreApellido { get; set; }

        [Required(ErrorMessage = "El EstadoCivilId es obligatorio")]
        [Display(Name = "EstadoCivilId")]
        public int EstadoCivilId { get; set; }

        [Display(Name = "FechaNacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El Edad Paciente es obligatorio")]
        [Display(Name = "Edad")]
        [Column(TypeName = "int")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El LugarNacimiento es obligatorio")]
        [Display(Name = "LugarNacimiento")]
        [StringLength(400)]
        public string LugarNacimiento { get; set; }

        [Required(ErrorMessage = "El Nacionalidad es obligatorio")]
        [Display(Name = "Nacionalidad")]
        [StringLength(300)]
        public string Nacionalidad { get; set; }

        [Required(ErrorMessage = "El GeneroId es obligatorio")]
        [Display(Name = "GeneroId")]
        public int GeneroId { get; set; }

        [Required(ErrorMessage = "El TipoSangreId es obligatorio")]
        [Display(Name = "TipoSangreId")]
        public int TipoSangreId { get; set; }

        [Required(ErrorMessage = "El EpsId es obligatorio")]
        [Display(Name = "EpsId")]
        public int EpsId { get; set; }

        [Required(ErrorMessage = "El CiudadId es obligatorio")]
        [Display(Name = "CiudadId")]
        public int CiudadId { get; set; }

        [Required(ErrorMessage = "El Direccion es obligatorio")]
        [Display(Name = "Direccion")]
        [StringLength(400)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El Barrio es obligatorio")]
        [Display(Name = "Barrio")]
        [StringLength(300)]
        public string Barrio { get; set; }

        [Required(ErrorMessage = "El Ocupacion es obligatorio")]
        [Display(Name = "Ocupacion")]
        [StringLength(300)]
        public string Ocupacion { get; set; }

        [Required(ErrorMessage = "El Correo es obligatorio")]
        [Display(Name = "Correo")]
        [StringLength(400)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El Telefono Fijo es obligatorio")]
        [Display(Name = "TelefonoFijo")]
        [StringLength(100)]
        public string TelefonoFijo { get; set; }

        [Required(ErrorMessage = "El Teléfono Celular es obligatorio")]
        [Display(Name = "TelefonoCelular")]
        [StringLength(100)]
        public string TelefonoCelular { get; set; }

        [Required(ErrorMessage = "El NombreApellidoPR es obligatorio")]
        [Display(Name = "NombreApellidoPR")]
        [StringLength(400)]
        public string NombreApellidoPR { get; set; }

        [Required(ErrorMessage = "El Teléfono Fijo es obligatorio")]
        [Display(Name = "TelefonoFijoPR")]
        [StringLength(100)]
        public string TelefonoFijoPR { get; set; }

        [Required(ErrorMessage = "El Teléfono Celular es obligatorio")]
        [Display(Name = "TelefonoCelularPR")]
        [StringLength(100)]
        public string TelefonoCelularPR { get; set; }

        [Required(ErrorMessage = "El ParentescoPR es obligatorio")]
        [Display(Name = "ParentescoPR")]
        [StringLength(300)]
        public string ParentescoPR { get; set; }

        [Required(ErrorMessage = "El NombreApellidoPREF es obligatorio")]
        [Display(Name = "NombreApellidoPREF")]
        [StringLength(400)]
        public string NombreApellidoPREF { get; set; }

        [Required(ErrorMessage = "El Teléfono Fijo es obligatorio")]
        [Display(Name = "TelefonoFijoPREF")]
        [StringLength(100)]
        public string TelefonoFijoPREF { get; set; }

        [Required(ErrorMessage = "El Teléfono Celular es obligatorio")]
        [Display(Name = "TelefonoCelularPREF")]
        [StringLength(100)]
        public string TelefonoCelularPREF { get; set; }

        [Required(ErrorMessage = "El ReferidoPor es obligatorio")]
        [Display(Name = "ReferidoPor")]
        [StringLength(400)]
        public string ReferidoPor { get; set; }

        [Required(ErrorMessage = "El NombreApellidoACOM es obligatorio")]
        [Display(Name = "NombreApellidoACOM")]
        [StringLength(400)]
        public string NombreApellidoACOM { get; set; }

        [Required(ErrorMessage = "El Telefono Fijo Acompañante es obligatorio")]
        [Display(Name = "TelefonoFijoACOM")]
        [StringLength(100)]
        public string TelefonoFijoACOM { get; set; }

        [Required(ErrorMessage = "El Telefono Celular es obligatorio")]
        [Display(Name = "TelefonoCelularACOM")]
        [StringLength(100)]
        public string TelefonoCelularACOM { get; set; }

        [Required(ErrorMessage = "El ParentescoACOM es obligatorio")]
        [Display(Name = "ParentescoACOM")]
        [StringLength(300)]
        public string ParentescoACOM { get; set; }

        [Required(ErrorMessage = "El NombreMadreME es obligatorio")]
        [Display(Name = "NombreMadreME")]
        [StringLength(400)]
        public string NombreMadreME { get; set; }

        [Required(ErrorMessage = "El Numero de cédula es obligatorio")]
        [Display(Name = "NumeroCedulaMadreME")]
        [Column(TypeName = "int")]
        public int NumeroCedulaMadreME { get; set; }

        [Required(ErrorMessage = "El Telefono Fijo es obligatorio")]
        [Display(Name = "TelefonoFijoME")]
        [StringLength(100)]
        public string TelefonoFijoME { get; set; }

        [Required(ErrorMessage = "El Telefono Celular es obligatorio")]
        [Display(Name = "TelefonoCelularME")]
        [StringLength(100)]
        public string TelefonoCelularME { get; set; }

        [Required(ErrorMessage = "El OcupacionME es obligatorio")]
        [Display(Name = "OcupacionME")]
        [StringLength(300)]
        public string OcupacionME { get; set; }

        [Required(ErrorMessage = "El ParentescoME es obligatorio")]
        [Display(Name = "ParentescoME")]
        [StringLength(300)]
        public string ParentescoME { get; set; }

         [ForeignKey("TipodocId")]
        public Tipodoc Tipodoc { get; set; }

        [ForeignKey("EstadoCivilId")]
        public EstadoCivil EstadoCivil { get; set; }

        [ForeignKey("GeneroId")]
        public Genero Genero { get; set; }

        [ForeignKey("TipoSangreId")]
        public TipoSangre TipoSangre { get; set; }

        [ForeignKey("EpsId")]
        public Eps Eps { get; set; }

        [ForeignKey("CiudadId")]
        public Ciudad Ciudad { get; set; }


   }




}

