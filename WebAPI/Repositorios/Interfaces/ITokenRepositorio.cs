using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Repositorios.Interfaces
{
    public interface ITokenRepositorio
    {
        Task <string?> GenerateToken(LoginDto loginDto);
    }
}
