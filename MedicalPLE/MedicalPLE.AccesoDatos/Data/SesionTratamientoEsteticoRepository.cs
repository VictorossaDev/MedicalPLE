// Tabla Dependiente SesionTratamientoEstetico
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.Models;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class SesionTratamientoEsteticoRepository : Repository<SesionTratamientoEstetico>, ISesionTratamientoEsteticoRepository
    {
        private readonly ApplicationDbContext _db;

        public SesionTratamientoEsteticoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaSesionTratamientoEstetico()
        {
            return _db.SesionTratamientoEstetico.Select(i => new SelectListItem() { 
                Text = i.TelefonoReferenciaAcom,
                Value = i.SesionTratamientoEsteticoId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(SesionTratamientoEstetico sesiontratamientoestetico)
        {
            var objDesdeDb = _db.SesionTratamientoEstetico.FirstOrDefault(s => s.SesionTratamientoEsteticoId == sesiontratamientoestetico.SesionTratamientoEsteticoId);
            objDesdeDb.PacienteEsteticaId = sesiontratamientoestetico.PacienteEsteticaId;
            objDesdeDb.TraeAcompanante = sesiontratamientoestetico.TraeAcompanante;
            objDesdeDb.Acompanante = sesiontratamientoestetico.Acompanante;
            objDesdeDb.TelefonoReferenciaAcom = sesiontratamientoestetico.TelefonoReferenciaAcom;
            objDesdeDb.FechaSesion = sesiontratamientoestetico.FechaSesion;
            objDesdeDb.Formulaciones = sesiontratamientoestetico.Formulaciones;

            _db.SaveChanges();
        }
    }
}


