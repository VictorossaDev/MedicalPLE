using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface IPacienteRepository : IRepository<Paciente>
    {
        IEnumerable<SelectListItem> GetListaPaciente();

        void Update(Paciente paciente);
    }
}
