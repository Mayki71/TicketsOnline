using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class ConciertoUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int CiudadId { get; set; }

        [Required]
        public int GeneroId { get; set; }

        [Required]
        public int OrganizadorId { get; set; }
    }

}
