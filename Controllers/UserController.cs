using IdentityControleDeUsuario.Data.Dto;
using IdentityControleDeUsuario.Services;
using IdentityUserControl.Data.Dto;
using Microsoft.AspNetCore.Mvc;

namespace IdentityControleDeUsuario.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var ret = await _userService.Register(userRegisterDTO);

            if (ret.Succeeded) return Ok(ret);
            return BadRequest(ret);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var ret = await _userService.Login(userLoginDTO);
            return Ok(ret);
        }
    }
}
