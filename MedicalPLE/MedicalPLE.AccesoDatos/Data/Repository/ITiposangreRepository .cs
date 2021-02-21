using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface ITipoSangreRepository : IRepository<TipoSangre>
    {
        IEnumerable<SelectListItem> GetListaTipoSangre();

        void Update(TipoSangre tiposangre);
    }
}
