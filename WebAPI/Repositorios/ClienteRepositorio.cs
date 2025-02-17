﻿using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly SistemaDeTarefasDBContext _context;

        public ClienteRepositorio(SistemaDeTarefasDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClienteModel>> GetClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task <ClienteModel> BuscarPorId(int id)
        {
            return await _context.Clientes?.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
            // Check if the referenced Usuario exists
            var usuarioExists = await _context.Usuarios.AnyAsync(u => u.Id == cliente.UsuarioId);
            if (!usuarioExists)
            {
                throw new InvalidOperationException($"Usuario with ID {cliente.UsuarioId} does not exist.");
            }

            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }


        public async Task<ClienteModel> UpdateClienteAsync(ClienteModel cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task <bool> Apagar(int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);

            if (clientePorId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco");
            };

            _context.Clientes.Remove(clientePorId);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
