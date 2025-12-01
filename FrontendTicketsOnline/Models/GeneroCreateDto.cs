using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class GeneroCreateDto
    {
        [Required(ErrorMessage = "El nombre del género es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del género no puede exceder 100 caracteres.")]
        [RegularExpression(@"\S+", ErrorMessage = "El nombre del género no puede estar vacío o contener solo espacios.")]
        public string Nombre { get; set; }
    }
}
