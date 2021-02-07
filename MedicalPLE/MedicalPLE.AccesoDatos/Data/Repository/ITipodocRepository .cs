using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface ITipodocRepository : IRepository<Tipodoc>
    {
        IEnumerable<SelectListItem> GetListaTipodoc();

        void Update(Tipodoc tipodoc);
    }
}
