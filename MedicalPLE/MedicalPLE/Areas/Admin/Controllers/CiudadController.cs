// Tabla Dependiente => Ciudad
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
    public class CiudadController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CiudadController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironmen)
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
            CiudadVM ciudadvm = new CiudadVM()
            {
                Ciudad = new Models.Ciudad(),
                ListaDepartamento = _contenedorTrabajo.Departamento.GetListaDepartamento(),

            };
            return View(ciudadvm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CiudadVM ciudadvm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (ciudadvm.Ciudad.CiudadId == 0)
                {
 
 
                    _contenedorTrabajo.Ciudad.Add(ciudadvm.Ciudad);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        private static void CrearImagenCiudad(CiudadVM ciudadvm, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\ciudad");
            var extension = Path.GetExtension(archivos[0].FileName);

            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }

        }



        [HttpGet]
        public IActionResult Edit(int? CiudadId)
        {
            CiudadVM ciudadvm = new CiudadVM()
            {
                Ciudad = new Models.Ciudad(),
                ListaDepartamento = _contenedorTrabajo.Departamento.GetListaDepartamento(),

            };
            if (CiudadId != null)
            {
                ciudadvm.Ciudad = _contenedorTrabajo.Ciudad.Get(CiudadId.GetValueOrDefault());
            }
            return View(ciudadvm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CiudadVM ciudadvm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var ciudadDesdeDb = _contenedorTrabajo.Ciudad.Get(ciudadvm.Ciudad.CiudadId);
                if (archivos.Count() > 0)
                {
 

                    _contenedorTrabajo.Ciudad.Update(ciudadvm.Ciudad);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
 
                _contenedorTrabajo.Ciudad.Update(ciudadvm.Ciudad);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private static void EditarImagenCiudad(CiudadVM ciudadvm, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos, Models.Ciudad ciudadDesdeDb)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\ciudad");
            var extension = Path.GetExtension(archivos[0].FileName);
            var nuevaExtension = Path.GetExtension(archivos[0].FileName);

 

            //subimos nuevamente el archivo
            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }
 
        }


        [HttpDelete]
        public IActionResult Delete(int CiudadId)
        {
            var ciudadDesdeDb = _contenedorTrabajo.Ciudad.Get(CiudadId);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;

  

            if (ciudadDesdeDb == null)
            {
                return Json(new { success = false, message = "Error borrando artículo"});
            }

            _contenedorTrabajo.Ciudad.Remove(ciudadDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Ciudad borrado con éxito" });

        }


        #region LLAMADAS A LA API Ciudad
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Ciudad.GetAll(includeProperties: "Departamento") });
        }        
        #endregion

    }
}
