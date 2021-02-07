using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class CiudadVM
    {
        public Ciudad Ciudad{ get; set; }
         // Listas
        public IEnumerable<SelectListItem> ListaDepartamento { get; set; }


    }
}