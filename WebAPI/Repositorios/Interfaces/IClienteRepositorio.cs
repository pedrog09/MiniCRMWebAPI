using WebAPI.Models;

namespace WebAPI.Repositorios.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<IEnumerable<ClienteModel>> GetClientesAsync();
        Task<ClienteModel> GetClienteByIdAsync(int id);
        Task AddClienteAsync(ClienteModel cliente);
        Task UpdateClienteAsync(ClienteModel cliente);
        Task DeleteClienteAsync(int id);
    }
}
