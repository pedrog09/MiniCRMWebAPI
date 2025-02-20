using WebAPI.Models;

namespace WebAPI.Strategies
{
    public class PessoaFisicaValidation : IClienteValidationStrategy
    {
        public bool Validate(ClienteModel cliente)
        {
            if (string.IsNullOrEmpty(cliente.CPF))
                return false;

            // Add more specific validation rules for pessoa física
            return cliente.CPF.Length == 14; // CPF format: 000.000.000-00
        }
    }
}
