// Tabla Independiente => Genero
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
    public class GeneroController : Controller
    {
        // Instanciamos el contenedor de trabajo que es donde tenemos todos los repositorios
        private readonly IContenedorTrabajo _contenedorTrabajo;
        // En caso de que el modelo tenga un campo tipo imagen
        private readonly IWebHostEnvironment _hostingEnvironment;

        // Contructor de la clase para acceder a todas las entidades
        public GeneroController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
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
        public IActionResult Create(Genero genero)
        {
            if (ModelState.IsValid)
            {             

                _contenedorTrabajo.Genero.Add(genero);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        // Metodo para Crear Imagen
        private void ConCreacionDeImagen(Genero genero)
        {
            string rutaPrincipal = _hostingEnvironment.WebRootPath;
            var archivos = HttpContext.Request.Form.Files;

            //Nueva Imagen de Genero
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\genero");
            var extension = Path.GetExtension(archivos[0].FileName);

            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }


        }

        // Carga El formulario de edicion 
        [HttpGet]
        public IActionResult Edit(int? GeneroId)
        {          
            if (GeneroId != null)
            {
                var genero = _contenedorTrabajo.Genero.Get(GeneroId.GetValueOrDefault());
                return View(genero);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genero genero)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var generoDesdeDb = _contenedorTrabajo.Genero.Get(genero.GeneroId);

                if (archivos.Count() > 0)
                {

                    _contenedorTrabajo.Genero.Update(genero);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Aquí es cuando la imagen ya existe se conserva la misma

                }

                _contenedorTrabajo.Genero.Update(genero);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // Actualiza imagen que este en base de datos
        private static void EditarImagenGuardada(Genero genero, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos, Genero generoDesdeDb)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\genero");
            var nuevaExtension = Path.GetExtension(archivos[0].FileName);

            //Aquí subimos nuevamente el archivo
            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }

        }       
        
        #region LLAMADAS A LA API TABLA Genero
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Genero.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int GeneroId)
        {
            var objFromDb = _contenedorTrabajo.Genero.Get(GeneroId);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Genero" });
            }
            _contenedorTrabajo.Genero.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Genero borrado correctamente" });
        }
        #endregion
    }
}

