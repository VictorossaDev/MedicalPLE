// Tabla Independiente Departamento
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        private readonly ApplicationDbContext _db;

        public DepartamentoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaDepartamento()
        {
            return _db.Departamento.Select(i => new SelectListItem() { 
                Text = i.NombreDepartamento,
                Value = i.DepartamentoId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(Departamento departamento)
        {
            var objDesdeDb = _db.Departamento.FirstOrDefault(s => s.DepartamentoId == departamento.DepartamentoId);
            objDesdeDb.NombreDepartamento = departamento.NombreDepartamento;

            _db.SaveChanges();
        }
    }
}


