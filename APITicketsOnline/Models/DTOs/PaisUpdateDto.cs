using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class PaisUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
    }

}
