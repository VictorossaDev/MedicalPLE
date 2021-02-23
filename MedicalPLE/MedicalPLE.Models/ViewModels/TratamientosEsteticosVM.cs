using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class TratamientosEsteticosVM
    {
        public TratamientosEsteticos TratamientosEsteticos { get; set; }
        // Para combobox
        public IEnumerable<SelectListItem> ListaTratamientosEsteticos { get; set; }
    }
}



