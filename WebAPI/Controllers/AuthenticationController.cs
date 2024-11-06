using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly ITokenRepositorio _tokenRepositorio;

        public AuthenticationController(ITokenRepositorio tokenRepositorio)
        {
            _tokenRepositorio = tokenRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<LoginDto>> Login([FromBody] LoginDto loginDto)
        {
            var token = await _tokenRepositorio.GenerateToken(loginDto);

            if (String.IsNullOrEmpty(token)){ 
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
