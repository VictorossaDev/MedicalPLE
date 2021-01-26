//  Independiente => Tipodoc
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalPLE.AccesoDatos.Data.Repository;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalPLE.Areas.Admin.Controllers
{
    // Solicitara autorizacion al acceso al controlador segun el rol del usuario, para que este protegido
    [Authorize]
    // Area a la que pertenece el controlador
    [Area("Admin")]
    public class TipodocController : Controller
    {
        // Instanciamos el contenedor de trabajo que es donde tenemos todos los repositorios
        private readonly IContenedorTrabajo _contenedorTrabajo;

        // Contructor de la clase para acceder a todas las entidades
        public TipodocController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Create que pinta el formulario
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //--===============================================================--
        //     Crear Tipodoc
       
        // Create Con validacion de token para evitar que hakeen el formulario y para crear el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tipodoc tipodoc)
        {
            // Valida el modelo, desde el modelo se determian lo requerido
            if (ModelState.IsValid)
            { 
       //------------------------------------------------------------------------------------------------------------------------------------------------------


       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
                // Invocamos el contenedor de trabajo para Tipodoc   
                _contenedorTrabajo.Tipodoc.Add(tipodoc);
                _contenedorTrabajo.Save();

                // En caso de guardar la informacion retorna al index de la vista
                return RedirectToAction(nameof(Index));
            }
            // En caso de que no retorna a la misma vista
            return View(tipodoc);
        }

        //--===============================================================--
        //     Editar1 Tipodoc

        [HttpGet]
        public IActionResult Edit(int TipodocId)
        {
            Tipodoc tipodoc = new Tipodoc();
            tipodoc = _contenedorTrabajo.Tipodoc.Get(TipodocId);
            if (tipodoc == null)
            {
                return NotFound();
            }

            return View(tipodoc);
        }

        //--===============================================================--
        //     Editar2 Tipodoc

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tipodoc tipodoc)
        {
            if (ModelState.IsValid)
            {

                _contenedorTrabajo.Tipodoc.Update(tipodoc);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Tipodoc.GetAll() });
        }

        //--===============================================================--
        //  Eliminar Tipodoc

        [HttpDelete]
        public IActionResult Delete(int TipodocId)
        {
            // Buscamos primero el registro segun el id que llego como parametro para eliminar el adecuado
            var tipodocDesdeDb = _contenedorTrabajo.Tipodoc.Get(TipodocId);
       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
            if (tipodocDesdeDb  == null)
            {
                return Json(new { success = false, message = "Error al borrar tipodoc"});
            }
            _contenedorTrabajo.Tipodoc.Remove(tipodocDesdeDb );
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Tipodoc borrado correctamente" });
        }
    }
}

        //--===============================================================--


