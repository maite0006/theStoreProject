using store.DTOs.DTOs.User.Authorization;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.Mappers
{
    public class AuthsMapper
    {
        public static Cliente MapToCliente(RegistroDTO dto)
        {
            return new Cliente
            {
                Nombre = dto.name,
                Email = dto.Email,
                Pais = dto.pais,
                Telefono = dto.telefono,
            };
        }
    }
}
