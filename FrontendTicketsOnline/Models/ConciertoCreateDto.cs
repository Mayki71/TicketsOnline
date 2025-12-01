using System;
using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class ConciertoCreateDto
    {
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede exceder 100 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.DateTime)]
        [CustomValidation(typeof(ConciertoCreateDto), nameof(ValidarFecha))]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "CiudadId debe ser mayor a 0.")]
        public int CiudadId { get; set; }

        [Required(ErrorMessage = "El género es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "GeneroId debe ser mayor a 0.")]
        public int GeneroId { get; set; }

        [Required(ErrorMessage = "El organizador es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "OrganizadorId debe ser mayor a 0.")]
        public int OrganizadorId { get; set; }

        // Validación personalizada para la fecha
        public static ValidationResult ValidarFecha(DateTime fecha, ValidationContext context)
        {
            if (fecha < DateTime.UtcNow)
                return new ValidationResult("La fecha del concierto no puede ser en el pasado.");
            return ValidationResult.Success;
        }
    }
}
