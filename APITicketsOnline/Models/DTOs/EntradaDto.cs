namespace APITicketsOnline.Models.DTOs
{
    public class EntradaDto
    {
        public int EntradaId { get; set; }

        public int OrdenId { get; set; }
        public int TipoId { get; set; }

        public string TipoNombre { get; set; }
        public decimal Precio { get; set; }

        public string CodigoQr { get; set; }
        public bool Estado { get; set; }
    }

}
