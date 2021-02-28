// Tabla Dependiente => PacienteEstetica
using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using MedicalPLE.Models.ViewModels;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PacienteEsteticaController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PacienteEsteticaController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironmen)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironmen;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            PacienteEsteticaVM pacienteesteticavm = new PacienteEsteticaVM()
            {
                PacienteEstetica = new Models.PacienteEstetica(),
                ListaTipodoc = _contenedorTrabajo.Tipodoc.GetListaTipodoc(),
                ListaGenero = _contenedorTrabajo.Genero.GetListaGenero(),
            };
            return View(pacienteesteticavm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PacienteEsteticaVM pacienteesteticavm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (pacienteesteticavm.PacienteEstetica.PacienteEsteticaId == 0)
                {
 
 
                    _contenedorTrabajo.PacienteEstetica.Add(pacienteesteticavm.PacienteEstetica);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        private static void CrearImagenPacienteEstetica(PacienteEsteticaVM pacienteesteticavm, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\pacienteestetica");
            var extension = Path.GetExtension(archivos[0].FileName);

            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }

        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            PacienteEsteticaVM pacienteesteticavm = new PacienteEsteticaVM()
            {
                PacienteEstetica = new Models.PacienteEstetica(),
                ListaTipodoc = _contenedorTrabajo.Tipodoc.GetListaTipodoc(),
                ListaGenero = _contenedorTrabajo.Genero.GetListaGenero(),

            };
            if (id != null)
            {
                pacienteesteticavm.PacienteEstetica = _contenedorTrabajo.PacienteEstetica.Get(id.GetValueOrDefault());
            }
            return View(pacienteesteticavm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PacienteEsteticaVM pacienteesteticavm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var pacienteesteticaDesdeDb = _contenedorTrabajo.PacienteEstetica.Get(pacienteesteticavm.PacienteEstetica.PacienteEsteticaId);
                if (archivos.Count() > 0)
                {
 

                    _contenedorTrabajo.PacienteEstetica.Update(pacienteesteticavm.PacienteEstetica);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
 
                _contenedorTrabajo.PacienteEstetica.Update(pacienteesteticavm.PacienteEstetica);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private static void EditarImagenPacienteEstetica(PacienteEsteticaVM pacienteesteticavm, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos, Models.PacienteEstetica pacienteesteticaDesdeDb)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\pacienteestetica");
            var extension = Path.GetExtension(archivos[0].FileName);
            var nuevaExtension = Path.GetExtension(archivos[0].FileName);

 

            //subimos nuevamente el archivo
            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }
 
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var pacienteesteticaDesdeDb = _contenedorTrabajo.PacienteEstetica.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;

  

            if (pacienteesteticaDesdeDb == null)
            {
                return Json(new { success = false, message = "Error borrando artículo"});
            }

            _contenedorTrabajo.PacienteEstetica.Remove(pacienteesteticaDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "PacienteEstetica borrado con éxito" });

        }


        #region LLAMADAS A LA API PacienteEstetica
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.PacienteEstetica.GetAll(includeProperties: "Tipodoc,Genero") });
        }        
        #endregion

    }
}
