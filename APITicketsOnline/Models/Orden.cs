using APITicketsOnline.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITicketsOnline.Models
{
    [Table("ordenes")]
    public class Orden
    {
        [Key]
        [Column("orden_id")]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "La fecha de la orden es obligatoria")]
        [Column("fecha_orden")]
        public DateTime FechaOrden { get; set; }

        [Required(ErrorMessage = "El total es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor a 0")]
        [Column("total")]
        public decimal Total { get; set; }
    }
}
