using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface IDepartamentoRepository : IRepository<Departamento>
    {
        IEnumerable<SelectListItem> GetListaDepartamento();

        void Update(Departamento departamento);
    }
}
