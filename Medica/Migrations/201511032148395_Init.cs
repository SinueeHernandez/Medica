namespace Medica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        ConsultaId = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        MedicoId = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        PacienteId = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        Fecha = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Sintomas = c.String(maxLength: 500, fixedLength: true),
                        Diagnostico = c.String(maxLength: 500, fixedLength: true),
                        Tratamiento = c.String(maxLength: 500, fixedLength: true),
                        Observaciones = c.String(maxLength: 500, fixedLength: true),
                    })
                .PrimaryKey(t => t.ConsultaId)
                .ForeignKey("dbo.Medicos", t => t.MedicoId)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId)
                .Index(t => t.MedicoId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        MedicoID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Nombre = c.String(nullable: false, maxLength: 500, fixedLength: true),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 500, fixedLength: true),
                        ApellidoMaterno = c.String(nullable: false, maxLength: 500, fixedLength: true),
                        Telefono = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        Foto = c.Binary(storeType: "image"),
                        Biografia = c.String(),
                    })
                .PrimaryKey(t => t.MedicoID);
            
            CreateTable(
                "dbo.MedicoEspecialidad",
                c => new
                    {
                        ID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        MedicoId = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                        EspecilidadId = c.Decimal(precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Especialidades", t => t.EspecilidadId)
                .ForeignKey("dbo.Medicos", t => t.MedicoId)
                .Index(t => t.MedicoId)
                .Index(t => t.EspecilidadId);
            
            CreateTable(
                "dbo.Especialidades",
                c => new
                    {
                        EspecialidadId = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Nombre = c.String(nullable: false, maxLength: 500),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EspecialidadId);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        PacienteId = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Nombres = c.String(nullable: false, maxLength: 500, fixedLength: true),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        ApellidoMaterno = c.String(maxLength: 100, fixedLength: true),
                        Telefono = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        Direccion = c.String(maxLength: 500, fixedLength: true),
                        GeneroID = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.PacienteId)
                .ForeignKey("dbo.Generos", t => t.GeneroID)
                .Index(t => t.GeneroID);
            
            CreateTable(
                "dbo.Generos",
                c => new
                    {
                        GeneroId = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Descripcion = c.String(nullable: false, maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.GeneroId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Pacientes", "GeneroID", "dbo.Generos");
            DropForeignKey("dbo.Consultas", "PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.MedicoEspecialidad", "MedicoId", "dbo.Medicos");
            DropForeignKey("dbo.MedicoEspecialidad", "EspecilidadId", "dbo.Especialidades");
            DropForeignKey("dbo.Consultas", "MedicoId", "dbo.Medicos");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Pacientes", new[] { "GeneroID" });
            DropIndex("dbo.MedicoEspecialidad", new[] { "EspecilidadId" });
            DropIndex("dbo.MedicoEspecialidad", new[] { "MedicoId" });
            DropIndex("dbo.Consultas", new[] { "PacienteId" });
            DropIndex("dbo.Consultas", new[] { "MedicoId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Generos");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Especialidades");
            DropTable("dbo.MedicoEspecialidad");
            DropTable("dbo.Medicos");
            DropTable("dbo.Consultas");
        }
    }
}
