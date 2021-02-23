// Tabla Independiente TratamientosEsteticos
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class TratamientosEsteticosRepository : Repository<TratamientosEsteticos>, ITratamientosEsteticosRepository
    {
        private readonly ApplicationDbContext _db;

        public TratamientosEsteticosRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaTratamientosEsteticos()
        {
            return _db.TratamientosEsteticos.Select(i => new SelectListItem() { 
                Text = i.NombreTratamientoEstetico,
                Value = i.TratamientoEsteticoId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(TratamientosEsteticos tratamientosesteticos)
        {
            var objDesdeDb = _db.TratamientosEsteticos.FirstOrDefault(s => s.TratamientoEsteticoId == tratamientosesteticos.TratamientoEsteticoId);
            objDesdeDb.NombreTratamientoEstetico = tratamientosesteticos.NombreTratamientoEstetico;
            objDesdeDb.ObservacionesTratamiento = tratamientosesteticos.ObservacionesTratamiento;

            _db.SaveChanges();
        }
    }
}


