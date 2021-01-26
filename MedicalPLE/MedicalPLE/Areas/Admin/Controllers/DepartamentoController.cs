//  Independiente => Departamento
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
    public class DepartamentoController : Controller
    {
        // Instanciamos el contenedor de trabajo que es donde tenemos todos los repositorios
        private readonly IContenedorTrabajo _contenedorTrabajo;

        // Contructor de la clase para acceder a todas las entidades
        public DepartamentoController(IContenedorTrabajo contenedorTrabajo)
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
        //     Crear Departamento
       
        // Create Con validacion de token para evitar que hakeen el formulario y para crear el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)
        {
            // Valida el modelo, desde el modelo se determian lo requerido
            if (ModelState.IsValid)
            { 
       //------------------------------------------------------------------------------------------------------------------------------------------------------


       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
                // Invocamos el contenedor de trabajo para Departamento   
                _contenedorTrabajo.Departamento.Add(departamento);
                _contenedorTrabajo.Save();

                // En caso de guardar la informacion retorna al index de la vista
                return RedirectToAction(nameof(Index));
            }
            // En caso de que no retorna a la misma vista
            return View(departamento);
        }

        //--===============================================================--
        //     Editar1 Departamento

        [HttpGet]
        public IActionResult Edit(int DepartamentoId)
        {
            Departamento departamento = new Departamento();
            departamento = _contenedorTrabajo.Departamento.Get(DepartamentoId);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        //--===============================================================--
        //     Editar2 Departamento

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento departamento)
        {
            if (ModelState.IsValid)
            {

                _contenedorTrabajo.Departamento.Update(departamento);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Departamento.GetAll() });
        }

        //--===============================================================--
        //  Eliminar Departamento

        [HttpDelete]
        public IActionResult Delete(int DepartamentoId)
        {
            // Buscamos primero el registro segun el id que llego como parametro para eliminar el adecuado
            var departamentoDesdeDb = _contenedorTrabajo.Departamento.Get(DepartamentoId);
       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
            if (departamentoDesdeDb  == null)
            {
                return Json(new { success = false, message = "Error al borrar departamento"});
            }
            _contenedorTrabajo.Departamento.Remove(departamentoDesdeDb );
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Departamento borrado correctamente" });
        }
    }
}

        //--===============================================================--


