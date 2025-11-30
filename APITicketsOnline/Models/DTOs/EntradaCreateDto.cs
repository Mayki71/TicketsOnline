using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class EntradaCreateDto
    {
        [Required(ErrorMessage = "El ID de la orden es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "OrdenId debe ser mayor a 0.")]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "El ID del tipo de entrada es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "TipoId debe ser mayor a 0.")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "El código QR es obligatorio.")]
        [StringLength(100, ErrorMessage = "El código QR no puede exceder 100 caracteres.")]
        [RegularExpression(@"\S+", ErrorMessage = "El código QR no puede estar vacío o contener solo espacios.")]
        public string CodigoQr { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        public bool Estado { get; set; }
    }
}
