using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class SesionTratamientoEsteticoVM
    {
        public SesionTratamientoEstetico SesionTratamientoEstetico{ get; set; }
         // Listas
        public IEnumerable<SelectListItem> ListaPacienteEstetica { get; set; }


    }
}