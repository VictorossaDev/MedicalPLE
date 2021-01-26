//  Independiente => Estadocivil
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
    public class EstadocivilController : Controller
    {
        // Instanciamos el contenedor de trabajo que es donde tenemos todos los repositorios
        private readonly IContenedorTrabajo _contenedorTrabajo;

        // Contructor de la clase para acceder a todas las entidades
        public EstadocivilController(IContenedorTrabajo contenedorTrabajo)
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
        //     Crear Estadocivil
       
        // Create Con validacion de token para evitar que hakeen el formulario y para crear el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Estadocivil estadocivil)
        {
            // Valida el modelo, desde el modelo se determian lo requerido
            if (ModelState.IsValid)
            { 
       //------------------------------------------------------------------------------------------------------------------------------------------------------


       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
                // Invocamos el contenedor de trabajo para Estadocivil   
                _contenedorTrabajo.Estadocivil.Add(estadocivil);
                _contenedorTrabajo.Save();

                // En caso de guardar la informacion retorna al index de la vista
                return RedirectToAction(nameof(Index));
            }
            // En caso de que no retorna a la misma vista
            return View(estadocivil);
        }

        //--===============================================================--
        //     Editar1 Estadocivil

        [HttpGet]
        public IActionResult Edit(int EstadocivilId)
        {
            Estadocivil estadocivil = new Estadocivil();
            estadocivil = _contenedorTrabajo.Estadocivil.Get(EstadocivilId);
            if (estadocivil == null)
            {
                return NotFound();
            }

            return View(estadocivil);
        }

        //--===============================================================--
        //     Editar2 Estadocivil

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Estadocivil estadocivil)
        {
            if (ModelState.IsValid)
            {

                _contenedorTrabajo.Estadocivil.Update(estadocivil);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //--===============================================================--
        //  Eliminar Estadocivil

        [HttpDelete]
        public IActionResult Delete(int EstadocivilId)
        {
            // Buscamos primero el registro segun el id que llego como parametro para eliminar el adecuado
            var estadocivilDesdeDb = _contenedorTrabajo.Estadocivil.Get(EstadocivilId);
       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
            if (estadocivilDesdeDb  == null)
            {
                return Json(new { success = false, message = "Error al borrar estadocivil"});
            }
            _contenedorTrabajo.Estadocivil.Remove(estadocivilDesdeDb );
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Estadocivil borrado correctamente" });
        }
    }
}

        //--===============================================================--


