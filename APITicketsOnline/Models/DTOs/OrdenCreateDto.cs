using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class OrdenCreateDto
    {
        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del usuario debe ser mayor que 0.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "La fecha de la orden es obligatoria.")]
        public DateTime FechaOrden { get; set; }

        [Required(ErrorMessage = "El total de la orden es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El total de la orden no puede ser negativo.")]
        public decimal Total { get; set; }
    }
}
