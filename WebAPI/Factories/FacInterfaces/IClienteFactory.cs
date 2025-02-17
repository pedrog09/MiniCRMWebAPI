using WebAPI.Models;

namespace WebAPI.Factories.FacInterfaces
{
    public interface IClienteFactory
    {
        ClienteModel CreateCliente(string name, string email, string role, string tipo, string? cnpj, string? cpf);
    }
}
