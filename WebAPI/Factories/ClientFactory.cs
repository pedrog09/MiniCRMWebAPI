﻿using WebAPI.Factories.FacInterfaces;
using WebAPI.Models;

namespace WebAPI.Factories
{
    public class ClientFactory : IClientFactory
    {
        public ClientModel CreatePessoaFisica(string name, string email, string cpf)
        {
            return new ClientModel
            {
                Name = name,
                Email = email,
                Tipo = "pessoa",
                CPF = cpf,
                CNPJ = null
            };
        }

        public ClientModel CreatePessoaJuridica(string name, string email, string cnpj)
        {
            return new ClientModel
            {
                Name = name,
                Email = email,
                Tipo = "empresa",
                CNPJ = cnpj,
                CPF = null
            };
        }
    }
}
