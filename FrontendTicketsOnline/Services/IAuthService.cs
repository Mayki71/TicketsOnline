using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IAuthService
    {
        Task<bool> Login(string email, string password);
        Task<bool> Register(RegisterDTO registerDto);
        Task Logout();
        Task Initialize();
        bool IsAuthenticated { get; }
        string UserName { get; }
        string UserRole { get; }
    }
}