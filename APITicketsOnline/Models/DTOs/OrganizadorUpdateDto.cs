using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class OrganizadorUpdateDto
    {
        [Required]
        public int UsuarioId { get; set; }

        [StringLength(150)]
        public string? NombreEmpresa { get; set; }
    }

}
