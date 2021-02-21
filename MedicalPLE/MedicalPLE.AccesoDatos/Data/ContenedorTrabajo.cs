using MedicalPLE.AccesoDatos.Data.Repository;
using MedicalPLE.AccesoDatos.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

/* Se busca implementar el repositorio, esto es ideal para arquitecturas robustas donde tendremos muchos archivos y
 podemos hacer en un solo lugar los cambios */
namespace MedicalPLE.AccesoDatos.Data
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;
        // Constructor de la clase aplicando el archivo dbcontext o contexto de la base de datos
        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            // Se pasan cada una de las entidades en el constructor pasandole el contexto de datos
            
           Tipodoc = new TipodocRepository(_db);
           TipoSangre = new TipoSangreRepository(_db);
           Eps = new EpsRepository(_db);
           Departamento = new DepartamentoRepository(_db);
           EstadoCivil = new EstadoCivilRepository(_db);
           Genero = new GeneroRepository(_db);
           Paciente = new PacienteRepository(_db);
           Ciudad = new CiudadRepository(_db);

            Categoria = new CategoriaRepository(_db);
            Articulo = new ArticuloRepository(_db);
            Slider = new SliderRepository(_db);
            Usuario = new UsuarioRepository(_db);
        }
            
           public ITipodocRepository Tipodoc { get; private set; }
           public ITipoSangreRepository TipoSangre { get; private set; }
           public IEpsRepository Eps { get; private set; }
           public IDepartamentoRepository Departamento { get; private set; }
           public IEstadoCivilRepository EstadoCivil { get; private set; }
           public IGeneroRepository Genero { get; private set; }
           public IPacienteRepository Paciente { get; private set; }
           public ICiudadRepository Ciudad { get; private set; }
    
             public ICategoriaRepository Categoria { get; private set; }
             public IArticuloRepository Articulo { get; private set; }      
             public ISliderRepository Slider { get; private set; }
             public IUsuarioRepository Usuario { get; private set; }        
             public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}


// --==================================================================--

