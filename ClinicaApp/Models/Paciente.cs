using System.ComponentModel.DataAnnotations;

namespace ClinicaApp.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120 años")]
        public int Edad { get; set; }

        [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
        public string Correo { get; set; }
    }
}
