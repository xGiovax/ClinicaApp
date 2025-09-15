using System.ComponentModel.DataAnnotations;
namespace ClinicaApp.Models
{
    public class HistorialMedico
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Diagnostico { get; set; }

        [Required]
        [StringLength(500)]
        public string Tratamiento { get; set; }

        // Relación con Paciente
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
