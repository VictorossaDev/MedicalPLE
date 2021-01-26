using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface IEstadocivilRepository : IRepository<Estadocivil>
    {
        IEnumerable<SelectListItem> GetListaEstadocivil();

        void Update(Estadocivil estadocivil);
    }
}
