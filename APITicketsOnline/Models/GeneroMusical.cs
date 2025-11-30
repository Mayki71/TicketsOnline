using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITicketsOnline.Models
{
    [Table("generos_musicales")]
    public class GeneroMusical
    {
        [Key]
        [Column("genero_id")]
        public int GeneroId { get; set; }

        [Required(ErrorMessage = "El nombre del género es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
