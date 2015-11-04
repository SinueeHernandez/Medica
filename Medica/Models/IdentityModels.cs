using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Medica.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MedicaConect", throwIfV1Schema: false)
            
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ///Para las tablas de Usuarios nativas de Identity EntityFramework
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });


            modelBuilder.Entity<Consulta>()
                .Property(e => e.ConsultaId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Consulta>()
                .Property(e => e.MedicoId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Consulta>()
                .Property(e => e.PacienteId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Consulta>()
                .Property(e => e.Sintomas)
                .IsFixedLength();

            modelBuilder.Entity<Consulta>()
                .Property(e => e.Diagnostico)
                .IsFixedLength();

            modelBuilder.Entity<Consulta>()
                .Property(e => e.Tratamiento)
                .IsFixedLength();

            modelBuilder.Entity<Consulta>()
                .Property(e => e.Observaciones)
                .IsFixedLength();

            modelBuilder.Entity<Especialidades>()
                .Property(e => e.EspecialidadId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Especialidades>()
                .HasMany(e => e.MedicoEspecialidad)
                .WithOptional(e => e.Especialidades)
                .HasForeignKey(e => e.EspecilidadId);

            modelBuilder.Entity<Genero>()
                .Property(e => e.GeneroId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Genero>()
                .Property(e => e.Descripcion)
                .IsFixedLength();

            modelBuilder.Entity<Genero>()
                .HasMany(e => e.Paciente)
                .WithRequired(e => e.Genero)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medico>()
                .Property(e => e.MedicoID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Nombre)
                .IsFixedLength();

            modelBuilder.Entity<Medico>()
                .Property(e => e.ApellidoPaterno)
                .IsFixedLength();

            modelBuilder.Entity<Medico>()
                .Property(e => e.ApellidoMaterno)
                .IsFixedLength();

            modelBuilder.Entity<Medico>()
                .Property(e => e.Telefono)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Medico>()
                .Property(e => e.Foto)
                .IsVariableLength()
                .HasColumnType("image");

            modelBuilder.Entity<Medico>()
                .HasMany(e => e.Consulta)
                .WithRequired(e => e.Medico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MedicoEspecialidad>()
                .Property(e => e.ID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MedicoEspecialidad>()
                .Property(e => e.MedicoId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MedicoEspecialidad>()
                .Property(e => e.EspecilidadId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.PacienteId)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Nombres)
                .IsFixedLength();

            modelBuilder.Entity<Paciente>()
                .Property(e => e.ApellidoPaterno)
                .IsFixedLength();

            modelBuilder.Entity<Paciente>()
                .Property(e => e.ApellidoMaterno)
                .IsFixedLength();

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Telefono)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Paciente>()
                .Property(e => e.Direccion)
                .IsFixedLength();

            modelBuilder.Entity<Paciente>()
                .Property(e => e.GeneroID)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Paciente>()
                .HasMany(e => e.Consulta)
                .WithRequired(e => e.Paciente)
                .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }
}