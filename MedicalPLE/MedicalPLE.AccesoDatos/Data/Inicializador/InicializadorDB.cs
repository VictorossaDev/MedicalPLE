
using MedicalPLE.Models;
using MedicalPLE.Utilidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MedicalPLE.AccesoDatos.Data.Inicializador
{
    public class InicializadorDB : IInicializadorDB
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InicializadorDB(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public void Inicializar()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {
                
            }

            if (_db.Roles.Any(ro => ro.Name == CNT.Admin)) return;           

            _roleManager.CreateAsync(new IdentityRole(CNT.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Usuario)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "victorossa1675@hotmail.com",
                Email = "victorossa1675@hotmail.com",
                EmailConfirmed = true,
                Nombre = "Victorossa"
            }, "Admin*123").GetAwaiter().GetResult();

            ApplicationUser usuario = _db.ApplicationUser
                .Where(us => us.Email == "victorossa1675@hotmail.com")
                .FirstOrDefault();
            _userManager.AddToRoleAsync(usuario, CNT.Admin).GetAwaiter().GetResult();
        
        }
    }
}
