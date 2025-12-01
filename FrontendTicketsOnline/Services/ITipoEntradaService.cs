using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface ITipoEntradaService
    {
        Task<List<TipoEntradaDto>> GetTiposEntradas();
        Task<TipoEntradaDto?> GetTipoEntradaById(int id);
        Task<bool> CreateTipoEntrada(TipoEntradaCreateDto dto);
        Task<bool> UpdateTipoEntrada(int id, TipoEntradaCreateDto dto);
        Task<bool> DeleteTipoEntrada(int id);
    }
}
