using store.DTOs.DTOs.Compra;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.Mappers
{
    public class EnvioMapper
    {
        public static Envio FromDTO(EnvioDTO dto)
        {
            Envio envio = new Envio();
            envio.Ciudad = dto.Ciudad;
            envio.CodigoPostal = dto.CodigoPostal;
            envio.Direccion = dto.Direccion;
            envio.MetodoEnvio = dto.MetodoEnvio;
            envio.Pais=dto.Pais;
            return envio;

        }
        public static EnvioDTO FromEnvio(Envio envio)
        {
            EnvioDTO dto = new EnvioDTO();
            dto.MetodoEnvio=envio.MetodoEnvio;
            dto.Pais=envio.Pais;
            dto.Direccion=envio.Direccion;
            dto.Ciudad=envio.Ciudad;
            dto.CodigoPostal=envio.CodigoPostal;
            return dto;
        }
    }
}
