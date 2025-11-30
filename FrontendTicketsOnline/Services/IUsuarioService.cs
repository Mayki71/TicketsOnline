using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> GetUsuarioActual();
        Task<bool> ActualizarPerfil(UsuarioDTO usuario);
    }
}