// Tabla Independiente => Estadocivil
using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

using MedicalPLE.Models;
using MedicalPLE.AccesoDatos.Data.Repository;

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
        // En caso de que el modelo tenga un campo tipo imagen
        private readonly IWebHostEnvironment _hostingEnvironment;

        // Contructor de la clase para acceder a todas las entidades
        public EstadocivilController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironment;
        }

        // Inicio de Formulario
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Inicio de Formulario de Creacion
        [HttpGet]
        public IActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Estadocivil estadocivil)
        {
            if (ModelState.IsValid)
            {             

                _contenedorTrabajo.Estadocivil.Add(estadocivil);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        // Metodo para Crear Imagen
        private void ConCreacionDeImagen(Estadocivil estadocivil)
        {
            string rutaPrincipal = _hostingEnvironment.WebRootPath;
            var archivos = HttpContext.Request.Form.Files;

            //Nueva Imagen de Estadocivil
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\estadocivil");
            var extension = Path.GetExtension(archivos[0].FileName);

            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }


        }

        // Carga El formulario de edicion 
        [HttpGet]
        public IActionResult Edit(int? EstadocivilId)
        {          
            if (EstadocivilId != null)
            {
                var estadocivil = _contenedorTrabajo.Estadocivil.Get(EstadocivilId.GetValueOrDefault());
                return View(estadocivil);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Estadocivil estadocivil)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var estadocivilDesdeDb = _contenedorTrabajo.Estadocivil.Get(estadocivil.EstadocivilId);

                if (archivos.Count() > 0)
                {

                    _contenedorTrabajo.Estadocivil.Update(estadocivil);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Aquí es cuando la imagen ya existe se conserva la misma

                }

                _contenedorTrabajo.Estadocivil.Update(estadocivil);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // Actualiza imagen que este en base de datos
        private static void EditarImagenGuardada(Estadocivil estadocivil, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos, Estadocivil estadocivilDesdeDb)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\estadocivil");
            var nuevaExtension = Path.GetExtension(archivos[0].FileName);

            //Aquí subimos nuevamente el archivo
            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }

        }       
        
        #region LLAMADAS A LA API TABLA Estadocivil
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Estadocivil.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int EstadocivilId)
        {
            var objFromDb = _contenedorTrabajo.Estadocivil.Get(EstadocivilId);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Estadocivil" });
            }
            _contenedorTrabajo.Estadocivil.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Estadocivil borrado correctamente" });
        }
        #endregion
    }
}

