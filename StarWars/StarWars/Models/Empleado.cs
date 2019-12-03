using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StarWars.Models
{
    public class Empleado
    {
        [Key, Required(ErrorMessage = "Campo Requerido"), Display(Name = "Codigo ")]
        public string CodigoEmpleado { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Departamento")]
        public string codigoDepartamento { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Cargo")]
        public string codigocargo { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Fecha")]
        public Nullable<System.DateTime> Fecha { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Salario")]
        public int Salario { get; set; }
        [Required(ErrorMessage = "Campo Requerido"), Display(Name = "Estatus")]
        public string Estatus { get; set; }

        public virtual Departamento Depto { get; set; }
        public virtual Cargo Carg { get; set; }
    }
}