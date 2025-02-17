using WebAPI.Factories.FacInterfaces;
using WebAPI.Models;

namespace WebAPI.Factories
{
    public class ClienteFactory : IClienteFactory
    {
        public ClienteModel CreateCliente(string name, string email, string tipo, string? cnpj, string? cpf)
        {
            return new ClienteModel
            {
                Name = name,
                Email = email,
                Tipo = tipo,
                CNPJ = cnpj,
                CPF = cpf
            };
        }
    }
}
