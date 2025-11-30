using System;
using System.Collections.Generic;

namespace FrontendTicketsOnline.Models
{
    public class ConciertoDTO
    {
        public int ConciertoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string CiudadNombre { get; set; }
        public string GeneroNombre { get; set; }
        public string OrganizadorNombre { get; set; }
        public List<TipoEntradaDTO> TiposDeEntrada { get; set; } = new();
    }

    public class TipoEntradaDTO
    {
        public int TipoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int ConciertoId { get; set; }
    }
}