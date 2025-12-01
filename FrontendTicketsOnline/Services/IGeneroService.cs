using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IGeneroService
    {
        Task<List<GeneroDto>> GetGeneros();
        Task<GeneroDto?> GetGeneroById(int id);
        Task<bool> CreateGenero(GeneroCreateDto dto);
        Task<bool> UpdateGenero(int id, GeneroCreateDto dto);
        Task<bool> DeleteGenero(int id);
    }
}
