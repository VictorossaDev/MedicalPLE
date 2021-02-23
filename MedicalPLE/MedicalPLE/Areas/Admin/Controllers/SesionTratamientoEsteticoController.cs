// Tabla Dependiente => SesionTratamientoEstetico
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
    public class SesionTratamientoEsteticoController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SesionTratamientoEsteticoController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironmen)
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
            SesionTratamientoEsteticoVM sesiontratamientoesteticovm = new SesionTratamientoEsteticoVM()
            {
                SesionTratamientoEstetico = new Models.SesionTratamientoEstetico(),
                ListaPacienteEstetica = _contenedorTrabajo.PacienteEstetica.GetListaPacienteEstetica(),

            };
            return View(sesiontratamientoesteticovm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SesionTratamientoEsteticoVM sesiontratamientoesteticovm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (sesiontratamientoesteticovm.SesionTratamientoEstetico.SesionTratamientoEsteticoId == 0)
                {
 
                    sesiontratamientoesteticovm.SesionTratamientoEstetico.FechaSesion = DateTime.Now; 
                    _contenedorTrabajo.SesionTratamientoEstetico.Add(sesiontratamientoesteticovm.SesionTratamientoEstetico);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        private static void CrearImagenSesionTratamientoEstetico(SesionTratamientoEsteticoVM sesiontratamientoesteticovm, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\sesiontratamientoestetico");
            var extension = Path.GetExtension(archivos[0].FileName);

            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }

        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            SesionTratamientoEsteticoVM sesiontratamientoesteticovm = new SesionTratamientoEsteticoVM()
            {
                SesionTratamientoEstetico = new Models.SesionTratamientoEstetico(),
                ListaPacienteEstetica = _contenedorTrabajo.PacienteEstetica.GetListaPacienteEstetica(),

            };
            if (id != null)
            {
                sesiontratamientoesteticovm.SesionTratamientoEstetico = _contenedorTrabajo.SesionTratamientoEstetico.Get(id.GetValueOrDefault());
            }
            return View(sesiontratamientoesteticovm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SesionTratamientoEsteticoVM sesiontratamientoesteticovm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var sesiontratamientoesteticoDesdeDb = _contenedorTrabajo.SesionTratamientoEstetico.Get(sesiontratamientoesteticovm.SesionTratamientoEstetico.SesionTratamientoEsteticoId);
                if (archivos.Count() > 0)
                {
 
                    sesiontratamientoesteticovm.SesionTratamientoEstetico.FechaSesion = DateTime.Now;
                    _contenedorTrabajo.SesionTratamientoEstetico.Update(sesiontratamientoesteticovm.SesionTratamientoEstetico);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
 
                _contenedorTrabajo.SesionTratamientoEstetico.Update(sesiontratamientoesteticovm.SesionTratamientoEstetico);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private static void EditarImagenSesionTratamientoEstetico(SesionTratamientoEsteticoVM sesiontratamientoesteticovm, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos, Models.SesionTratamientoEstetico sesiontratamientoesteticoDesdeDb)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\sesiontratamientoestetico");
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
            var sesiontratamientoesteticoDesdeDb = _contenedorTrabajo.SesionTratamientoEstetico.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;

  

            if (sesiontratamientoesteticoDesdeDb == null)
            {
                return Json(new { success = false, message = "Error borrando artículo"});
            }

            _contenedorTrabajo.SesionTratamientoEstetico.Remove(sesiontratamientoesteticoDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "SesionTratamientoEstetico borrado con éxito" });

        }


        #region LLAMADAS A LA API SesionTratamientoEstetico
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.SesionTratamientoEstetico.GetAll(includeProperties: "PacienteEstetica") });
        }        
        #endregion

    }
}
