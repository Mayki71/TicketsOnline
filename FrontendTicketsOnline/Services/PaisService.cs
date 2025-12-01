using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class PaisService : IPaisService
    {
        private readonly HttpClient _http;
        public PaisService(HttpClient http) => _http = http;

        public async Task<List<PaisDto>> GetPaises() =>
            await _http.GetFromJsonAsync<List<PaisDto>>("api/Pais") ?? new List<PaisDto>();

        public async Task<PaisDto?> GetPaisById(int id) =>
            await _http.GetFromJsonAsync<PaisDto>($"api/Pais/{id}");

        public async Task<bool> CreatePais(PaisCreateDto dto) =>
            (await _http.PostAsJsonAsync("api/Pais", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdatePais(int id, PaisCreateDto dto) =>
            (await _http.PutAsJsonAsync($"api/Pais/{id}", dto)).IsSuccessStatusCode;

        public async Task<bool> DeletePais(int id) =>
            (await _http.DeleteAsync($"api/Pais/{id}")).IsSuccessStatusCode;
    }
}
