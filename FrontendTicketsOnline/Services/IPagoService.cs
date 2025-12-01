using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IPagoService
    {
        Task<List<PagoDto>> GetPagos();
        Task<PagoDto?> GetPagoById(int id);
        Task<bool> CreatePago(PagoCreateDto dto);
        Task<bool> UpdatePago(int id, PagoCreateDto dto);
        Task<bool> DeletePago(int id);
    }
}
