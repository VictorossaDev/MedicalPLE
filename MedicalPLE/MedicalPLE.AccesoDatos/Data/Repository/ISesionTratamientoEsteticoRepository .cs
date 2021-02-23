using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface ISesionTratamientoEsteticoRepository : IRepository<SesionTratamientoEstetico>
    {
        IEnumerable<SelectListItem> GetListaSesionTratamientoEstetico();

        void Update(SesionTratamientoEstetico sesiontratamientoestetico);
    }
}
