using WebAPI.DTOs;

namespace WebAPI.Repositorios.Interfaces
{
    public interface ITokenRepository
    {
        Task<string?> GetUserKey(LoginDto loginDto);
        Task<string?> GenerateToken(LoginDto loginDto);
    }
}
