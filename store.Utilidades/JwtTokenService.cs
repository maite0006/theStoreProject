using Microsoft.IdentityModel.Tokens;
using store.DTOs.DTOs.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace store.Utilidades
{
    public class JwtTokenService
    {
        private readonly string _claveSecreta;

        public JwtTokenService(string claveSecreta)
        {
            _claveSecreta = claveSecreta;
        }

        public UserOutputDTO GenerarToken(UserInputDTO usuario)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Rol)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_claveSecreta));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );
            UserOutputDTO dtoOut=new UserOutputDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return dtoOut;
        }

    }
}
