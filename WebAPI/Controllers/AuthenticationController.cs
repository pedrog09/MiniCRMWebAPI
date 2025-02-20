using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;
using WebAPI.Data;

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

        [HttpPost("login")]
        public async Task<ActionResult<LoginDto>> Login([FromBody] LoginDto loginDto)
        {
            var userKey = await _tokenRepositorio.GetUserKey(loginDto);
            
            if (string.IsNullOrEmpty(userKey))
            {
                return Unauthorized();
            }
                
            return Ok(new { userKey });
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginDto>> Register([FromBody] LoginDto loginDto)
        {
            var token = await _tokenRepositorio.GenerateToken(loginDto);
            
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }
                
            return Ok(new { token });
        }
    }
}
