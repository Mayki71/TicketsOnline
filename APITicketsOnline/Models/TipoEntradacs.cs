using APITicketsOnline.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITicketsOnline.Models
{
    [Table("tipos_de_entrada")]
    public class TipoEntrada
    {
        [Key]
        [Column("tipo_id")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "El concierto es obligatorio")]
        [Column("concierto_id")]
        public int ConciertoId { get; set; }

        [ForeignKey("ConciertoId")]
        public Concierto? Concierto { get; set; }

        [Required(ErrorMessage = "El nombre del tipo de entrada es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres")]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        [Column("precio")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        [Column("stock")]
        public int Stock { get; set; }
    }
}
