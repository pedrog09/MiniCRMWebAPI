using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Repositorios.Interfaces
{
    public interface IClienteRepositorio : IGenericRepository<ClienteModel>
    {
        Task<IEnumerable<ClienteModel>> GetClientesAsync();
    }
}
