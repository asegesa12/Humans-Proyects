using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StarWars.Models
{
    public class Departamento
    {
        [Key, Required(ErrorMessage = "Campo Requerido"), Display(Name = "Codigo de Departamento")]
        public string codigodepartamento { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Nmbre de Departamento")]
        public string nombredepartamento { get; set; }
    }
}
