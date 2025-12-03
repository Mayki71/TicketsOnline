using APITicketsOnline.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITicketsOnline.Models
{
    [Table("pagos")]
    public class Pago
    {
        [Key]
        [Column("pago_id")]
        public int PagoId { get; set; }

        [Required(ErrorMessage = "La orden es obligatoria")]
        [Column("orden_id")]
        public int OrdenId { get; set; }

        [ForeignKey("OrdenId")]
        public Orden? Orden { get; set; }

        /*[Required(ErrorMessage = "El método de pago es obligatorio")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [RegularExpression("^(otro|transferencia|paypal|tarjeta)$",
            ErrorMessage = "Método inválido: debe ser 'otro', 'transferencia', 'paypal' o 'tarjeta'")]
        [Column("metodo")]
        public string Metodo { get; set; }*/

        [RegularExpression(@"^\d{4}$", ErrorMessage = "Debe contener exactamente 4 dígitos")]
        [Column("ultimos_4")]
        public string? Ultimos4 { get; set; }

        [StringLength(20, ErrorMessage = "La marca no puede exceder 20 caracteres")]
        [Column("marca_tarjeta")]
        public string? MarcaTarjeta { get; set; }

        [Column("token")]
        public string? Token { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0")]
        [Column("monto")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20)]
        [RegularExpression("^(pendiente|reembolsado|fallido|exitoso)$",
            ErrorMessage = "Estado inválido: debe ser 'pendiente', 'reembolsado', 'fallido' o 'exitoso'")]
        [Column("estado")]
        public bool Estado { get; set; }

        [Column("fecha_pago")]
        public DateTime FechaPago { get; set; } = DateTime.Now;
    }
}
