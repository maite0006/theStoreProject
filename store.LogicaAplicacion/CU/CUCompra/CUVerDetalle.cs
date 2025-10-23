using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.ICU.ICUCompra;
using store.LogicaAplicacion.Mappers;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCompra
{
    public class CUVerDetalle : ICUVerDetalle
    {
        private readonly IRepositorioCompras _repositorioCompras;
        public CUVerDetalle (IRepositorioCompras repositorioCompras)
        {
            _repositorioCompras = repositorioCompras;
        }
        public async Task<CompraDTO> VerDetalleCompra(Guid compraId)
        {
            Compra compra= await _repositorioCompras.FindByGuid(compraId);
            if (compra == null )
                throw new EntityNotFound("Compra", compraId);
            CompraDTO dto= CompraMapper.FromCompra(compra);
            return dto;

        }
    }
}
