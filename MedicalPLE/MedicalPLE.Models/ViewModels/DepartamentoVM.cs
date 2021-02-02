using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class DepartamentoVM
    {
        public Departamento Departamento { get; set; }

        public IEnumerable<SelectListItem> ListaDepartamento { get; set; }
    }
}



