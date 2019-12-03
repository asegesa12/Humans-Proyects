using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StarWars.Models
{
    public class Cargo
    {
        [Key, Required(ErrorMessage = "Campo Requerido"), Display(Name = "Codigo de cargo")]
        public string codigocargo { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Nmbre de cargo")]
        public string nombrecargo { get; set; }
    }
}