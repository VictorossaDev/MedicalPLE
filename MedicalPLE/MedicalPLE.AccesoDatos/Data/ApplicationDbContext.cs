using System;
using System.Collections.Generic;
using System.Text;
using MedicalPLE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicalPLE.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

          /* En caso de querer hacer una migracion deben de existir aqui las entidades y este se debe de generar desde el
               proyecto de acceso a datos*/

          
        public DbSet<Tipodoc> Tipodoc { get; set; }

        public DbSet<TipoSangre> TipoSangre { get; set; }

        public DbSet<Eps> Eps { get; set; }

        public DbSet<Departamento> Departamento { get; set; }

        public DbSet<EstadoCivil> EstadoCivil { get; set; }

        public DbSet<Genero> Genero { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Ciudad> Ciudad { get; set; }
   


         public DbSet<Categoria> Categoria { get; set; }
         public DbSet<Articulo> Articulo { get; set; }
         public DbSet<Slider> Slider { get; set; }
         public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
