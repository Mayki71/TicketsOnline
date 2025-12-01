using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class CiudadUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        public int PaisId { get; set; }
    }

}
