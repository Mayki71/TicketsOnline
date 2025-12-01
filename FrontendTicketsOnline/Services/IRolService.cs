using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IRolService
    {
        Task<List<RolDto>> GetRoles();
        Task<RolDto?> GetRolById(int id);
        Task<bool> CreateRol(RolCreateDto dto);
        Task<bool> UpdateRol(int id, RolCreateDto dto);
        Task<bool> DeleteRol(int id);
    }
}
