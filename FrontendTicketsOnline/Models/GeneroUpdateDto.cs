using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class GeneroUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }

}
