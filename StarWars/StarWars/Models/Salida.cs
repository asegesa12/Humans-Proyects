using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StarWars.Models
{
    public class Salida
    {
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Codigo ")]
        public string CodigoEmpleado { get; set; }
        [Key, Required(ErrorMessage = "Campo Requerido"), Display(Name = "Codigo Salida ")]
        public string CodigoSalida { get; set; }
        [ Required(ErrorMessage = "Campo Requerido"), Display(Name = "Salida ")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Motivo ")]
        public string Motivo { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}