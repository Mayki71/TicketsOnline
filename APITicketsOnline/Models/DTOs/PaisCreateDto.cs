using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class PaisCreateDto
    {
        [Required(ErrorMessage = "El nombre del país es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del país no puede exceder 100 caracteres.")]
        [RegularExpression(@"\S+", ErrorMessage = "El nombre del país no puede estar vacío o solo espacios.")]
        public string Nombre { get; set; }
    }
}
