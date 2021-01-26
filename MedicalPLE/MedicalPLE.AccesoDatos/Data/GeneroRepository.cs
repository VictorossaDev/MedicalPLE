// Tabla Independiente Genero
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        private readonly ApplicationDbContext _db;

        public GeneroRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaGenero()
        {
            return _db.Genero.Select(i => new SelectListItem() { 
                Text = i.NombreGenero,
                Value = i.GeneroId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(Genero genero)
        {
            var objDesdeDb = _db.Genero.FirstOrDefault(s => s.GeneroId == genero.GeneroId);
            objDesdeDb.NombreGenero = genero.NombreGenero;

            _db.SaveChanges();
        }
    }
}


