using APITicketsOnline.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITicketsOnline.Models
{
    [Table("entradas")]
    public class Entrada
    {
        [Key]
        [Column("entrada_id")]
        public int EntradaId { get; set; }

        [Required(ErrorMessage = "La orden es obligatoria")]
        [Column("orden_id")]
        public int OrdenId { get; set; }

        [ForeignKey("OrdenId")]
        public Orden? Orden { get; set; }

        [Required(ErrorMessage = "El tipo de entrada es obligatorio")]
        [Column("tipo_id")]
        public int TipoId { get; set; }

        [ForeignKey("TipoId")]
        public TipoEntrada? TipoEntrada { get; set; }

        [Required(ErrorMessage = "El código QR es obligatorio")]
        [StringLength(100, ErrorMessage = "El código QR no puede exceder 100 caracteres")]
        [Column("codigo_qr")]
        public string CodigoQr { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [Column("estado")]
        public bool Estado { get; set; }
    }
}
