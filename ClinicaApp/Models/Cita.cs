using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaApp.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(200)]
        public string Motivo { get; set; }

        // Relación con Paciente
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
