using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class RolService : IRolService
    {
        private readonly HttpClient _http;
        public RolService(HttpClient http) => _http = http;

        public async Task<List<RolDto>> GetRoles() =>
            await _http.GetFromJsonAsync<List<RolDto>>("api/Rol") ?? new List<RolDto>();

        public async Task<RolDto?> GetRolById(int id) =>
            await _http.GetFromJsonAsync<RolDto>($"api/Rol/{id}");

        public async Task<bool> CreateRol(RolCreateDto dto) =>
            (await _http.PostAsJsonAsync("api/Rol", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateRol(int id, RolCreateDto dto) =>
            (await _http.PutAsJsonAsync($"api/Rol/{id}", dto)).IsSuccessStatusCode;

        public async Task<bool> DeleteRol(int id) =>
            (await _http.DeleteAsync($"api/Rol/{id}")).IsSuccessStatusCode;
    }
}
