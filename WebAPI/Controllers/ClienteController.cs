﻿﻿﻿﻿﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Factories.FacInterfaces;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;
using WebAPI.Strategies;


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
            var cliente = await _clienteRepositorio.BuscarPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] ClienteModel cliente)
        {
            if (cliente == null)
            {
                return BadRequest(new { message = "Cliente data is required" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (cliente.UsuarioId <= 0)
                {
                    return BadRequest(new { message = "UsuarioId is required and must be greater than 0" });
                }

                // Select validation strategy based on client type
                IClienteValidationStrategy validationStrategy = cliente.Tipo.ToLower() == "pessoa" 
                    ? new PessoaFisicaValidation() 
                    : new PessoaJuridicaValidation();

                var validator = new ClienteValidator(validationStrategy);
                if (!validator.Validate(cliente))
                {
                    return BadRequest(new { message = $"Invalid {cliente.Tipo} data" });
                }

                var novoCliente = _clienteFactory.CreateCliente(
                    cliente.Name,
                    cliente.Email,
                    cliente.Tipo,
                    cliente.CNPJ,
                    cliente.CPF
                );

                novoCliente.UsuarioId = cliente.UsuarioId;
                await _clienteRepositorio.Adicionar(novoCliente);
                return CreatedAtAction(nameof(GetClienteById), new { id = novoCliente.Id }, novoCliente);
            }

            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the client." });
            }
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
            await _clienteRepositorio.Apagar(id);
            return NoContent();
        }
    }

}
