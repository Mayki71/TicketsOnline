using System.ComponentModel.DataAnnotations;

namespace FrontendTicketsOnline.Models
{
    public class CiudadCreateDto
    {
        [Required(ErrorMessage = "El nombre de la ciudad es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El país es obligatorio")]
        public int PaisId { get; set; }
    }
}
