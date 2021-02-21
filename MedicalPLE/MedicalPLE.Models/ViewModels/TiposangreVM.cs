using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class TipoSangreVM
    {
        public TipoSangre TipoSangre { get; set; }
        // Para combobox
        public IEnumerable<SelectListItem> ListaTipoSangre { get; set; }
    }
}



