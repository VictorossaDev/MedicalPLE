// Tabla Dependiente Ciudad
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.Models;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class CiudadRepository : Repository<Ciudad>, ICiudadRepository
    {
        private readonly ApplicationDbContext _db;

        public CiudadRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaCiudad()
        {
            return _db.Ciudad.Select(i => new SelectListItem() { 
                Text = i.NombreCiudad,
                Value = i.CiudadId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(Ciudad ciudad)
        {
            var objDesdeDb = _db.Ciudad.FirstOrDefault(s => s.CiudadId == ciudad.CiudadId);
            objDesdeDb.NombreCiudad = ciudad.NombreCiudad;
            objDesdeDb.DepartamentoId = ciudad.DepartamentoId;

            _db.SaveChanges();
        }
    }
}


