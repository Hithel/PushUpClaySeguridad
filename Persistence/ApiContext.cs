using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<CategoriaPersona> CategoriaPersonas { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<ContactoPersona> ContactoPersonas { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<DireccionPersona> DireccionPersonas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Programacion> Programaciones { get; set; }
        public DbSet<TipoContacto> TipoContactos { get; set; }
        public DbSet<TipoDireccion> TipoDirecciones { get; set; }
        public DbSet<TipoPersona> TipoPersonas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UsersRols { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /* dotnet ef migrations add InitialCreate --project .\Persistence\ --startup-project .\API\ --output-dir ./Data/Migrations 
         */
         /* dotnet ef database update --project .\Persistence\ --startup-project .\API\
          */
    }
