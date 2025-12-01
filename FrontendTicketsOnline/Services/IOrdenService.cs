using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IOrdenService
    {
        Task<List<OrdenDto>> GetOrdenes();
        Task<OrdenDto?> GetOrdenById(int id);
        Task<bool> CreateOrden(OrdenCreateDto dto);
        Task<bool> UpdateOrden(int id, OrdenCreateDto dto);
        Task<bool> DeleteOrden(int id);
    }
}
