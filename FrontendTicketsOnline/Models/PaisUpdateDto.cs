using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class PaisUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }

}
