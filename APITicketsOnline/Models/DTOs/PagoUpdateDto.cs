using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class PagoUpdateDto
    {
        [Required]
        public string Estado { get; set; }
    }

}
