namespace FrontendTicketsOnline.Models
{
    public class TipoEntradaDto
    {
        public int TipoId { get; set; }
        public int ConciertoId { get; set; }

        public string ConciertoTitulo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }

}
