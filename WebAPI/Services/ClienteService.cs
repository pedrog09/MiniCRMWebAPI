using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Services
{
    public class ClienteService
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> GetClientesAsync()
        {
            var clientes = await _clienteRepositorio.GetClientesAsync();
            return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }

        public async Task<ClienteDto> GetClienteByIdAsync(int id)
        {
            var cliente = await _clienteRepositorio.GetByIdAsync(id);
            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task<ClienteDto> CreateClienteAsync(ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<ClienteModel>(clienteDto);
            var createdCliente = await _clienteRepositorio.AddAsync(cliente);
            return _mapper.Map<ClienteDto>(createdCliente);
        }

        public async Task UpdateClienteAsync(ClienteDto clienteDto)
        {
            var cliente = _mapper.Map<ClienteModel>(clienteDto);
            await _clienteRepositorio.UpdateAsync(cliente);
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            return await _clienteRepositorio.DeleteAsync(id);
        }
    }
}
