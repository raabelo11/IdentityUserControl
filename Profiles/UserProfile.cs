using AutoMapper;
using IdentityControleDeUsuario.Data.Dto;
using IdentityControleDeUsuario.Models;

namespace IdentityControleDeUsuario.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDTO, User>();
        }
    }
}
