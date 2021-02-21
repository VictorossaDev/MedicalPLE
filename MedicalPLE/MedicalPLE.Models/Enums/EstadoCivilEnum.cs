using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalPLE.Models.Enums
{
    public enum EstadoCivilEnum
    {
        [Display(Name = "Estado Civil Soltero")]
        Soltero,
        [Display(Name = "Estado Civil Casado")]
        Casado,
        [Display(Name = "Estado Civil Divorsiado")]
        Divorsiado,
        [Display(Name = "Estado Civil Union Libre")]
        UnionLibre
    }
}
