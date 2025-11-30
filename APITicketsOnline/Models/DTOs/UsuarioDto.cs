using System;

namespace APITicketsOnline.Models.DTOs
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string Email { get; set; }

        // Nunca devolver password_hash en la respuesta.
        public string? Telefono { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int RolId { get; set; }
        public string? RolNombre { get; set; }
    }

}
