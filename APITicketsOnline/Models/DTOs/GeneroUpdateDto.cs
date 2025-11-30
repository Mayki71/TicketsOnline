using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class GeneroUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }

}
