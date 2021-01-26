//  Dependiente => Paciente
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MedicalPLE.AccesoDatos.Data.Repository;
using MedicalPLE.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPLE.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PacienteController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PacienteController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironmen)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironmen;
        }
        // --===============================================================--
        //      Carga Vista Paciente

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       //--===============================================================--
       //     Carga Paciente

        [HttpGet]
        public IActionResult Create()
        {
            PacienteVM pacientevm = new PacienteVM()
            {
                Paciente = new Models.Paciente(),
                ListaTipodoc = _contenedorTrabajo.Tipodoc.GetListaTipodoc(),
                ListaTiposangre = _contenedorTrabajo.Tiposangre.GetListaTiposangre(),
                ListaEstadocivil = _contenedorTrabajo.Estadocivil.GetListaEstadocivil(),
                ListaGenero = _contenedorTrabajo.Genero.GetListaGenero(),
                ListaEps = _contenedorTrabajo.Eps.GetListaEps(),
            };
            return View(pacientevm );
        }

        //--===============================================================--
        //     Crear Paciente

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PacienteVM pacienteVM)
        {

            // Valida el Modelo para hacer un primer filtro
            if (ModelState.IsValid)
            {
       //------------------------------------------------------------------------------------------------------------------------------------------------------

      //------------------------------------------------------------------------------------------------------------------------------------------------------

      //------------------------------------------------------------------------------------------------------------------------------------------------------
                    _contenedorTrabajo.Paciente.Add(pacienteVM.Paciente);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));                
            }
            return View();
        }

        //--===============================================================--
        //     Editar1 Paciente

        [HttpGet]
        public IActionResult Edit(int? PacienteId)
        {
            PacienteVM pacientevm = new PacienteVM()
            {
                Paciente = new Models.Paciente(),
                ListaTipodoc = _contenedorTrabajo.Tipodoc.GetListaTipodoc(),
                ListaTiposangre = _contenedorTrabajo.Tiposangre.GetListaTiposangre(),
                ListaEstadocivil = _contenedorTrabajo.Estadocivil.GetListaEstadocivil(),
                ListaGenero = _contenedorTrabajo.Genero.GetListaGenero(),
                ListaEps = _contenedorTrabajo.Eps.GetListaEps(),

            };

            if (PacienteId != null)
            {
                pacientevm.Paciente= _contenedorTrabajo.Paciente.Get(PacienteId.GetValueOrDefault());
            }
            return View(pacientevm);
        }

        //--===============================================================--
        //     Editar2 Paciente

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PacienteVM pacienteVM)
        {
            if (ModelState.IsValid)
            {
      //------------------------------------------------------------------------------------------------------------------------------------------------------

      //------------------------------------------------------------------------------------------------------------------------------------------------------

      //------------------------------------------------------------------------------------------------------------------------------------------------------

     //------------------------------------------------------------------------------------------------------------------------------------------------------

                _contenedorTrabajo.Paciente.Update(pacienteVM.Paciente);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpDelete]
        public IActionResult Delete(int PacienteId)
        {

            var pacienteDesdeDb = _contenedorTrabajo.Paciente.Get(PacienteId);
       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
            _contenedorTrabajo.Paciente.Remove(pacienteDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Paciente borrado con éxito" });

        }


        #region LLAMADAS A LA API
        // Para poder utilizar Datatables y consultar estos por ajax
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Paciente.GetAll(includeProperties: "Categoria") });
        }
        #endregion        
    }
}


