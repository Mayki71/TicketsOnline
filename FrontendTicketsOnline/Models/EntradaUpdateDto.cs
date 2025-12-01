using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class EntradaUpdateDto
    {
        [Required]
        public int TipoId { get; set; }

        [Required]
        [StringLength(100)]
        public string CodigoQr { get; set; }

        [Required]
        public bool Estado { get; set; }
    }

}
