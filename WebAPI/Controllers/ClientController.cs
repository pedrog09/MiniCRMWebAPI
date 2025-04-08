using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Factories.FacInterfaces;
using WebAPI.Models;
using WebAPI.Services;
using WebAPI.Strategies;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly IClientFactory _clienteFactory;

        public ClienteController(ClienteService clienteService, IClientFactory clienteFactory)
        {
            _clienteService = clienteService;
            _clienteFactory = clienteFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clienteService.GetClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] ClientDto clienteDto)
        {
            if (clienteDto == null)
            {
                return BadRequest(new { message = "Cliente data is required" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (clienteDto.UsuarioId <= 0)
                {
                    return BadRequest(new { message = "UsuarioId is required and must be greater than 0" });
                }

                // Select validation strategy based on client type
                IClientValidationStrategy validationStrategy = clienteDto.Tipo.ToLower() == "pessoa"
                    ? new PessoaFisicaValidation()
                    : new PessoaJuridicaValidation();

                var validator = new ClientValidator(validationStrategy);
                if (!validator.Validate(clienteDto))
                {
                    return BadRequest(new { message = $"Invalid {clienteDto.Tipo} data" });
                }

                var createdCliente = await _clienteService.CreateClienteAsync(clienteDto);
                return CreatedAtAction(nameof(GetClienteById), new { id = createdCliente.Id }, createdCliente);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the client. %s", ex });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClientModel cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            // Map ClientModel to ClientDto
            var clienteDto = new ClientDto
            {
                Id = cliente.Id,
                UsuarioId = cliente.UsuarioId,
                Name = cliente.Name,
                Email = cliente.Email,
                Tipo = cliente.Tipo,
                CNPJ = cliente.CNPJ,
                CPF = cliente.CPF
            };

            await _clienteService.UpdateClienteAsync(clienteDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _clienteService.DeleteClienteAsync(id);
            return NoContent();
        }
    }

}
