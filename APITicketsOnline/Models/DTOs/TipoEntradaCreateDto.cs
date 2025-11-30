using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class TipoEntradaCreateDto
    {
        [Required(ErrorMessage = "El ID del concierto es obligatorio.")]
        public int ConciertoId { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de entrada es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres.")]
        [RegularExpression(@"\S+", ErrorMessage = "El nombre no puede estar vacío o solo espacios.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
        public int Stock { get; set; }
    }
}
