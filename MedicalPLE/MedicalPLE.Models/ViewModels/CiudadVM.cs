using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class CiudadVM
    {
        public Ciudad Ciudad { get; set; }
        public IEnumerable<SelectListItem> ListaDepartamento { get; set; }


    }
}



