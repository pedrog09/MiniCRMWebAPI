using WebAPI.DTOs;

namespace WebAPI.Strategies
{
    public class ClientValidator
    {
        private readonly IClientValidationStrategy _strategy;

        public ClientValidator(IClientValidationStrategy strategy)
        {
            _strategy = strategy;
        }

        public bool Validate(ClientDto cliente)
        {
            return _strategy.Validate(cliente);
        }
    }
}
