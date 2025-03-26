using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Repositorios.Interfaces
{
    public interface IClienteRepositorio : IGenericRepository<ClientModel>
    {
        Task<IEnumerable<ClientModel>> GetClientesAsync();
    }
}
