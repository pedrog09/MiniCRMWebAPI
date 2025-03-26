using WebAPI.DTOs;

namespace WebAPI.Strategies
{
    public interface IClienteValidationStrategy
    {
        bool Validate(ClientDto cliente);
    }
}
