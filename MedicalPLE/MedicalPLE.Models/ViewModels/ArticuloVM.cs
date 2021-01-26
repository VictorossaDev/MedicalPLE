using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.Models.ViewModels
{
    public class ArticuloVM
    {
        public Articulo Articulo { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}
