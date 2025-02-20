using WebAPI.Models;

namespace WebAPI.Factories.FacInterfaces
{
    public interface IClienteFactory
    {
        ClienteModel CreatePessoaFisica(string name, string email, string cpf);
        ClienteModel CreatePessoaJuridica(string name, string email, string cnpj);
    }
}
