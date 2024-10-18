using Core.Entities;
using PruebaTecnicaAPI.Modelos;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PruebaTecnicaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aula>()
                .HasOne(a => a.Docente)
                .WithMany(d => d.Aulas)
                .HasForeignKey(a => a.DocenteID);

            modelBuilder.Entity<Alumno>()
                .HasOne(a => a.Aula)
                .WithMany(au => au.Alumnos)
                .HasForeignKey(a => a.AulaID);
        }
    }
}
