using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface ICarritoService
    {
        Task AgregarAlCarrito(TipoEntradaDTO entrada, int cantidad);
        Task<List<CarritoItem>> GetCarrito();
        Task LimpiarCarrito();
        Task RemoverDelCarrito(int tipoEntradaId);
    }

    public class CarritoItem
    {
        public TipoEntradaDTO Entrada { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Entrada.Precio * Cantidad;
    }
}