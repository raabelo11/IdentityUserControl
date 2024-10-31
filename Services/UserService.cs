using AutoMapper;
using IdentityControleDeUsuario.Data.Dto;
using IdentityControleDeUsuario.Models;
using IdentityUserControl.Data.Dto;
using IdentityUserControl.Services;
using Microsoft.AspNetCore.Identity;

namespace IdentityControleDeUsuario.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager,
               TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<IdentityResult> Register(UserRegisterDTO userRegisterDTO)
        {
            User user = _mapper.Map<User>(userRegisterDTO);

            IdentityResult ret = await _userManager.CreateAsync(user, userRegisterDTO.Password);

            return ret;
        }

        public async Task<string> Login(UserLoginDTO userLoginDTO)
        {
            SignInResult ret = await _signInManager.PasswordSignInAsync(userLoginDTO.Username, userLoginDTO.Password, false, false);

            if (!ret.Succeeded)
            {
                throw new Exception("Usuário inválido!");
            }

            var user = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == userLoginDTO.Username.ToUpper());

            var token = _tokenService.GetToken(user);

            return token;
        }
    }
}
