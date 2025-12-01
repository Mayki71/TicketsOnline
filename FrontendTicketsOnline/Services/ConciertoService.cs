using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class ConciertoService : IConciertoService
    {
        private readonly HttpClient _http;

        public ConciertoService(HttpClient http) => _http = http;

        public async Task<List<ConciertoDto>> GetConciertos() =>
            await _http.GetFromJsonAsync<List<ConciertoDto>>("api/Concierto") ?? new List<ConciertoDto>();

        public async Task<ConciertoDto?> GetConciertoById(int id) =>
            await _http.GetFromJsonAsync<ConciertoDto>($"api/Concierto/{id}");

        public async Task<List<ConciertoDto>> GetConciertosProximos() =>
            await _http.GetFromJsonAsync<List<ConciertoDto>>("api/Concierto") ?? new List<ConciertoDto>();

        public async Task<bool> CreateConcierto(ConciertoCreateDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/Concierto", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateConcierto(int id, ConciertoCreateDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/Concierto/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteConcierto(int id)
        {
            var response = await _http.DeleteAsync($"api/Concierto/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<List<GeneroDto>> GetGeneros()
        {
            return await _http.GetFromJsonAsync<List<GeneroDto>>("api/genero");
        }
    }
}