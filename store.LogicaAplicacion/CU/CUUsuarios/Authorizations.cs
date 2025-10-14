using Microsoft.IdentityModel.Tokens;
using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaNegocio.IRepositorios;
using store.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using store.LogicaNegocio.CustomExceptions.UserExceptions;
using store.LogicaNegocio.Entidades;
using store.DTOs.DTOs.User.Authorization;
using Microsoft.EntityFrameworkCore.Infrastructure;
using store.DTOs.Mappers;
using store.DTOs.DTOs.User;

namespace store.LogicaAplicacion.CU.CUUsuarios
{
    public class Authorizations : IAuthorizations
    {
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        private readonly JwtTokenService _JwtTokenService;
        public Authorizations(IRepositorioUsuarios repositorioUsuarios, JwtTokenService jwt)          {
            _repositorioUsuarios = repositorioUsuarios;
            _JwtTokenService = jwt;
        }

        public async Task<UserOutputDTO> LoginAsync(LoginDTO dto)
        {
           Usuario buscado = await _repositorioUsuarios.FindByEmail(dto.Email);
            if (buscado == null)
            {
                throw new NotExistingUser(dto.Email);
            }
            bool passwordMatch = Crypto.VerifyPasswordConBcrypt(buscado.Password, dto.password);
            if (!passwordMatch)
            {
                throw new IncorrectPassword();
            }
            UserInputDTO dtoInToken = new UserInputDTO
            {
                Id = buscado.Id,
                Email = buscado.Email,
                Rol = buscado.Rol
            };
            UserOutputDTO token = _JwtTokenService.GenerarToken(dtoInToken);
            return token;
        }

        public async Task<UserOutputDTO> RegistrarAsync(RegistroDTO dto)
        {
            if(dto.password!= dto.confirmPassword)
            {
                throw new PasswordsDontMatch();
            }
            Usuario buscado = await _repositorioUsuarios.FindByEmail(dto.Email);
            if (buscado != null)
            {
                throw new ExistingUser(dto.Email);
            }
            var user= AuthsMapper.MapToCliente(dto);
            user.Password = Crypto.HashPasswordConBcrypt(dto.password,12);
            try
            {
               await _repositorioUsuarios.AddAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el usuario: " + ex.Message);
            }
            UserInputDTO dtoInToken = new UserInputDTO
            {
                Id = user.Id,
                Email = user.Email,
                Rol = user.Rol
            };
            UserOutputDTO token = _JwtTokenService.GenerarToken(dtoInToken);
            return token;
        }
    }
}
