using EFCoreFirstAPI.Models;
using EFCoreFirstAPI.Models.DTOs;

namespace EFCoreFirstAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginResponseDTO> Autheticate(LoginRequestDTO loginUser);
        public Task<LoginResponseDTO> Register(UserCreateDTO registerUser);
    }
}
