using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class EstadoCivilVM
    {
        public EstadoCivil EstadoCivil { get; set; }
        // Para combobox
        public IEnumerable<SelectListItem> ListaEstadoCivil { get; set; }
    }
}



