//  Independiente => Genero
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
    public class GeneroController : Controller
    {
        // Instanciamos el contenedor de trabajo que es donde tenemos todos los repositorios
        private readonly IContenedorTrabajo _contenedorTrabajo;

        // Contructor de la clase para acceder a todas las entidades
        public GeneroController(IContenedorTrabajo contenedorTrabajo)
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
        //     Crear Genero
       
        // Create Con validacion de token para evitar que hakeen el formulario y para crear el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genero genero)
        {
            // Valida el modelo, desde el modelo se determian lo requerido
            if (ModelState.IsValid)
            { 
       //------------------------------------------------------------------------------------------------------------------------------------------------------


       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
                // Invocamos el contenedor de trabajo para Genero   
                _contenedorTrabajo.Genero.Add(genero);
                _contenedorTrabajo.Save();

                // En caso de guardar la informacion retorna al index de la vista
                return RedirectToAction(nameof(Index));
            }
            // En caso de que no retorna a la misma vista
            return View(genero);
        }

        //--===============================================================--
        //     Editar1 Genero

        [HttpGet]
        public IActionResult Edit(int GeneroId)
        {
            Genero genero = new Genero();
            genero = _contenedorTrabajo.Genero.Get(GeneroId);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        //--===============================================================--
        //     Editar2 Genero

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genero genero)
        {
            if (ModelState.IsValid)
            {

                _contenedorTrabajo.Genero.Update(genero);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //--===============================================================--
        //  Eliminar Genero

        [HttpDelete]
        public IActionResult Delete(int GeneroId)
        {
            // Buscamos primero el registro segun el id que llego como parametro para eliminar el adecuado
            var generoDesdeDb = _contenedorTrabajo.Genero.Get(GeneroId);
       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
            if (generoDesdeDb  == null)
            {
                return Json(new { success = false, message = "Error al borrar genero"});
            }
            _contenedorTrabajo.Genero.Remove(generoDesdeDb );
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Genero borrado correctamente" });
        }
    }
}

        //--===============================================================--


