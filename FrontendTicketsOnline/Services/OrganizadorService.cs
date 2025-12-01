using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class OrganizadorService : IOrganizadorService
    {
        private readonly HttpClient _http;
        public OrganizadorService(HttpClient http) => _http = http;

        public async Task<List<OrganizadorDto>> GetOrganizadores() =>
            await _http.GetFromJsonAsync<List<OrganizadorDto>>("api/Organizador") ?? new List<OrganizadorDto>();

        public async Task<OrganizadorDto?> GetOrganizadorById(int id) =>
            await _http.GetFromJsonAsync<OrganizadorDto>($"api/Organizador/{id}");

        public async Task<bool> CreateOrganizador(OrganizadorCreateDto dto) =>
            (await _http.PostAsJsonAsync("api/Organizador", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateOrganizador(int id, OrganizadorCreateDto dto) =>
            (await _http.PutAsJsonAsync($"api/Organizador/{id}", dto)).IsSuccessStatusCode;

        public async Task<bool> DeleteOrganizador(int id) =>
            (await _http.DeleteAsync($"api/Organizador/{id}")).IsSuccessStatusCode;
    }
}
