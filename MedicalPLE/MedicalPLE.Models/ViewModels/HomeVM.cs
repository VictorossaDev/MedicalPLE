
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Slider { get; set; }
        public IEnumerable<Tipodoc> ListaTipodoc { get; set; }
        public IEnumerable<TipoSangre> ListaTiposangre { get; set; }
        public IEnumerable<Eps> ListaEps { get; set; }
        public IEnumerable<Paciente> ListaPaciente { get; set; }
        public IEnumerable<Articulo> ListaArticulos { get; set; }
}

}