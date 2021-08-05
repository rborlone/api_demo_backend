using ApiDemo.Infra.Mappings;
using APIDemo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ApiDemo.Infra
{
    /// <summary>
    /// Clase Contexto de Base de Datos.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DbSet<LogApi> LogApi { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Constructor de Clase.
        /// </summary>
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
        {
        }

        /// <summary>
        /// Metodo que Sobreescribe a la clase base al generar el modelo y aplica los mappings.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Se debe tener ojo aqui, si se agrega algun nuevo mapping por favor agregarlo en orden alfabetico
            //y se debe tener en consideracion los cambios que se hagan a la base de datos
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LogApiConfiguration());
            modelBuilder.ApplyConfiguration(new TareaConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        /// <summary>
        /// Metodo que Sobreescribe a la clase basse para configurar el contexto y la configuración correspondiente al ConnectionString.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //get the configuration from the app settings
           //var config = new ConfigurationBuilder()
           //    .SetBasePath(@Directory.GetCurrentDirectory())
           //    .AddJsonFile("appsettings.json")
           //    .Build();

           // optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
