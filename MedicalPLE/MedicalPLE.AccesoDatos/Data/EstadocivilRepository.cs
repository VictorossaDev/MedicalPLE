// Tabla Independiente Estadocivil
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class EstadocivilRepository : Repository<Estadocivil>, IEstadocivilRepository
    {
        private readonly ApplicationDbContext _db;

        public EstadocivilRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaEstadocivil()
        {
            return _db.Estadocivil.Select(i => new SelectListItem() { 
                Text = i.NombreEstadocivil,
                Value = i.EstadocivilId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(Estadocivil estadocivil)
        {
            var objDesdeDb = _db.Estadocivil.FirstOrDefault(s => s.EstadocivilId == estadocivil.EstadocivilId);
            objDesdeDb.NombreEstadocivil = estadocivil.NombreEstadocivil;

            _db.SaveChanges();
        }
    }
}


