using System.Collections.Generic;
using System.Threading.Tasks;
using FrontendTicketsOnline.Models;

namespace FrontendTicketsOnline.Services
{
    public interface IOrganizadorService
    {
        Task<List<OrganizadorDto>> GetOrganizadores();
        Task<OrganizadorDto?> GetOrganizadorById(int id);
        Task<bool> CreateOrganizador(OrganizadorCreateDto dto);
        Task<bool> UpdateOrganizador(int id, OrganizadorCreateDto dto);
        Task<bool> DeleteOrganizador(int id);
    }
}
