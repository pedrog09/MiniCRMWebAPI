﻿using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Repositorios
{
    public class ClientRepository : GenericRepository<ClientModel>, IClientRepository
    {
        private readonly SistemaDeTarefasDBContext _context;

        public ClientRepository(SistemaDeTarefasDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientModel>> GetClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
