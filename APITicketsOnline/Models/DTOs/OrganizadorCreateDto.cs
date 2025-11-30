using System.ComponentModel.DataAnnotations;

namespace APITicketsOnline.Models.DTOs
{
    public class OrganizadorCreateDto
    {
        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID del usuario debe ser mayor que 0.")]
        public int UsuarioId { get; set; }

        [StringLength(150, ErrorMessage = "El nombre de la empresa no puede exceder 150 caracteres.")]
        public string? NombreEmpresa { get; set; }
    }
}
