using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class OrdenUpdateDto
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public DateTime FechaOrden { get; set; }

        [Required]
        public decimal Total { get; set; }
    }

}
