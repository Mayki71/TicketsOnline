using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _http;
        public UsuarioService(HttpClient http) => _http = http;

        public async Task<List<UsuarioDto>> GetUsuarios() =>
            await _http.GetFromJsonAsync<List<UsuarioDto>>("api/Usuarios") ?? new List<UsuarioDto>();

        public async Task<UsuarioDto?> GetUsuarioById(int id) =>
            await _http.GetFromJsonAsync<UsuarioDto>($"api/Usuarios/{id}");

        public async Task<bool> CreateUsuario(UsuarioCreateDto dto) =>
            (await _http.PostAsJsonAsync("api/Usuarios", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateUsuario(int id, UsuarioCreateDto dto) =>
            (await _http.PutAsJsonAsync($"api/Usuarios/{id}", dto)).IsSuccessStatusCode;

        public async Task<bool> DeleteUsuario(int id) =>
            (await _http.DeleteAsync($"api/Usuarios/{id}")).IsSuccessStatusCode;
        public async Task<UsuarioDto> GetUsuarioActual(int usuarioId)
        {
            return await _http.GetFromJsonAsync<UsuarioDto>($"api/Usuarios/{usuarioId}");
        }

        public async Task<List<EntradaDto>> GetEntradasUsuario(int usuarioId)
        {
            // Endpoint para obtener entradas de un usuario
            return await _http.GetFromJsonAsync<List<EntradaDto>>($"api/Entrada/usuario/{usuarioId}")
                   ?? new List<EntradaDto>();
        }

    }
}
