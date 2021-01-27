// Tabla Independiente => Tipodoc
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
    public class TipodocController : Controller
    {
        // Instanciamos el contenedor de trabajo que es donde tenemos todos los repositorios
        private readonly IContenedorTrabajo _contenedorTrabajo;
        // En caso de que el modelo tenga un campo tipo imagen
        private readonly IWebHostEnvironment _hostingEnvironment;

        // Contructor de la clase para acceder a todas las entidades
        public TipodocController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
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
        public IActionResult Create(Tipodoc tipodoc)
        {
            if (ModelState.IsValid)
            {

                _contenedorTrabajo.Tipodoc.Add(tipodoc);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        // Metodo para Crear Imagen
        private void ConCreacionDeImagen(Tipodoc tipodoc)
        {
            string rutaPrincipal = _hostingEnvironment.WebRootPath;
            var archivos = HttpContext.Request.Form.Files;

            //Nueva Imagen de Tipodoc
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\tipodoc");
            var extension = Path.GetExtension(archivos[0].FileName);

            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }


        }

        // Carga El formulario de edicion 
        [HttpGet]
        public IActionResult Edit(int? TipodocId)
        {
            if (TipodocId != null)
            {
                var tipodoc = _contenedorTrabajo.Tipodoc.Get(TipodocId.GetValueOrDefault());
                return View(tipodoc);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tipodoc tipodoc)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var tipodocDesdeDb = _contenedorTrabajo.Tipodoc.Get(tipodoc.TipodocId);

                if (archivos.Count() > 0)
                {

                    _contenedorTrabajo.Tipodoc.Update(tipodoc);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Aquí es cuando la imagen ya existe se conserva la misma

                }

                _contenedorTrabajo.Tipodoc.Update(tipodoc);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // Actualiza imagen que este en base de datos
        private static void EditarImagenGuardada(Tipodoc tipodoc, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos, Tipodoc tipodocDesdeDb)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\tipodoc");
            var nuevaExtension = Path.GetExtension(archivos[0].FileName);

            //Aquí subimos nuevamente el archivo
            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }

        }

        #region LLAMADAS A LA API TABLA Tipodoc
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Tipodoc.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int TipodocId)
        {
            var objFromDb = _contenedorTrabajo.Tipodoc.Get(TipodocId);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Tipodoc" });
            }
            _contenedorTrabajo.Tipodoc.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Tipodoc borrado correctamente" });
        }
        #endregion
    }
}

