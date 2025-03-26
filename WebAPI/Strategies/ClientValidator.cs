using WebAPI.DTOs;

namespace WebAPI.Strategies
{
    public class ClienteValidator
    {
        private readonly IClienteValidationStrategy _strategy;

        public ClienteValidator(IClienteValidationStrategy strategy)
        {
            _strategy = strategy;
        }

        public bool Validate(ClientDto cliente)
        {
            return _strategy.Validate(cliente);
        }
    }
}
