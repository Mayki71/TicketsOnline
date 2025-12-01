using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IPaisService
    {
        Task<List<PaisDto>> GetPaises();
        Task<PaisDto?> GetPaisById(int id);
        Task<bool> CreatePais(PaisCreateDto dto);
        Task<bool> UpdatePais(int id, PaisCreateDto dto);
        Task<bool> DeletePais(int id);
    }
}
