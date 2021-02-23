using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface ITratamientosEsteticosRepository : IRepository<TratamientosEsteticos>
    {
        IEnumerable<SelectListItem> GetListaTratamientosEsteticos();

        void Update(TratamientosEsteticos tratamientosesteticos);
    }
}
