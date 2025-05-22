using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Repositorios.Interfaces
{
    public interface IClientRepositorio : IGenericRepository<ClientModel>
    {
        Task<IEnumerable<ClientModel>> GetClientesAsync();
    }
}
