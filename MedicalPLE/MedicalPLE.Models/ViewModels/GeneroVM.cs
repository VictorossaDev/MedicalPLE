using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class GeneroVM
    {
        public Genero Genero { get; set; }
        // Para combobox
        public IEnumerable<SelectListItem> ListaGenero { get; set; }
    }
}



