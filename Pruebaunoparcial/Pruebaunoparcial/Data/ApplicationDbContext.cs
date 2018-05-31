using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pruebaunoparcial.Models;

namespace Pruebaunoparcial.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        public DbSet<Pruebaunoparcial.Models.Usuario> Usuario { get; set; }

       

        public DbSet<Pruebaunoparcial.Models.Contrato> Contrato { get; set; }

        public DbSet<Pruebaunoparcial.Models.Empleo> Empleo { get; set; }

        public DbSet<Pruebaunoparcial.Models.Desempleado> Desempleado { get; set; }

        public DbSet<Pruebaunoparcial.Models.Usu_empleado> Usu_empleado { get; set; }

        public DbSet<Pruebaunoparcial.Models.Contacto> Contacto { get; set; }

        public DbSet<Pruebaunoparcial.Models.Empleado> Empleado { get; set; }

        public DbSet<Pruebaunoparcial.Models.Curso> Curso { get; set; }

        public DbSet<Pruebaunoparcial.Models.Usu_estudio> Usu_estudio { get; set; }

        public DbSet<Pruebaunoparcial.Models.Estudio> Estudio { get; set; }

        public DbSet<Pruebaunoparcial.Models.Discapacidad> Discapacidad { get; set; }

        public DbSet<Pruebaunoparcial.Models.Usuario_discapacidad> Usuario_discapacidad { get; set; }

    }
}
