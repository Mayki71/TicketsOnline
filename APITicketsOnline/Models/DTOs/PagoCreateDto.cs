using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class PagoCreateDto
    {
        [Required(ErrorMessage = "El ID de la orden es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la orden debe ser mayor que 0.")]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio.")]
        [StringLength(50, ErrorMessage = "El método de pago no puede exceder 50 caracteres.")]
        public string Metodo { get; set; }

        [RegularExpression(@"^\d{4}$", ErrorMessage = "Los últimos 4 dígitos deben ser exactamente 4 números.")]
        public string? Ultimos4 { get; set; }

        [StringLength(50, ErrorMessage = "La marca de la tarjeta no puede exceder 50 caracteres.")]
        public string? MarcaTarjeta { get; set; }

        [StringLength(255, ErrorMessage = "El token no puede exceder 255 caracteres.")]
        public string? Token { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(50, ErrorMessage = "El estado no puede exceder 50 caracteres.")]
        public string Estado { get; set; }
    }
}
