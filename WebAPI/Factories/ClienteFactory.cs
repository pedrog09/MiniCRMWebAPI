using WebAPI.Factories.FacInterfaces;
using WebAPI.Models;

namespace WebAPI.Factories
{
    public class ClienteFactory : IClienteFactory
    {
        public ClienteModel CreateCliente(string name, string email, string role, string tipo, string? cnpj, string? cpf)
        {
            return new ClienteModel
            {
                Name = name,
                Email = email,
                Role = role,
                Tipo = tipo,
                CNPJ = cnpj,
                CPF = cpf
            };
        }
}
