﻿using WebAPI.Factories.FacInterfaces;
using WebAPI.Models;

namespace WebAPI.Factories
{
    public class ClienteFactory : IClienteFactory
    {
        public ClienteModel CreatePessoaFisica(string name, string email, string cpf)
        {
            return new ClienteModel
            {
                Name = name,
                Email = email,
                Tipo = "pessoa",
                CPF = cpf,
                CNPJ = null
            };
        }

        public ClienteModel CreatePessoaJuridica(string name, string email, string cnpj)
        {
            return new ClienteModel
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
