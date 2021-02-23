using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface IImagenesSesionRepository : IRepository<ImagenesSesion>
    {
        IEnumerable<SelectListItem> GetListaImagenesSesion();

        void Update(ImagenesSesion imagenessesion);
    }
}
