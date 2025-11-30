using APITicketsOnline.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITicketsOnline.Models
{
    [Table("organizadores")]
    public class Organizador
    {
        [Key]
        [Column("organizador_id")]
        public int OrganizadorId { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [StringLength(150, ErrorMessage = "El nombre de la empresa no puede exceder 150 caracteres")]
        [Column("nombre_empresa")]
        public string? NombreEmpresa { get; set; }  // opcional, NULL permitido
    }
}
