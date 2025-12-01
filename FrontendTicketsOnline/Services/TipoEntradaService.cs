using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class TipoEntradaService : ITipoEntradaService
    {
        private readonly HttpClient _http;
        public TipoEntradaService(HttpClient http) => _http = http;

        public async Task<List<TipoEntradaDto>> GetTiposEntradas() =>
            await _http.GetFromJsonAsync<List<TipoEntradaDto>>("api/TipoEntrada") ?? new List<TipoEntradaDto>();

        public async Task<TipoEntradaDto?> GetTipoEntradaById(int id) =>
            await _http.GetFromJsonAsync<TipoEntradaDto>($"api/TipoEntrada/{id}");

        public async Task<bool> CreateTipoEntrada(TipoEntradaCreateDto dto) =>
            (await _http.PostAsJsonAsync("api/TipoEntrada", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateTipoEntrada(int id, TipoEntradaCreateDto dto) =>
            (await _http.PutAsJsonAsync($"api/TipoEntrada/{id}", dto)).IsSuccessStatusCode;

        public async Task<bool> DeleteTipoEntrada(int id) =>
            (await _http.DeleteAsync($"api/TipoEntrada/{id}")).IsSuccessStatusCode;
    }
}
