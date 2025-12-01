using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDto>> GetUsuarios();
        Task<UsuarioDto?> GetUsuarioById(int id);
        Task<bool> CreateUsuario(UsuarioCreateDto dto);
        Task<bool> UpdateUsuario(int id, UsuarioCreateDto dto);
        Task<bool> DeleteUsuario(int id);

        Task<UsuarioDto> GetUsuarioActual(int usuarioId);
        Task<List<EntradaDto>> GetEntradasUsuario(int usuarioId);
    }
}
