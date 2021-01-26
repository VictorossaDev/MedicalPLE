//  Independiente => Eps
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
    public class EpsController : Controller
    {
        // Instanciamos el contenedor de trabajo que es donde tenemos todos los repositorios
        private readonly IContenedorTrabajo _contenedorTrabajo;

        // Contructor de la clase para acceder a todas las entidades
        public EpsController(IContenedorTrabajo contenedorTrabajo)
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
        //     Crear Eps
       
        // Create Con validacion de token para evitar que hakeen el formulario y para crear el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Eps eps)
        {
            // Valida el modelo, desde el modelo se determian lo requerido
            if (ModelState.IsValid)
            { 
       //------------------------------------------------------------------------------------------------------------------------------------------------------


       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
                // Invocamos el contenedor de trabajo para Eps   
                _contenedorTrabajo.Eps.Add(eps);
                _contenedorTrabajo.Save();

                // En caso de guardar la informacion retorna al index de la vista
                return RedirectToAction(nameof(Index));
            }
            // En caso de que no retorna a la misma vista
            return View(eps);
        }

        //--===============================================================--
        //     Editar1 Eps

        [HttpGet]
        public IActionResult Edit(int EpsId)
        {
            Eps eps = new Eps();
            eps = _contenedorTrabajo.Eps.Get(EpsId);
            if (eps == null)
            {
                return NotFound();
            }

            return View(eps);
        }

        //--===============================================================--
        //     Editar2 Eps

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Eps eps)
        {
            if (ModelState.IsValid)
            {

                _contenedorTrabajo.Eps.Update(eps);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //--===============================================================--
        //  Eliminar Eps

        [HttpDelete]
        public IActionResult Delete(int EpsId)
        {
            // Buscamos primero el registro segun el id que llego como parametro para eliminar el adecuado
            var epsDesdeDb = _contenedorTrabajo.Eps.Get(EpsId);
       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
            if (epsDesdeDb  == null)
            {
                return Json(new { success = false, message = "Error al borrar eps"});
            }
            _contenedorTrabajo.Eps.Remove(epsDesdeDb );
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Eps borrado correctamente" });
        }
    }
}

        //--===============================================================--


