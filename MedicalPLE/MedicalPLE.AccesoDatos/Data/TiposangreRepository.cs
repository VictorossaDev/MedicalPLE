// Tabla Independiente Tiposangre
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class TiposangreRepository : Repository<Tiposangre>, ITiposangreRepository
    {
        private readonly ApplicationDbContext _db;

        public TiposangreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaTiposangre()
        {
            return _db.Tiposangre.Select(i => new SelectListItem() { 
                Text = i.NombreTiposangre,
                Value = i.TiposangreId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(Tiposangre tiposangre)
        {
            var objDesdeDb = _db.Tiposangre.FirstOrDefault(s => s.TiposangreId == tiposangre.TiposangreId);
            objDesdeDb.NombreTiposangre = tiposangre.NombreTiposangre;

            _db.SaveChanges();
        }
    }
}


