using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class PagoService : IPagoService
    {
        private readonly HttpClient _http;
        public PagoService(HttpClient http) => _http = http;

        public async Task<List<PagoDto>> GetPagos() =>
            await _http.GetFromJsonAsync<List<PagoDto>>("api/Pago") ?? new List<PagoDto>();

        public async Task<PagoDto?> GetPagoById(int id) =>
            await _http.GetFromJsonAsync<PagoDto>($"api/Pago/{id}");

        public async Task<bool> CreatePago(PagoCreateDto dto) =>
            (await _http.PostAsJsonAsync("api/Pago", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdatePago(int id, PagoCreateDto dto) =>
            (await _http.PutAsJsonAsync($"api/Pago/{id}", dto)).IsSuccessStatusCode;

        public async Task<bool> DeletePago(int id) =>
            (await _http.DeleteAsync($"api/Pago/{id}")).IsSuccessStatusCode;
    }
}
