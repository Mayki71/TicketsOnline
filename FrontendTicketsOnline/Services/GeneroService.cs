using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class GeneroService : IGeneroService
    {
        private readonly HttpClient _http;
        public GeneroService(HttpClient http) => _http = http;

        public async Task<List<GeneroDto>> GetGeneros() =>
            await _http.GetFromJsonAsync<List<GeneroDto>>("api/Genero") ?? new List<GeneroDto>();

        public async Task<GeneroDto?> GetGeneroById(int id) =>
            await _http.GetFromJsonAsync<GeneroDto>($"api/Genero/{id}");

        public async Task<bool> CreateGenero(GeneroCreateDto dto) =>
            (await _http.PostAsJsonAsync("api/Genero", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateGenero(int id, GeneroCreateDto dto) =>
            (await _http.PutAsJsonAsync($"api/Genero/{id}", dto)).IsSuccessStatusCode;

        public async Task<bool> DeleteGenero(int id) =>
            (await _http.DeleteAsync($"api/Genero/{id}")).IsSuccessStatusCode;
    }
}
