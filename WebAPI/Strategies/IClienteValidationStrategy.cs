using WebAPI.DTOs;

namespace WebAPI.Strategies
{
    public interface IClienteValidationStrategy
    {
        bool Validate(ClienteDto cliente);
    }
}
