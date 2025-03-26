﻿using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Repositorios
{
    public class ClienteRepositorio : GenericRepository<ClientModel>, IClienteRepositorio
    {
        private readonly SistemaDeTarefasDBContext _context;

        public ClienteRepositorio(SistemaDeTarefasDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientModel>> GetClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
