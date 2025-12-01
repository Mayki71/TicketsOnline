using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class CiudadService : ICiudadService
    {
        private readonly HttpClient _http;
        public CiudadService(HttpClient http) => _http = http;

        public async Task<List<CiudadDto>> GetCiudades() =>
            await _http.GetFromJsonAsync<List<CiudadDto>>("api/Ciudad") ?? new List<CiudadDto>();

        public async Task<CiudadDto?> GetCiudadById(int id) =>
            await _http.GetFromJsonAsync<CiudadDto>($"api/Ciudad/{id}");

        public async Task<bool> CreateCiudad(CiudadCreateDto dto) =>
            (await _http.PostAsJsonAsync("api/Ciudad", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateCiudad(int id, CiudadCreateDto dto) =>
            (await _http.PutAsJsonAsync($"api/Ciudad/{id}", dto)).IsSuccessStatusCode;

        public async Task<bool> DeleteCiudad(int id) =>
            (await _http.DeleteAsync($"api/Ciudad/{id}")).IsSuccessStatusCode;
    }
}
