// Tabla Dependiente ImagenesSesion
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalPLE.Models;
using MedicalPLE.AccesoDatos.Data.Repository;

namespace MedicalPLE.AccesoDatos.Data
{
    public class ImagenesSesionRepository : Repository<ImagenesSesion>, IImagenesSesionRepository
    {
        private readonly ApplicationDbContext _db;

        public ImagenesSesionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Para implementar en un combobox una seleccion de elementos de la entidad, nombre y el value
        public IEnumerable<SelectListItem> GetListaImagenesSesion()
        {
            return _db.ImagenesSesion.Select(i => new SelectListItem() { 
                Text = i.DescripcionImagen,
                Value = i.ImagenesSesionId.ToString()
            });
        }
        // Para actualizacion singular de la entidad, por buena practica debe de estar aqui y no en  el generico
        public void Update(ImagenesSesion imagenessesion)
        {
            var objDesdeDb = _db.ImagenesSesion.FirstOrDefault(s => s.ImagenesSesionId == imagenessesion.ImagenesSesionId);
            objDesdeDb.DescripcionImagen = imagenessesion.DescripcionImagen;
            objDesdeDb.Imagen = imagenessesion.Imagen;
            objDesdeDb.SesionTratamientoEsteticoId = imagenessesion.SesionTratamientoEsteticoId;

            _db.SaveChanges();
        }
    }
}


