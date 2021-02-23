// Dependiente -- SesionTratamientoEstetico
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicalPLE.Models
{
    public class SesionTratamientoEstetico
    {
        [Key]
       [Column("SesionTratamientoEsteticoId")]
       public int SesionTratamientoEsteticoId { get; set; }

        [Required(ErrorMessage = "El PacienteEsteticaId es obligatorio")]
        [Display(Name = "PacienteEsteticaId")]
        public int PacienteEsteticaId { get; set; }

        [Required(ErrorMessage = "El Trae Acompañante es obligatorio")]
        [Display(Name = "TraeAcompanante")]
        public bool TraeAcompanante { get; set; }

        [Required(ErrorMessage = "El Acompanante es obligatorio")]
        [Display(Name = "Acompanante")]
        [StringLength(400)]
        public string Acompanante { get; set; }

        [Required(ErrorMessage = "El Telefono en caso de urgencia es obligatorio")]
        [Display(Name = "TelefonoReferenciaAcom")]
        [StringLength(100)]
        public string TelefonoReferenciaAcom { get; set; }

        [Display(Name = "FechaSesion")]
        public DateTime? FechaSesion { get; set; }

        [Required(ErrorMessage = "El Formulaciones es obligatorio")]
        [Display(Name = "Formulaciones")]
        public string Formulaciones { get; set; }

         [ForeignKey("PacienteEsteticaId")]
        public PacienteEstetica PacienteEstetica { get; set; }


   }




}

