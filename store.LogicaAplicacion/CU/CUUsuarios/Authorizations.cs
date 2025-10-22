using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using store.DTOs.DTOs.User;
using store.DTOs.DTOs.User.Authorization;
using store.DTOs.Mappers;
using store.LogicaAplicacion.ICU.ICUUsuarios;
using store.LogicaDatos;
using store.LogicaNegocio.CustomExceptions.UserExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using store.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUUsuarios
{
    public class Authorizations : IAuthorizations
    {
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        private readonly JwtTokenService _JwtTokenService;
        private readonly eStoreDBContext _context;
        public Authorizations(IRepositorioUsuarios repositorioUsuarios, JwtTokenService jwt, eStoreDBContext context)          {
            _repositorioUsuarios = repositorioUsuarios;
            _JwtTokenService = jwt;
            _context = context;
        }

        public async Task<UserOutputDTO> LoginAsync(LoginDTO dto)
        {
           Usuario buscado = await _repositorioUsuarios.FindByEmail(dto.Email);
            if (buscado == null)
            {
                throw new NotExistingUser(dto.Email);
            }
            bool passwordMatch = Crypto.VerifyPasswordConBcrypt(dto.password, buscado.Password);
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
            if (dto.password != dto.confirmPassword)
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
                var precompra = new Precompra();
                user.Precompra = precompra;
                await _context.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("==> Error en AddAsync: " + ex.Message);
                throw new errorRegistro("Error al registrar el usuario: " + ex.Message);
                
            }
            UserInputDTO dtoInToken = new UserInputDTO
            {
                Id = user.Id,
                Email = user.Email,
                Rol = user.Rol
            };
            
            UserOutputDTO token = _JwtTokenService.GenerarToken(dtoInToken);
            Console.WriteLine("==> Token generado OK");
            return token;

        }
    }
}
