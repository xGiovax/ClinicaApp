using System.Collections.Generic;
using ClinicaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.Data
{
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options) : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<HistorialMedico> HistorialesMedicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración explícita de la relación Paciente-Cita
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Paciente)
                .WithMany() // Si quieres, puedes crear ICollection<Cita> en Paciente y poner WithMany(p => p.Citas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
