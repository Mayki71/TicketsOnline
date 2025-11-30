using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APITicketsOnline.Models
{
    [Table("conciertos")]
    public class Concierto
    {
        [Key]
        [Column("concierto_id")]
        public int ConciertoId { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "El título no puede exceder 100 caracteres")]
        [Column("titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha del concierto es obligatoria")]
        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        [Column("ciudad_id")]
        public int CiudadId { get; set; }

        [ForeignKey("CiudadId")]
        public Ciudad? Ciudad { get; set; }

        [Required(ErrorMessage = "El género musical es obligatorio")]
        [Column("genero_id")]
        public int GeneroId { get; set; }

        [ForeignKey("GeneroId")]
        public GeneroMusical? Genero { get; set; }

        [Required(ErrorMessage = "El organizador es obligatorio")]
        [Column("organizador_id")]
        public int OrganizadorId { get; set; }

        [ForeignKey("OrganizadorId")]
        public Organizador? Organizador { get; set; }

        // Colección de tipos de entrada
        public ICollection<TipoEntrada>? TiposDeEntrada { get; set; }
    }
}
