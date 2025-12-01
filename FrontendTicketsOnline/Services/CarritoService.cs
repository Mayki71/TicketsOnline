using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;
using Microsoft.JSInterop;

namespace FrontendTicketsOnline.Services
{
    public class CarritoService : ICarritoService
    {
        private readonly IJSRuntime _jsRuntime;
        private List<CarritoItem> _carritoItems = new();

        public CarritoService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task AgregarAlCarrito(TipoEntradaDto entrada, int cantidad)
        {
            var itemExistente = _carritoItems.FirstOrDefault(x => x.Entrada.TipoId == entrada.TipoId);

            if (itemExistente != null)
            {
                itemExistente.Cantidad += cantidad;
            }
            else
            {
                _carritoItems.Add(new CarritoItem
                {
                    Entrada = entrada,
                    Cantidad = cantidad
                });
            }

            await GuardarCarrito();
        }

        public Task<List<CarritoItem>> GetCarrito()
        {
            return Task.FromResult(_carritoItems);
        }

        public async Task LimpiarCarrito()
        {
            _carritoItems.Clear();
            await GuardarCarrito();
        }

        public async Task RemoverDelCarrito(int tipoEntradaId)
        {
            _carritoItems.RemoveAll(x => x.Entrada.TipoId == tipoEntradaId);
            await GuardarCarrito();
        }

        private async Task GuardarCarrito()
        {
            // Implementar si se desea persistencia
        }
    }
}