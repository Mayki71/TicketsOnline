using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;
using Microsoft.JSInterop;

namespace FrontendTicketsOnline.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly IJSRuntime _jsRuntime;

        public AuthService(HttpClient http, IJSRuntime jsRuntime)
        {
            _http = http;
            _jsRuntime = jsRuntime;
        }

        public bool IsAuthenticated { get; private set; }
        public string UserName { get; private set; }
        public string UserRole { get; private set; }

        public async Task<bool> Login(string email, string password)
        {
            try
            {
                var loginDto = new LoginDto { Email = email, Password = password };
                var response = await _http.PostAsJsonAsync("auth/login", loginDto);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", result.Token);
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "userName", result.Nombre);
                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "userRole", result.Rol);

                    IsAuthenticated = true;
                    UserName = result.Nombre;
                    UserRole = result.Rol;

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Register(RegisterDTO registerDto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("auth/register", registerDto);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task Logout()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "userName");
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "userRole");

            IsAuthenticated = false;
            UserName = string.Empty;
            UserRole = string.Empty;
        }

        public async Task Initialize()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
            var userName = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "userName");
            var userRole = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "userRole");

            if (!string.IsNullOrEmpty(token))
            {
                IsAuthenticated = true;
                UserName = userName ?? string.Empty;
                UserRole = userRole ?? string.Empty;
            }
        }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
    }
}