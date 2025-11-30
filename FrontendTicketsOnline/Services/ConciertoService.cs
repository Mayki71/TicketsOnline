using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class ConciertoService : IConciertoService
    {
        private readonly HttpClient _http;

        public ConciertoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ConciertoDTO>> GetConciertos()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<ConciertoDTO>>("conciertos") ?? new List<ConciertoDTO>();
            }
            catch
            {
                return new List<ConciertoDTO>();
            }
        }

        public async Task<ConciertoDTO> GetConciertoById(int id)
        {
            return await _http.GetFromJsonAsync<ConciertoDTO>($"conciertos/{id}");
        }

        public async Task<List<ConciertoDTO>> GetConciertosPorGenero(int generoId)
        {
            return await _http.GetFromJsonAsync<List<ConciertoDTO>>($"conciertos/genero/{generoId}") ?? new List<ConciertoDTO>();
        }

        public async Task<List<ConciertoDTO>> GetConciertosProximos()
        {
            return await _http.GetFromJsonAsync<List<ConciertoDTO>>("conciertos/proximos") ?? new List<ConciertoDTO>();
        }
    }
}