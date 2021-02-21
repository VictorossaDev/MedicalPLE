// Tabla Independiente EstadoCivil
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class EstadoCivilRepository : Repository<EstadoCivil>, IEstadoCivilRepository
    {
        private readonly ApplicationDbContext _db;

        public EstadoCivilRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaEstadoCivil()
        {
            return _db.EstadoCivil.Select(i => new SelectListItem() { 
                Text = i.NombreEstadoCivil,
                Value = i.EstadoCivilId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(EstadoCivil estadocivil)
        {
            var objDesdeDb = _db.EstadoCivil.FirstOrDefault(s => s.EstadoCivilId == estadocivil.EstadoCivilId);
            objDesdeDb.NombreEstadoCivil = estadocivil.NombreEstadoCivil;

            _db.SaveChanges();
        }
    }
}


