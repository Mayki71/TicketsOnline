using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class RolUpdateDto
    {
        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }

}
