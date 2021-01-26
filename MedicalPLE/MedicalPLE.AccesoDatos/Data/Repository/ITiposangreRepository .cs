using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface ITiposangreRepository : IRepository<Tiposangre>
    {
        IEnumerable<SelectListItem> GetListaTiposangre();

        void Update(Tiposangre tiposangre);
    }
}
