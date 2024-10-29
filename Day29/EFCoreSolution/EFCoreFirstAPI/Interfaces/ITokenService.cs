
using EFCoreFirstAPI.Models.DTOs;

namespace EFCoreFirstAPI.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserTokenDTO user);
    }
}
