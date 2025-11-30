using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITicketsOnline.Models
{
    [Table("ciudades")]
    public class Ciudad
    {
        [Key]
        [Column("ciudad_id")]
        public int CiudadId { get; set; }

        [Required(ErrorMessage = "El nombre de la ciudad es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El país es obligatorio")]
        [Column("pais_id")]
        public int PaisId { get; set; }

        // Propiedad de navegación
        [ForeignKey("PaisId")]
        public Pais Pais { get; set; }
    }
}
