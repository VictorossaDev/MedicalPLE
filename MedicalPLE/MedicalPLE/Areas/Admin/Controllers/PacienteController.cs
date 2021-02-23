// Tabla Dependiente => Paciente
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
    public class PacienteController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PacienteController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostingEnvironmen)
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
            PacienteVM pacientevm = new PacienteVM()
            {
                Paciente = new Models.Paciente(),
                ListaTipodoc = _contenedorTrabajo.Tipodoc.GetListaTipodoc(),
                ListaEstadoCivil = _contenedorTrabajo.EstadoCivil.GetListaEstadoCivil(),
                ListaGenero = _contenedorTrabajo.Genero.GetListaGenero(),
                ListaTipoSangre = _contenedorTrabajo.TipoSangre.GetListaTipoSangre(),
                ListaEps = _contenedorTrabajo.Eps.GetListaEps(),
                ListaCiudad = _contenedorTrabajo.Ciudad.GetListaCiudad(),
                ListaDepartamento = _contenedorTrabajo.Departamento.GetListaDepartamento(),
            };
            return View(pacientevm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PacienteVM pacientevm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                if (pacientevm.Paciente.PacienteId == 0)
                {
 
 
                    _contenedorTrabajo.Paciente.Add(pacientevm.Paciente);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        private static void CrearImagenPaciente(PacienteVM pacientevm, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\paciente");
            var extension = Path.GetExtension(archivos[0].FileName);

            using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
            {
                archivos[0].CopyTo(fileStreams);
            }

        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            PacienteVM pacientevm = new PacienteVM()
            {
                Paciente = new Models.Paciente(),
                ListaTipodoc = _contenedorTrabajo.Tipodoc.GetListaTipodoc(),
                ListaEstadoCivil = _contenedorTrabajo.EstadoCivil.GetListaEstadoCivil(),
                ListaGenero = _contenedorTrabajo.Genero.GetListaGenero(),
                ListaTipoSangre = _contenedorTrabajo.TipoSangre.GetListaTipoSangre(),
                ListaEps = _contenedorTrabajo.Eps.GetListaEps(),
                ListaCiudad = _contenedorTrabajo.Ciudad.GetListaCiudad(),
                ListaDepartamento = _contenedorTrabajo.Departamento.GetListaDepartamento(),

            };
            if (id != null)
            {
                pacientevm.Paciente = _contenedorTrabajo.Paciente.Get(id.GetValueOrDefault());
            }
            return View(pacientevm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PacienteVM pacientevm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var pacienteDesdeDb = _contenedorTrabajo.Paciente.Get(pacientevm.Paciente.PacienteId);
                if (archivos.Count() > 0)
                {
 

                    _contenedorTrabajo.Paciente.Update(pacientevm.Paciente);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
 
                _contenedorTrabajo.Paciente.Update(pacientevm.Paciente);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private static void EditarImagenPaciente(PacienteVM pacientevm, string rutaPrincipal, Microsoft.AspNetCore.Http.IFormFileCollection archivos, Models.Paciente pacienteDesdeDb)
        {
            string nombreArchivo = Guid.NewGuid().ToString();
            var subidas = Path.Combine(rutaPrincipal, @"imagenes\paciente");
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
            var pacienteDesdeDb = _contenedorTrabajo.Paciente.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;

  

            if (pacienteDesdeDb == null)
            {
                return Json(new { success = false, message = "Error borrando artículo"});
            }

            _contenedorTrabajo.Paciente.Remove(pacienteDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Paciente borrado con éxito" });

        }


        #region LLAMADAS A LA API Paciente
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Paciente.GetAll(includeProperties: "Tipodoc,EstadoCivil,Genero,TipoSangre,Eps,Ciudad") });
        }        
        #endregion

    }
}
