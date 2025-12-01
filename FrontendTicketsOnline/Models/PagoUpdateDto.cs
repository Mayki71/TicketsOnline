using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class PagoUpdateDto
    {
        [Required]
        public string Estado { get; set; }
    }

}
