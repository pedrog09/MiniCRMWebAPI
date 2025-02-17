using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Factories.FacInterfaces;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IClienteFactory _clienteFactory;

        public ClienteController(IClienteRepositorio clienteRepository, IClienteFactory clienteFactory)
        {
            _clienteRepositorio = clienteRepository;
            _clienteFactory = clienteFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clienteRepositorio.GetClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteRepositorio.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] ClienteModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novoCliente = _clienteFactory.CreateCliente(cliente.Name, cliente.Email, cliente.Role, cliente.Tipo, cliente.CNPJ, cliente.CPF);
            await _clienteRepositorio.AddClienteAsync(novoCliente);
            return CreatedAtAction(nameof(GetClienteById), new { id = novoCliente.Id }, novoCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteModel cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            await _clienteRepositorio.UpdateClienteAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteRepositorio.DeleteClienteAsync(id);
            return NoContent();
        }
    }

}
