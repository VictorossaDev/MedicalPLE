using MedicalPLE.AccesoDatos.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {
      // Aqui se nombran todos los repositorios 
      
        ITipodocRepository Tipodoc { get; }
        ITiposangreRepository Tiposangre { get; }
        IGeneroRepository Genero { get; }
        IEpsRepository Eps { get; }
        IDepartamentoRepository Departamento { get; }
        IEstadocivilRepository Estadocivil { get; }
        IPacienteRepository Paciente { get; }
        ICiudadRepository Ciudad { get; }    
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }
        ISliderRepository Slider { get; }
        IUsuarioRepository Usuario { get; }
        void Save();
    }
}
