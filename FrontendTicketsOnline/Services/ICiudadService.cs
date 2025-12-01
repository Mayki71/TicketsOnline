using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface ICiudadService
    {
        Task<List<CiudadDto>> GetCiudades();
        Task<CiudadDto?> GetCiudadById(int id);
        Task<bool> CreateCiudad(CiudadCreateDto dto);
        Task<bool> UpdateCiudad(int id, CiudadCreateDto dto);
        Task<bool> DeleteCiudad(int id);
    }
}
