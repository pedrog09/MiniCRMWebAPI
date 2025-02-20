using WebAPI.Models;

namespace WebAPI.Strategies
{
    public interface IClienteValidationStrategy
    {
        bool Validate(ClienteModel cliente);
    }
}
