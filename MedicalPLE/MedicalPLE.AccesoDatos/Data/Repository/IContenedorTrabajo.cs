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
        ITipoSangreRepository TipoSangre { get; }
        IEpsRepository Eps { get; }
        IDepartamentoRepository Departamento { get; }
        IEstadoCivilRepository EstadoCivil { get; }
        IGeneroRepository Genero { get; }
        IPacienteRepository Paciente { get; }
        ICiudadRepository Ciudad { get; }    
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }
        ISliderRepository Slider { get; }
        IUsuarioRepository Usuario { get; }
        void Save();
    }
}
