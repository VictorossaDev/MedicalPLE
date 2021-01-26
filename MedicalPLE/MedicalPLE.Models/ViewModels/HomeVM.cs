
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Slider { get; set; }
        public IEnumerable<Tipodoc> ListaTipodoc { get; set; }
        public IEnumerable<Tiposangre> ListaTiposangre { get; set; }
        public IEnumerable<Genero> ListaGenero { get; set; }
        public IEnumerable<Eps> ListaEps { get; set; }
        public IEnumerable<Departamento> ListaDepartamento { get; set; }
        public IEnumerable<Estadocivil> ListaEstadocivil { get; set; }
        public IEnumerable<Paciente> ListaPaciente { get; set; }
        public IEnumerable<Ciudad> ListaCiudad { get; set; }    
        public IEnumerable<Articulo> ListaArticulos { get; set; }
}

}