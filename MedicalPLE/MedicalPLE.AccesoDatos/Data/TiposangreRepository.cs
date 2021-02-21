// Tabla Independiente TipoSangre
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class TipoSangreRepository : Repository<TipoSangre>, ITipoSangreRepository
    {
        private readonly ApplicationDbContext _db;

        public TipoSangreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaTipoSangre()
        {
            return _db.TipoSangre.Select(i => new SelectListItem() { 
                Text = i.NombreTipoSangre,
                Value = i.TipoSangreId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(TipoSangre tiposangre)
        {
            var objDesdeDb = _db.TipoSangre.FirstOrDefault(s => s.TipoSangreId == tiposangre.TipoSangreId);
            objDesdeDb.NombreTipoSangre = tiposangre.NombreTipoSangre;

            _db.SaveChanges();
        }
    }
}


