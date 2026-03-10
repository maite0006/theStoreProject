using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.ICU.ICUCompra.ICUEnvio;
using store.LogicaAplicacion.Mappers;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCompra.CUEnvio
{
    public class CUListarEnvios : ICUListarEnvios
    {
        private readonly IRepositorioCompras _repositorioCompras;
        private List<Envio> Envios;
        public CUListarEnvios(IRepositorioCompras repositorioCompras)
        {
            _repositorioCompras = repositorioCompras;
        }
        
        public async Task<List<EnvioDTO>> HistorialEnvios()
        {
            List<Compra> compras= await _repositorioCompras.FindAllAsync();
            List<EnvioDTO> envioDTOs = new List<EnvioDTO>();
            foreach (Compra c in compras)
            {
                Envios.Add(c.Envio);
                EnvioDTO dto= EnvioMapper.FromEnvio(c.Envio);
                envioDTOs.Add(dto);
            }

            return envioDTOs;
        }

        public Task<List<EnvioDTO>> HistorialEnviosNF()
        {
            Task<List<EnvioDTO>> envioDTOs = HistorialEnvios();
            return envioDTOs;

        }

        public Task<List<EnvioDTO>> HistorialEnviosU(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EnvioDTO>> HistorialEnviosUNF(int usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}
