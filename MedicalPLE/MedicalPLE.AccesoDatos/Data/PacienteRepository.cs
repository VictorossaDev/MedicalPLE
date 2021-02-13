// Tabla Dependiente Paciente
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.Models;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        private readonly ApplicationDbContext _db;

        public PacienteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaPaciente()
        {
            return _db.Paciente.Select(i => new SelectListItem() { 
                Text = i.NombreApellido,
                Value = i.PacienteId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(Paciente paciente)
        {
            var objDesdeDb = _db.Paciente.FirstOrDefault(s => s.PacienteId == paciente.PacienteId);
            objDesdeDb.TipodocId = paciente.TipodocId;
            objDesdeDb.NumeroDoc = paciente.NumeroDoc;
            objDesdeDb.NombreApellido = paciente.NombreApellido;
            objDesdeDb.TiposangreId = paciente.TiposangreId;
            objDesdeDb.EstadocivilId = paciente.EstadocivilId;
            objDesdeDb.Edad = paciente.Edad;
            objDesdeDb.CiudadId = paciente.CiudadId;
            objDesdeDb.Nacionalidad = paciente.Nacionalidad;
            objDesdeDb.GeneroId = paciente.GeneroId;

            _db.SaveChanges();
        }
    }
}


