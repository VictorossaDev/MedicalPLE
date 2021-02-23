using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface IPacienteEsteticaRepository : IRepository<PacienteEstetica>
    {
        IEnumerable<SelectListItem> GetListaPacienteEstetica();

        void Update(PacienteEstetica pacienteestetica);
    }
}
