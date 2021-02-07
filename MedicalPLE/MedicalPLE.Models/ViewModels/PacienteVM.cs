using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class PacienteVM
    {
        public Paciente Paciente{ get; set; }
         // Listas
        public IEnumerable<SelectListItem> ListaTipodoc { get; set; }

        public IEnumerable<SelectListItem> ListaTiposangre { get; set; }

        public IEnumerable<SelectListItem> ListaEstadocivil { get; set; }

        public IEnumerable<SelectListItem> ListaGenero { get; set; }

        public IEnumerable<SelectListItem> ListaEps { get; set; }


    }
}