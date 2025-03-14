using WebAPI.DTOs;

namespace WebAPI.Strategies
{
    public class PessoaJuridicaValidation : IClienteValidationStrategy
    {
        public bool Validate(ClienteDto cliente)
        {
            if (string.IsNullOrEmpty(cliente.CNPJ))
                return false;

            // Add more specific validation rules for pessoa jurídica
            return cliente.CNPJ.Length == 18; // CNPJ format: 00.000.000/0000-00
        }
    }
}
