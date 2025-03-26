﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Repositorios
{
    public class TokenRepositorio : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SistemaDeTarefasDBContext _context;

        public TokenRepositorio(IConfiguration configuration, SistemaDeTarefasDBContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<string?> GetUserKey(LoginDto loginDto)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Name == loginDto.UserName && u.Password == loginDto.Password);

            return user.UserKey;
        }

        public async Task<string?> GenerateToken(LoginDto loginDto)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Name == loginDto.UserName && u.Password == loginDto.Password);

            if (user == null)
                return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
