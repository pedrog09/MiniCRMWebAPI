using WebAPI.DTOs;

namespace WebAPI.Strategies
{
    public interface IClientValidationStrategy
    {
        bool Validate(ClientDto cliente);
    }
}
