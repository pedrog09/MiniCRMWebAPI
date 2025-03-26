using WebAPI.DTOs;

namespace WebAPI.Repositorios.Interfaces
{
    public interface ITokenRepositorio
    {
        Task<string?> GetUserKey(LoginDto loginDto);
        Task<string?> GenerateToken(LoginDto loginDto);
    }
}
