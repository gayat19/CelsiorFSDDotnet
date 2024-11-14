using EFCoreFirstAPI.Interfaces;
using EFCoreFirstAPI.Misc;
using EFCoreFirstAPI.Models.DTOs;
using EFCoreFirstAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [CustomExceptionFilter]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<LoginResponseDTO>> Register(UserCreateDTO createDTO)
        {
               if(ModelState.IsValid)
                {
                    var user = await _userService.Register(createDTO);
                    return Ok(user);
                }
                else
                {
                    throw new Exception("one or more validation errors");
                }
            
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO requestDTO)
        {
            var user = await _userService.Autheticate(requestDTO);
            return Ok(user);
        }
    }
}
