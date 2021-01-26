using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface IGeneroRepository : IRepository<Genero>
    {
        IEnumerable<SelectListItem> GetListaGenero();

        void Update(Genero genero);
    }
}
