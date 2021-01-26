//  Dependiente => Ciudad
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MedicalPLE.AccesoDatos.Data.Repository;
using MedicalPLE.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

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
        // --===============================================================--
        //      Carga Vista Ciudad

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       //--===============================================================--
       //     Carga Ciudad

        [HttpGet]
        public IActionResult Create()
        {
            CiudadVM ciudadvm = new CiudadVM()
            {
                Ciudad = new Models.Ciudad(),
                ListaDepartamento = _contenedorTrabajo.Departamento.GetListaDepartamento(),
            };
            return View(ciudadvm );
        }

        //--===============================================================--
        //     Crear Ciudad

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CiudadVM ciudadVM)
        {

            // Valida el Modelo para hacer un primer filtro
            if (ModelState.IsValid)
            {
       //------------------------------------------------------------------------------------------------------------------------------------------------------

      //------------------------------------------------------------------------------------------------------------------------------------------------------

      //------------------------------------------------------------------------------------------------------------------------------------------------------
                    _contenedorTrabajo.Ciudad.Add(ciudadVM.Ciudad);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));                
            }
            return View();
        }

        //--===============================================================--
        //     Editar1 Ciudad

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
                ciudadvm.Ciudad= _contenedorTrabajo.Ciudad.Get(CiudadId.GetValueOrDefault());
            }
            return View(ciudadvm);
        }

        //--===============================================================--
        //     Editar2 Ciudad

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CiudadVM ciudadVM)
        {
            if (ModelState.IsValid)
            {
      //------------------------------------------------------------------------------------------------------------------------------------------------------

      //------------------------------------------------------------------------------------------------------------------------------------------------------

      //------------------------------------------------------------------------------------------------------------------------------------------------------

     //------------------------------------------------------------------------------------------------------------------------------------------------------

                _contenedorTrabajo.Ciudad.Update(ciudadVM.Ciudad);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        [HttpDelete]
        public IActionResult Delete(int CiudadId)
        {

            var ciudadDesdeDb = _contenedorTrabajo.Ciudad.Get(CiudadId);
       //------------------------------------------------------------------------------------------------------------------------------------------------------

       //------------------------------------------------------------------------------------------------------------------------------------------------------
            _contenedorTrabajo.Ciudad.Remove(ciudadDesdeDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Ciudad borrado con éxito" });

        }


        #region LLAMADAS A LA API
        // Para poder utilizar Datatables y consultar estos por ajax
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Ciudad.GetAll(includeProperties: "Categoria") });
        }
        #endregion        
    }
}


