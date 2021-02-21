using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface IEstadoCivilRepository : IRepository<EstadoCivil>
    {
        IEnumerable<SelectListItem> GetListaEstadoCivil();

        void Update(EstadoCivil estadocivil);
    }
}
