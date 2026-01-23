using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.ICU.ICUCompra;
using store.LogicaAplicacion.Mappers;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCompra
{
    public class CUHistorialGeneralCompras:ICUHistorialGeneralCompras
    {
        private readonly IRepositorioCompras _repositorioCompras;
        public CUHistorialGeneralCompras(IRepositorioCompras repositorioCompras)
        {
            _repositorioCompras = repositorioCompras;
        }

        public async Task<List<CompraDTO>> HistorialComprasbyEstadoEnvio(string estado)
        {
            List<CompraDTO> compraDTOs = new List<CompraDTO>();
            List<Compra> compras = await _repositorioCompras.FindByEstado(estado);
            foreach (Compra compra in compras)
            {
                CompraDTO compraDTO = CompraMapper.FromCompra(compra);
                compraDTOs.Add(compraDTO);
            }
            return compraDTOs;
        }

        public async Task<List<CompraDTO>> HistorialComprasbyFecha(DateTime min, DateTime max)
        {
            List<CompraDTO> compraDTOs = new List<CompraDTO>();
            List<Compra> compras = await _repositorioCompras.FindByDateRange(min, max);
            foreach (Compra compra in compras)
            {
                CompraDTO compraDTO = CompraMapper.FromCompra(compra);
                compraDTOs.Add(compraDTO);
            }
            return compraDTOs;
        }

        public async Task<List<CompraDTO>> HistorialComprasPending()
        {
            List<CompraDTO> compraDTOs = new List<CompraDTO>();
            List<Compra> compras = await _repositorioCompras.FindPending();
            foreach (Compra compra in compras)
            {
                CompraDTO compraDTO = CompraMapper.FromCompra(compra);
                compraDTOs.Add(compraDTO);
            }
            return compraDTOs;
        }

        public async Task<List<CompraDTO>> HistorialGeneral()
        {
            List<CompraDTO> compraDTOs = new List<CompraDTO>();
            List<Compra> compras = await _repositorioCompras.FindAllAsync();
            foreach (Compra compra in compras)
            {
                CompraDTO compraDTO = CompraMapper.FromCompra(compra);
                compraDTOs.Add(compraDTO);
            }
            return compraDTOs;
        }
    }
}
