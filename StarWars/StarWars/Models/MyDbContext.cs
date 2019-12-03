using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StarWars.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("Conexion5")
        {

        }

        #region
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Departamento> departamentos { get; set; }
        public DbSet<Cargo> cargos { get; set; }
        public DbSet<Vacaciones> vacaciones { get; set; }
        public DbSet<Licencia> licencias { get; set; }
        public DbSet<Salida> salidas { get; set; }
        public DbSet<Permiso> permisos { get; set; }

        #endregion
    }
}