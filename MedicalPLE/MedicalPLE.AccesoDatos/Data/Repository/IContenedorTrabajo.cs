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
        IEstadoCivilRepository EstadoCivil { get; }
        IGeneroRepository Genero { get; }
        ITratamientosEsteticosRepository TratamientosEsteticos { get; }
        IDepartamentoRepository Departamento { get; }
        IPacienteRepository Paciente { get; }
        ISesionTratamientoEsteticoRepository SesionTratamientoEstetico { get; }
        IImagenesSesionRepository ImagenesSesion { get; }
        IPacienteEsteticaRepository PacienteEstetica { get; }
        ICiudadRepository Ciudad { get; }    
        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }
        ISliderRepository Slider { get; }
        IUsuarioRepository Usuario { get; }
        void Save();
    }
}
