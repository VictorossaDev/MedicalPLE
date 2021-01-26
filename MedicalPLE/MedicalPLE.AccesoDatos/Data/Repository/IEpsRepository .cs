using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface IEpsRepository : IRepository<Eps>
    {
        IEnumerable<SelectListItem> GetListaEps();

        void Update(Eps eps);
    }
}
