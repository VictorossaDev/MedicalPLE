using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class TiposangreVM
    {
        public Tiposangre Tiposangre { get; set; }
        // Para combobox
        public IEnumerable<SelectListItem> ListaTiposangre { get; set; }
    }
}



