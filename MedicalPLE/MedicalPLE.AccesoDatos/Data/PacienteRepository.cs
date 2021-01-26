// Tabla Dependiente Paciente
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                Text = i.NombresApellidos,
                Value = i.PacienteId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(Paciente paciente)
        {
            var objDesdeDb = _db.Paciente.FirstOrDefault(s => s.PacienteId == paciente.PacienteId);
            objDesdeDb.TipodocId = paciente.TipodocId;
            objDesdeDb.NumeroDocumento = paciente.NumeroDocumento;
            objDesdeDb.NombresApellidos = paciente.NombresApellidos;
            objDesdeDb.TiposangreId = paciente.TiposangreId;
            objDesdeDb.EstadocivilId = paciente.EstadocivilId;
            objDesdeDb.Fechanacimiento = paciente.Fechanacimiento;
            objDesdeDb.Edad = paciente.Edad;
            objDesdeDb.Lugarnacimiento = paciente.Lugarnacimiento;
            objDesdeDb.Nacionalidad = paciente.Nacionalidad;
            objDesdeDb.GeneroId = paciente.GeneroId;
            objDesdeDb.Embarazo = paciente.Embarazo;
            objDesdeDb.UltimaMestruacion = paciente.UltimaMestruacion;
            objDesdeDb.Semanaembarazo = paciente.Semanaembarazo;
            objDesdeDb.Numeroembarazo = paciente.Numeroembarazo;
            objDesdeDb.EpsId = paciente.EpsId;
            objDesdeDb.CiudadId = paciente.CiudadId;
            objDesdeDb.Direccion = paciente.Direccion;
            objDesdeDb.Barrio = paciente.Barrio;
            objDesdeDb.Correo = paciente.Correo;
            objDesdeDb.Fijo = paciente.Fijo;
            objDesdeDb.Celular = paciente.Celular;
            objDesdeDb.NombreResponsable = paciente.NombreResponsable;
            objDesdeDb.FijoResponsable = paciente.FijoResponsable;
            objDesdeDb.CelularResponsable = paciente.CelularResponsable;
            objDesdeDb.ParentescoResponsable = paciente.ParentescoResponsable;
            objDesdeDb.NombreReferida = paciente.NombreReferida;
            objDesdeDb.FijoReferido = paciente.FijoReferido;
            objDesdeDb.CelularReferido = paciente.CelularReferido;
            objDesdeDb.ReferidoPor = paciente.ReferidoPor;
            objDesdeDb.NombreAcompanante = paciente.NombreAcompanante;
            objDesdeDb.FijoAcompanante = paciente.FijoAcompanante;
            objDesdeDb.CelularAcompanante = paciente.CelularAcompanante;
            objDesdeDb.ParentescoAcompanante = paciente.ParentescoAcompanante;
            objDesdeDb.NombreMadreMenor = paciente.NombreMadreMenor;
            objDesdeDb.CedulaMadreMenor = paciente.CedulaMadreMenor;
            objDesdeDb.TelefonoMadreMenor = paciente.TelefonoMadreMenor;
            objDesdeDb.OcupacionMadreMenor = paciente.OcupacionMadreMenor;
            objDesdeDb.NombrePadreCuidadorMenor = paciente.NombrePadreCuidadorMenor;
            objDesdeDb.CedulaPadreCuidadorMenor = paciente.CedulaPadreCuidadorMenor;
            objDesdeDb.TelefonoPadreCuidadorMenor = paciente.TelefonoPadreCuidadorMenor;
            objDesdeDb.OcupacionPadreCuidadorMenor = paciente.OcupacionPadreCuidadorMenor;
            objDesdeDb.ParentescoPadreCuidador = paciente.ParentescoPadreCuidador;

            _db.SaveChanges();
        }
    }
}


