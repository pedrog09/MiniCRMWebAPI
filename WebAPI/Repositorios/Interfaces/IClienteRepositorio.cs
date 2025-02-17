using WebAPI.Models;

namespace WebAPI.Repositorios.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<IEnumerable<ClienteModel>> GetClientesAsync();
        Task<ClienteModel> BuscarPorId(int id);
        Task <ClienteModel> Adicionar(ClienteModel cliente);
        Task <ClienteModel> UpdateClienteAsync(ClienteModel cliente);
        Task <bool> Apagar(int id);
    }
}
