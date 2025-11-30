using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<UsuarioDTO> GetUsuarioActual()
        {
            return await _http.GetFromJsonAsync<UsuarioDTO>("usuarios/perfil");
        }

        public async Task<bool> ActualizarPerfil(UsuarioDTO usuario)
        {
            var response = await _http.PutAsJsonAsync("usuarios/perfil", usuario);
            return response.IsSuccessStatusCode;
        }
    }
}