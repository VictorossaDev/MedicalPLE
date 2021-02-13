using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedicalPLE.Models;
using MedicalPLE.AccesoDatos.Data.Repository;
using MedicalPLE.Models.ViewModels;

namespace MedicalPLE.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            HomeVM homeVm = new HomeVM()
            {
                Slider = _contenedorTrabajo.Slider.GetAll(),
                ListaTipodoc = _contenedorTrabajo.Tipodoc.GetAll(),
                ListaTiposangre = _contenedorTrabajo.Tiposangre.GetAll(),
                ListaGenero = _contenedorTrabajo.Genero.GetAll(),
                ListaEps = _contenedorTrabajo.Eps.GetAll(),
                ListaDepartamento = _contenedorTrabajo.Departamento.GetAll(),
                ListaEstadocivil = _contenedorTrabajo.Estadocivil.GetAll(),
                ListaPaciente = _contenedorTrabajo.Paciente.GetAll(),
                ListaCiudad = _contenedorTrabajo.Ciudad.GetAll(),
                ListaArticulos = _contenedorTrabajo.Articulo.GetAll()
            };
            return View(homeVm);
        }

        public IActionResult Error()
        {
            return View();
        }

        // OPCIONAL
        public IActionResult Details(int id)
        {
            var articuloDesdeDb = _contenedorTrabajo.Articulo.GetFirstOrDefault(a => a.Id == id);
            return View(articuloDesdeDb);
        }       
    }
}