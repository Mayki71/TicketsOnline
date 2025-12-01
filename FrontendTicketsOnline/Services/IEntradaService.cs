using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IEntradaService
    {
        Task<List<EntradaDto>> GetEntradas();
        Task<EntradaDto?> GetEntradaById(int id);
        Task<bool> CreateEntrada(EntradaCreateDto dto);
        Task<bool> UpdateEntrada(int id, EntradaCreateDto dto);
        Task<bool> DeleteEntrada(int id);
    }
}
