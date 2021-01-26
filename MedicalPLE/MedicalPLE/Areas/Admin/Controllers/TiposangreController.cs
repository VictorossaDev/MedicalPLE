//  Independiente => Tiposangre
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
    public class TiposangreController : Controller
    {
        // Instanciamos el contenedor de trabajo que es donde tenemos todos los repositorios
        private readonly IContenedorTrabajo _contenedorTrabajo;

        // Contructor de la clase para acceder a todas las entidades
        public TiposangreController(IContenedorTrabajo contenedorTrabajo)
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
        //     Crear Tiposangre
       
        // Create Con validacion de token para evitar que hakeen el formulario y para crear el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tiposangre tiposangre)
        {
            // Valida el modelo, desde el modelo se determian lo requerido
            if (ModelState.IsValid)
            { 
       //------------------------------------------------------------------------------------------------------------------------------------------------------


       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
                // Invocamos el contenedor de trabajo para Tiposangre   
                _contenedorTrabajo.Tiposangre.Add(tiposangre);
                _contenedorTrabajo.Save();

                // En caso de guardar la informacion retorna al index de la vista
                return RedirectToAction(nameof(Index));
            }
            // En caso de que no retorna a la misma vista
            return View(tiposangre);
        }

        //--===============================================================--
        //     Editar1 Tiposangre

        [HttpGet]
        public IActionResult Edit(int TiposangreId)
        {
            Tiposangre tiposangre = new Tiposangre();
            tiposangre = _contenedorTrabajo.Tiposangre.Get(TiposangreId);
            if (tiposangre == null)
            {
                return NotFound();
            }

            return View(tiposangre);
        }

        //--===============================================================--
        //     Editar2 Tiposangre

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tiposangre tiposangre)
        {
            if (ModelState.IsValid)
            {

                _contenedorTrabajo.Tiposangre.Update(tiposangre);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //--===============================================================--
        //  Eliminar Tiposangre

        [HttpDelete]
        public IActionResult Delete(int TiposangreId)
        {
            // Buscamos primero el registro segun el id que llego como parametro para eliminar el adecuado
            var tiposangreDesdeDb = _contenedorTrabajo.Tiposangre.Get(TiposangreId);
       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
            if (tiposangreDesdeDb  == null)
            {
                return Json(new { success = false, message = "Error al borrar tiposangre"});
            }
            _contenedorTrabajo.Tiposangre.Remove(tiposangreDesdeDb );
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Tiposangre borrado correctamente" });
        }
    }
}

        //--===============================================================--


