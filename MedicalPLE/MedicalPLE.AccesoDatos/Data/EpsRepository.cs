// Tabla Independiente Eps
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class EpsRepository : Repository<Eps>, IEpsRepository
    {
        private readonly ApplicationDbContext _db;

        public EpsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaEps()
        {
            return _db.Eps.Select(i => new SelectListItem() { 
                Text = i.NombreEps,
                Value = i.EpsId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(Eps eps)
        {
            var objDesdeDb = _db.Eps.FirstOrDefault(s => s.EpsId == eps.EpsId);
            objDesdeDb.NombreEps = eps.NombreEps;

            _db.SaveChanges();
        }
    }
}


