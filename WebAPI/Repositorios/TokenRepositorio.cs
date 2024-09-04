using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;

namespace WebAPI.Repositorios
{
    public class TokenRepositorio : ITokenRepositorio
    {


        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public TokenRepositorio(IConfiguration configuration, IUsuarioRepositorio usuarioRepositorio)
        {
            _configuration = configuration;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<string> GenerateToken(LoginDto loginDto)
        {
            var usuarioDatabase = await _usuarioRepositorio.BuscarPorNome(loginDto.UserName);

            if (loginDto.UserName != usuarioDatabase.Name || loginDto.Password != usuarioDatabase.Password)
            {
                return string.Empty;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var siginCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience = audience,
                claims: new[]
                {
                    new Claim(type: ClaimTypes.Name, usuarioDatabase.Name),
                    new Claim(type: ClaimTypes.Role, usuarioDatabase.Role),
                },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: siginCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;

        }
    }
}
