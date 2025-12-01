using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class EntradaService : IEntradaService
    {
        private readonly HttpClient _http;
        public EntradaService(HttpClient http) => _http = http;

        public async Task<List<EntradaDto>> GetEntradas() =>
            await _http.GetFromJsonAsync<List<EntradaDto>>("api/Entrada") ?? new List<EntradaDto>();

        public async Task<EntradaDto?> GetEntradaById(int id) =>
            await _http.GetFromJsonAsync<EntradaDto>($"api/Entrada/{id}");

        public async Task<bool> CreateEntrada(EntradaCreateDto dto) =>
            (await _http.PostAsJsonAsync("api/Entrada", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateEntrada(int id, EntradaCreateDto dto) =>
            (await _http.PutAsJsonAsync($"api/Entrada/{id}", dto)).IsSuccessStatusCode;

        public async Task<bool> DeleteEntrada(int id) =>
            (await _http.DeleteAsync($"api/Entrada/{id}")).IsSuccessStatusCode;
    }
}
