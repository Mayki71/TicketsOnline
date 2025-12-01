using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class RolCreateDto
    {
        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }

}
