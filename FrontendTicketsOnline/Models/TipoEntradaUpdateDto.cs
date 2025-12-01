using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class TipoEntradaUpdateDto
    {
        [Required]
        public int ConciertoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }
    }

}
