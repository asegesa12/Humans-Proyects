namespace StarWars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class query : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cargoes",
                c => new
                    {
                        codigocargo = c.String(nullable: false, maxLength: 128),
                        nombrecargo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.codigocargo);
            
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        codigodepartamento = c.String(nullable: false, maxLength: 128),
                        nombredepartamento = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.codigodepartamento);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        CodigoEmpleado = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        codigoDepartamento = c.String(nullable: false, maxLength: 128),
                        codigocargo = c.String(nullable: false, maxLength: 128),
                        Fecha = c.DateTime(nullable: false),
                        Salario = c.Int(nullable: false),
                        Estatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoEmpleado)
                .ForeignKey("dbo.Cargoes", t => t.codigocargo, cascadeDelete: true)
                .ForeignKey("dbo.Departamentoes", t => t.codigoDepartamento, cascadeDelete: true)
                .Index(t => t.codigoDepartamento)
                .Index(t => t.codigocargo);
            
            CreateTable(
                "dbo.Licencias",
                c => new
                    {
                        CodigoFecha = c.String(nullable: false, maxLength: 128),
                        CodigoEmpleado = c.String(nullable: false, maxLength: 128),
                        FechaEntrada = c.DateTime(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                        Comentario = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoFecha)
                .ForeignKey("dbo.Empleadoes", t => t.CodigoEmpleado, cascadeDelete: true)
                .Index(t => t.CodigoEmpleado);
            
            CreateTable(
                "dbo.Permisoes",
                c => new
                    {
                        CodigoFecha = c.String(nullable: false, maxLength: 128),
                        CodigoEmpleado = c.String(nullable: false, maxLength: 128),
                        FechaEntrada = c.DateTime(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                        Comentario = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoFecha)
                .ForeignKey("dbo.Empleadoes", t => t.CodigoEmpleado, cascadeDelete: true)
                .Index(t => t.CodigoEmpleado);
            
            CreateTable(
                "dbo.Salidas",
                c => new
                    {
                        CodigoSalida = c.String(nullable: false, maxLength: 128),
                        CodigoEmpleado = c.String(nullable: false, maxLength: 128),
                        Tipo = c.String(nullable: false),
                        Motivo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoSalida)
                .ForeignKey("dbo.Empleadoes", t => t.CodigoEmpleado, cascadeDelete: true)
                .Index(t => t.CodigoEmpleado);
            
            CreateTable(
                "dbo.Vacaciones",
                c => new
                    {
                        CodigoFecha = c.String(nullable: false, maxLength: 128),
                        CodigoEmpleado = c.String(nullable: false, maxLength: 128),
                        FechaEntrada = c.DateTime(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                        Comentario = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoFecha)
                .ForeignKey("dbo.Empleadoes", t => t.CodigoEmpleado, cascadeDelete: true)
                .Index(t => t.CodigoEmpleado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacaciones", "CodigoEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Salidas", "CodigoEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Permisoes", "CodigoEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Licencias", "CodigoEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "codigoDepartamento", "dbo.Departamentoes");
            DropForeignKey("dbo.Empleadoes", "codigocargo", "dbo.Cargoes");
            DropIndex("dbo.Vacaciones", new[] { "CodigoEmpleado" });
            DropIndex("dbo.Salidas", new[] { "CodigoEmpleado" });
            DropIndex("dbo.Permisoes", new[] { "CodigoEmpleado" });
            DropIndex("dbo.Licencias", new[] { "CodigoEmpleado" });
            DropIndex("dbo.Empleadoes", new[] { "codigocargo" });
            DropIndex("dbo.Empleadoes", new[] { "codigoDepartamento" });
            DropTable("dbo.Vacaciones");
            DropTable("dbo.Salidas");
            DropTable("dbo.Permisoes");
            DropTable("dbo.Licencias");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Departamentoes");
            DropTable("dbo.Cargoes");
        }
    }
}
