using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class RolCreateDto
    {
        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }

}
