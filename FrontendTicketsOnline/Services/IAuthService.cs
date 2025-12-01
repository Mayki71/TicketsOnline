using FrontendTicketsOnline.Models;
using System.Threading.Tasks;

namespace FrontendTicketsOnline.Services
{
    public interface IAuthService
    {
        Task<bool> Login(string email, string password);

        // Nuevo método para registro
        Task<RegisterResult> RegisterAsync(RegisterDto registerDto);

        Task Logout();
        Task Initialize();
        bool IsAuthenticated { get; }
        string UserName { get; }
        string UserRole { get; }
    }

    public class RegisterResult
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
    }
}
