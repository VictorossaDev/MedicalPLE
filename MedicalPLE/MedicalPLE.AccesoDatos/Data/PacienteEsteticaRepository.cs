// Tabla Dependiente PacienteEstetica
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.Models;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class PacienteEsteticaRepository : Repository<PacienteEstetica>, IPacienteEsteticaRepository
    {
        private readonly ApplicationDbContext _db;

        public PacienteEsteticaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaPacienteEstetica()
        {
            return _db.PacienteEstetica.Select(i => new SelectListItem() { 
                Text = i.NombreApellido,
                Value = i.PacienteEsteticaId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(PacienteEstetica pacienteestetica)
        {
            var objDesdeDb = _db.PacienteEstetica.FirstOrDefault(s => s.PacienteEsteticaId == pacienteestetica.PacienteEsteticaId);
            objDesdeDb.TipodocId = pacienteestetica.TipodocId;
            objDesdeDb.NumeroDocumento = pacienteestetica.NumeroDocumento;
            objDesdeDb.NombreApellido = pacienteestetica.NombreApellido;
            objDesdeDb.Edad = pacienteestetica.Edad;
            objDesdeDb.GeneroId = pacienteestetica.GeneroId;

            _db.SaveChanges();
        }
    }
}


