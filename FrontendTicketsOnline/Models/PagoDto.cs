using System;

namespace FrontendTicketsOnline.Models
{
    public class PagoDto
    {
        public int PagoId { get; set; }

        public int OrdenId { get; set; }
        public decimal Monto { get; set; }

        public string Metodo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPago { get; set; }
    }

}
