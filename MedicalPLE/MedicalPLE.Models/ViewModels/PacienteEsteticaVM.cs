using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class PacienteEsteticaVM
    {
        public PacienteEstetica PacienteEstetica{ get; set; }
         // Listas
        public IEnumerable<SelectListItem> ListaTipodoc { get; set; }

        public IEnumerable<SelectListItem> ListaGenero { get; set; }


    }
}