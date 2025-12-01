using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;

        public bool IsAuthenticated { get; private set; }
        public string UserName { get; private set; }
        public string UserRole { get; private set; }

        public AuthService(HttpClient http)
        {
            _http = http;
        }


        public async Task<bool> Login(string email, string password)
        {
            var body = new { email = email, password = password };

            var response = await _http.PostAsJsonAsync("api/Auth/login", body);

            if (!response.IsSuccessStatusCode)
                return false;

            IsAuthenticated = true;
            UserName = email;
            UserRole = "usuario";

            return true;
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            var response = await _http.PostAsJsonAsync("api/Usuarios", registerDto);
            return response.IsSuccessStatusCode;
        }

        public Task Logout()
        {
            IsAuthenticated = false;
            UserName = null;
            UserRole = null;
            return Task.CompletedTask;
        }

        public Task Initialize()
        {
            return Task.CompletedTask;
        }
        public async Task<RegisterResult> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("auth/register", registerDto);

                if (response.IsSuccessStatusCode)
                {
                    return new RegisterResult
                    {
                        Exito = true,
                        Mensaje = "Registro exitoso"
                    };
                }

                var errorMsg = await response.Content.ReadAsStringAsync();
                return new RegisterResult
                {
                    Exito = false,
                    Mensaje = errorMsg
                };
            }
            catch (Exception ex)
            {
                return new RegisterResult
                {
                    Exito = false,
                    Mensaje = ex.Message
                };
            }
        }

    }
}
