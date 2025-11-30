namespace FrontendTicketsOnline.Models
{
    public class EntradaDTO
    {
        public int EntradaId { get; set; }
        public int OrdenId { get; set; }
        public string CodigoQr { get; set; }
        public bool Estado { get; set; }
        public TipoEntradaDTO TipoEntrada { get; set; }
    }
}