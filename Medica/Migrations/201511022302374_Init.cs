namespace Medica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consulta",
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
                .ForeignKey("dbo.Medico", t => t.MedicoId)
                .ForeignKey("dbo.Paciente", t => t.PacienteId)
                .Index(t => t.MedicoId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Medico",
                c => new
                    {
                        MedicoID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Nombre = c.String(maxLength: 500, fixedLength: true),
                        ApellidoPaterno = c.String(maxLength: 500, fixedLength: true),
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
                .ForeignKey("dbo.Medico", t => t.MedicoId)
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
                "dbo.Paciente",
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
                .ForeignKey("dbo.Genero", t => t.GeneroID)
                .Index(t => t.GeneroID);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        GeneroId = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Descripcion = c.String(maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.GeneroId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Paciente", "GeneroID", "dbo.Genero");
            DropForeignKey("dbo.Consulta", "PacienteId", "dbo.Paciente");
            DropForeignKey("dbo.MedicoEspecialidad", "MedicoId", "dbo.Medico");
            DropForeignKey("dbo.MedicoEspecialidad", "EspecilidadId", "dbo.Especialidades");
            DropForeignKey("dbo.Consulta", "MedicoId", "dbo.Medico");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Paciente", new[] { "GeneroID" });
            DropIndex("dbo.MedicoEspecialidad", new[] { "EspecilidadId" });
            DropIndex("dbo.MedicoEspecialidad", new[] { "MedicoId" });
            DropIndex("dbo.Consulta", new[] { "PacienteId" });
            DropIndex("dbo.Consulta", new[] { "MedicoId" });
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Genero");
            DropTable("dbo.Paciente");
            DropTable("dbo.Especialidades");
            DropTable("dbo.MedicoEspecialidad");
            DropTable("dbo.Medico");
            DropTable("dbo.Consulta");
        }
    }
}
