// Tabla Independiente Tipodoc
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class TipodocRepository : Repository<Tipodoc>, ITipodocRepository
    {
        private readonly ApplicationDbContext _db;

        public TipodocRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaTipodoc()
        {
            return _db.Tipodoc.Select(i => new SelectListItem() { 
                Text = i.NombreTipodoc,
                Value = i.TipodocId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(Tipodoc tipodoc)
        {
            var objDesdeDb = _db.Tipodoc.FirstOrDefault(s => s.TipodocId == tipodoc.TipodocId);
            objDesdeDb.NombreTipodoc = tipodoc.NombreTipodoc;

            _db.SaveChanges();
        }
    }
}


