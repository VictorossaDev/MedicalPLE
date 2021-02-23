// Tabla Independiente => TratamientosEsteticos
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
    public class TratamientosEsteticosController : Controller
    {
        // Instanciamos el contenedor de trabajo que es donde tenemos todos los repositorios
        private readonly IContenedorTrabajo _contenedorTrabajo;
        // En caso de que el modelo tenga un campo tipo imagen
        private readonly IWebHostEnvironment _hostingEnvironment;

        // Contructor de la clase para acceder a todas las entidades
        public TratamientosEsteticosController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironment)
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
        public IActionResult Create(TratamientosEsteticos tratamientosesteticos)
        {
            if (ModelState.IsValid)
            {             

                _contenedorTrabajo.TratamientosEsteticos.Add(tratamientosesteticos);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        // Metodo para Crear Imagen
        private void ConCreacionDeImagen(TratamientosEsteticos tratamientosesteticos)
        {
            string rutaPrincipal = _hostingEnvironment.WebRootPath;
            var archivos = HttpContext.Request.Form.Files;

            //Nueva Imagen de TratamientosEsteticos
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\tratamientosesteticos");
            var extension = Path.GetExtension(archivos[0].FileName);

            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }


        }

        // Carga El Formulario de Edicion por convencion el parametro debera llamarce id si que si....
        [HttpGet]
        public IActionResult Edit(int? id)
        {          
            if (id != null)
            {
                var tratamientosesteticos = _contenedorTrabajo.TratamientosEsteticos.Get(id.GetValueOrDefault());
                return View(tratamientosesteticos);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TratamientosEsteticos tratamientosesteticos)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var tratamientosesteticosDesdeDb = _contenedorTrabajo.TratamientosEsteticos.Get(tratamientosesteticos.TratamientoEsteticoId);

                if (archivos.Count() > 0)
                {

                    _contenedorTrabajo.TratamientosEsteticos.Update(tratamientosesteticos);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Aquí es cuando la imagen ya existe se conserva la misma

                }

                _contenedorTrabajo.TratamientosEsteticos.Update(tratamientosesteticos);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // Actualiza imagen que este en base de datos
        private static void EditarImagenGuardada(TratamientosEsteticos tratamientosesteticos, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos, TratamientosEsteticos tratamientosesteticosDesdeDb)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\tratamientosesteticos");
            var nuevaExtension = Path.GetExtension(archivos[0].FileName);

            //Aquí subimos nuevamente el archivo
            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }

        }       
        
        #region LLAMADAS A LA API TABLA TratamientosEsteticos
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.TratamientosEsteticos.GetAll() });
        }
        // Para la eliminacion por convencion el parametro debera llamarce id si que si....
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.TratamientosEsteticos.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando TratamientosEsteticos" });
            }
            _contenedorTrabajo.TratamientosEsteticos.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "TratamientosEsteticos borrado correctamente" });
        }
        #endregion
    }
}

