using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StarWars.Models
{
    public class Licencia
    {
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Codigo ")]
        public string CodigoEmpleado { get; set; }
        [Key,Required(ErrorMessage = "Campo Requerido"), Display(Name = "Codigo Fecha")]
        public string CodigoFecha { get; set; }
        [ Required(ErrorMessage = "Campo Requerido"), Display(Name = "Fecha de entrada ")]
        public Nullable<System.DateTime> FechaEntrada { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Fecha de salida ")]
        public Nullable<System.DateTime> FechaSalida { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Comentario ")]
        public string Comentario { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}