using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITicketsOnline.Models
{
    [Table("paises")]
    public class Pais
    {
        [Key]
        [Column("pais_id")]
        public int PaisId { get; set; }

        [Required(ErrorMessage = "El nombre del país es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
