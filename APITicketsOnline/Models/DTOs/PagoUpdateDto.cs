using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class PagoUpdateDto
    {
        [Required]
        public bool Estado { get; set; }
    }

}
