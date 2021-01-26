using MedicalPLE.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalPLE.AccesoDatos.Data.Repository
{
    public interface IUsuarioRepository : IRepository<ApplicationUser>
    {
        // Hace el bloqueo y desbloqueo del usuario en la base de datos en el campo LockoutEnd
        void BloqueaUsuario(string IdUsuario);
        void DesbloquearUsuario(string IdUsuario);
    }
}

// --======================================================--
