using EFCoreFirstAPI.Interfaces;
using EFCoreFirstAPI.Models;
using EFCoreFirstAPI.Models.DTOs;
using EFCoreFirstAPI.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace EFCoreFirstAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> _userRepository;
        private readonly ILogger<UserService> _logger;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<string, User> userRepository, 
            ITokenService tokenService,
            ILogger<UserService> logger) 
        {
            _userRepository = userRepository;
            _logger = logger;
            _tokenService = tokenService;


        }
        public async Task<LoginResponseDTO> Autheticate(LoginRequestDTO loginUser)
        {
            var user = await _userRepository.Get(loginUser.Username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            HMACSHA256 hmac = new HMACSHA256(user.HashKey);
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));
            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != user.Password[i])
                {
                    throw new Exception("Invalid username or password");
                }
            }
            return new LoginResponseDTO()
            {
                Username = user.Username,
                Token = await _tokenService.GenerateToken(new UserTokenDTO()
                {
                    Username = user.Username,
                    Role = user.Role.ToString()
                })

            };
        }

        public async Task<LoginResponseDTO> Register(UserCreateDTO registerUser)
        {
            HMACSHA256 hmac = new HMACSHA256();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password));
            User user = new User()
            {
                Username = registerUser.Username,
                Password = passwordHash,
                HashKey = hmac.Key,
                Role = registerUser.Role
            };
            try
            {
                var addesUser = await _userRepository.Add(user);
                LoginResponseDTO response = new LoginResponseDTO()
                {
                    Username = user.Username
                };
                return response;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Could not register user");
                throw new Exception("Could not register user");
            }
        }

    }
}
