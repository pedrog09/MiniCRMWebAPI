using WebAPI.Models;

namespace WebAPI.Factories.FacInterfaces
{
    public interface IClientFactory
    {
        ClientModel CreatePessoaFisica(string name, string email, string cpf);
        ClientModel CreatePessoaJuridica(string name, string email, string cnpj);
    }
}
