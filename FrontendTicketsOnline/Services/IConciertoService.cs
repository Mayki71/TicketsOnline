using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IConciertoService
    {
        Task<List<ConciertoDTO>> GetConciertos();
        Task<ConciertoDTO> GetConciertoById(int id);
        Task<List<ConciertoDTO>> GetConciertosPorGenero(int generoId);
        Task<List<ConciertoDTO>> GetConciertosProximos();
    }
}