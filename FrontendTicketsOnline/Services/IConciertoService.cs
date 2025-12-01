using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IConciertoService
    {
        Task<List<ConciertoDto>> GetConciertos();
        Task<ConciertoDto?> GetConciertoById(int id);
        Task<List<ConciertoDto>> GetConciertosProximos();
        Task<bool> CreateConcierto(ConciertoCreateDto dto);
        Task<bool> UpdateConcierto(int id, ConciertoCreateDto dto);
        Task<bool> DeleteConcierto(int id);

        Task<List<GeneroDto>> GetGeneros();

    }
}
