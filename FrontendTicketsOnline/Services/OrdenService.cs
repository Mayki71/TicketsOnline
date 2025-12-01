using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class OrdenService : IOrdenService
    {
        private readonly HttpClient _http;
        public OrdenService(HttpClient http) => _http = http;

        public async Task<List<OrdenDto>> GetOrdenes() =>
            await _http.GetFromJsonAsync<List<OrdenDto>>("api/Orden") ?? new List<OrdenDto>();

        public async Task<OrdenDto?> GetOrdenById(int id) =>
            await _http.GetFromJsonAsync<OrdenDto>($"api/Orden/{id}");

        public async Task<bool> CreateOrden(OrdenCreateDto dto) =>
            (await _http.PostAsJsonAsync("api/Orden", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateOrden(int id, OrdenCreateDto dto) =>
            (await _http.PutAsJsonAsync($"api/Orden/{id}", dto)).IsSuccessStatusCode;

        public async Task<bool> DeleteOrden(int id) =>
            (await _http.DeleteAsync($"api/Orden/{id}")).IsSuccessStatusCode;
    }
}
