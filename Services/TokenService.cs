using IdentityControleDeUsuario.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityUserControl.Services
{
    public class TokenService
    {
        public string GetToken(User user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("Username", user.UserName),
                new Claim("Id", user.Id),
                new Claim("DateOfBirth", user.DateOfBirth.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6SLMSDFSFD7jkdfsklsdfjdf7h78"));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(10),
                                            claims: claims,
                                            signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
