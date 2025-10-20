using Microsoft.Identity.Client.Extensibility;
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
    public class CUVerHistorial : ICUVerHistorial
    {
        private readonly IRepositorioCompras _repositorioCompras;
        public CUVerHistorial(IRepositorioCompras repositorioCompras)
        {
            _repositorioCompras=repositorioCompras;
        }
        public async Task<List<CompraDTO>> HistorialCompras(int usuarioId)
        {
            List<CompraDTO> compraDTOs = new List<CompraDTO>();
            List<Compra> compras= await _repositorioCompras.FindAllAsync();
            List<Compra> comprasUser= compras.Where(c => c.ClienteId == usuarioId).ToList();
            foreach (Compra compra in comprasUser)
            {
                CompraDTO compraDTO = CompraMapper.fromCompra(compra);
                compraDTOs.Add(compraDTO);
            }
            return compraDTOs;
            
        }

        public async Task<List<CompraDTO>> HistorialComprasbyEstado(int usuarioId, string estado)
        {
            List<CompraDTO> compraDTOs = new List<CompraDTO>();
            List<Compra> compras = await _repositorioCompras.FindByEstado(estado);
            List<Compra> comprasUser = compras.Where(c => c.ClienteId == usuarioId).ToList();
            foreach (Compra compra in comprasUser)
            {
                CompraDTO compraDTO = CompraMapper.fromCompra(compra);
                compraDTOs.Add(compraDTO);
            }
            return compraDTOs;
        }

        public async Task <List<CompraDTO>> HistorialComprasbyFecha(int usuarioId, DateTime min, DateTime max)
        {
            List<CompraDTO> compraDTOs = new List<CompraDTO>();
            List<Compra> compras = await _repositorioCompras.FindByDateRange(min,max);
            List<Compra> comprasUser= compras.Where(c => c.ClienteId == usuarioId).ToList();
            foreach (Compra compra in comprasUser)
            {
                CompraDTO compraDTO = CompraMapper.fromCompra(compra);
                compraDTOs.Add(compraDTO);
            }
            return compraDTOs;
        }

        public async Task<List<CompraDTO>> HistorialComprasPending(int usuarioId)
        {
            List<CompraDTO> compraDTOs = new List<CompraDTO>();
            List<Compra> compras = await _repositorioCompras.FindPending();
            List<Compra> comprasUser = compras.Where(c => c.ClienteId == usuarioId).ToList();
            foreach (Compra compra in comprasUser)
            {
                CompraDTO compraDTO = CompraMapper.fromCompra(compra);
                compraDTOs.Add(compraDTO);
            }
            return compraDTOs;
        }

        
    }
}
