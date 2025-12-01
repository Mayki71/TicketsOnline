using System;
using System.Collections.Generic;

namespace FrontendTicketsOnline.Models
{
    public class ConciertoDto
    {
        public int ConciertoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public int CiudadId { get; set; }
        public string CiudadNombre { get; set; }

        public int GeneroId { get; set; }
        public string GeneroNombre { get; set; }

        public int OrganizadorId { get; set; }
        public string OrganizadorNombre { get; set; }

        public List<TipoEntradaDto> TiposDeEntrada { get; set; } = new();
    }

}
