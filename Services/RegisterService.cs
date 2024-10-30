using AutoMapper;
using IdentityControleDeUsuario.Data.Dto;
using IdentityControleDeUsuario.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityControleDeUsuario.Services
{
    public class RegisterService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public RegisterService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(UserRegisterDTO userRegisterDTO)
        {
            User user = _mapper.Map<User>(userRegisterDTO);

            IdentityResult ret = await _userManager.CreateAsync(user, userRegisterDTO.Password);

            return ret;

        }
    }
}
