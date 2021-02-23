using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MedicalPLE.Models.ViewModels
{
    // Debe ser una clase publica
    public class ImagenesSesionVM
    {
        public ImagenesSesion ImagenesSesion{ get; set; }
         // Listas
        public IEnumerable<SelectListItem> ListaSesionTratamientoEstetico { get; set; }


    }
}