// Tabla Dependiente => ImagenesSesion
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
    public class ImagenesSesionController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImagenesSesionController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironmen)
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
            ImagenesSesionVM imagenessesionvm = new ImagenesSesionVM()
            {
                ImagenesSesion = new Models.ImagenesSesion(),
                ListaSesionTratamientoEstetico = _contenedorTrabajo.SesionTratamientoEstetico.GetListaSesionTratamientoEstetico(),

            };
            return View(imagenessesionvm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ImagenesSesionVM imagenessesionvm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (imagenessesionvm.ImagenesSesion.ImagenesSesionId == 0)
                {
                    CrearImagenImagenesSesion(imagenessesionvm, rutaPrincipal, archivos); 
 
                    _contenedorTrabajo.ImagenesSesion.Add(imagenessesionvm.ImagenesSesion);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        private static void CrearImagenImagenesSesion(ImagenesSesionVM imagenessesionvm, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\imagenessesion");
            var extension = Path.GetExtension(archivos[0].FileName);

            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }
            imagenessesionvm.ImagenesSesion.Imagen = @"\imagenes\imagenessesion\" + nombreArchivo + extension;
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ImagenesSesionVM imagenessesionvm = new ImagenesSesionVM()
            {
                ImagenesSesion = new Models.ImagenesSesion(),
                ListaSesionTratamientoEstetico = _contenedorTrabajo.SesionTratamientoEstetico.GetListaSesionTratamientoEstetico(),

            };
            if (id != null)
            {
                imagenessesionvm.ImagenesSesion = _contenedorTrabajo.ImagenesSesion.Get(id.GetValueOrDefault());
            }
            return View(imagenessesionvm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ImagenesSesionVM imagenessesionvm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var imagenessesionDesdeDb = _contenedorTrabajo.ImagenesSesion.Get(imagenessesionvm.ImagenesSesion.ImagenesSesionId);
                if (archivos.Count() > 0)
                {
                    EditarImagenImagenesSesion(imagenessesionvm, rutaPrincipal, archivos, imagenessesionDesdeDb); 

                    _contenedorTrabajo.ImagenesSesion.Update(imagenessesionvm.ImagenesSesion);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    imagenessesionvm.ImagenesSesion.Imagen = imagenessesionDesdeDb.Imagen;
                } 
                _contenedorTrabajo.ImagenesSesion.Update(imagenessesionvm.ImagenesSesion);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private static void EditarImagenImagenesSesion(ImagenesSesionVM imagenessesionvm, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos, Models.ImagenesSesion imagenessesionDesdeDb)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\imagenessesion");
            var extension = Path.GetExtension(archivos[0].FileName);
            var nuevaExtension = Path.GetExtension(archivos[0].FileName);

            var rutaImagen = Path.Combine(rutaPrincipal, imagenessesionDesdeDb.Imagen.TrimStart('\\'));
            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }
 

            //subimos nuevamente el archivo
            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }
            imagenessesionvm.ImagenesSesion.Imagen = @"\imagenes\imagenessesion\" + nombreArchivo + nuevaExtension; 
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var imagenessesionDesdeDb = _contenedorTrabajo.ImagenesSesion.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;

            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, imagenessesionDesdeDb.Imagen.TrimStart('\\'));

            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }  

            if (imagenessesionDesdeDb == null)
            {
                return Json(new { success = false, message = "Error borrando artículo"});
            }

            _contenedorTrabajo.ImagenesSesion.Remove(imagenessesionDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "ImagenesSesion borrado con éxito" });

        }


        #region LLAMADAS A LA API ImagenesSesion
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.ImagenesSesion.GetAll(includeProperties: "SesionTratamientoEstetico") });
        }        
        #endregion

    }
}
