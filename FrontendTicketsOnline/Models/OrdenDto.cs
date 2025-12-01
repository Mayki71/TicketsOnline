using System;

namespace FrontendTicketsOnline.Models
{
    public class OrdenDto
    {
        public int OrdenId { get; set; }

        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }

        public DateTime FechaOrden { get; set; }
        public decimal Total { get; set; }
    }

}
