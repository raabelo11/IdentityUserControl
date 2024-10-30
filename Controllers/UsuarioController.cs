using AutoMapper;
using IdentityControleDeUsuario.Data.Dto;
using IdentityControleDeUsuario.Models;
using IdentityControleDeUsuario.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityControleDeUsuario.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private RegisterService _registerService;

        public UsuarioController(RegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var ret = await _registerService.Register(userRegisterDTO);

            if (ret.Succeeded) return Ok(ret);
            return BadRequest(ret);
        }
    }
}
