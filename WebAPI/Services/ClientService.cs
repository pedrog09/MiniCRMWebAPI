using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Services
{
    public class ClienteService
    {
        private readonly IClientRepository _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IClientRepository clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetClientesAsync()
        {
            var clientes = await _clienteRepositorio.GetClientesAsync();
            return _mapper.Map<IEnumerable<ClientDto>>(clientes);
        }

        public async Task<ClientDto> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepositorio.GetByIdAsync(id);
            return _mapper.Map<ClientDto>(cliente);
        }

        public async Task<ClientDto> CreateClienteAsync(ClientDto clienteDto)
        {
            var cliente = _mapper.Map<ClientModel>(clienteDto);
            var createdCliente = await _clienteRepositorio.AddAsync(cliente);
            return _mapper.Map<ClientDto>(createdCliente);
        }

        public async Task UpdateClienteAsync(ClientDto clienteDto)
        {
            var cliente = _mapper.Map<ClientModel>(clienteDto);
            await _clienteRepositorio.UpdateAsync(cliente);
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            return await _clienteRepositorio.DeleteAsync(id);
        }
    }
}
