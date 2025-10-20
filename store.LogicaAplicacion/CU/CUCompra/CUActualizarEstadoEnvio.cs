using store.LogicaAplicacion.ICU.ICUCompra;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.CompraExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUCompra
{
    public class CUActualizarEstadoEnvio : ICUActualizarEstadoEnvio
    {
        private readonly IRepositorioCompras _repositorioCompras;
        public CUActualizarEstadoEnvio(IRepositorioCompras repositorioCompras)
        {
            _repositorioCompras = repositorioCompras;
        }

        public async Task<bool> ActualizarEstadoEnvio(int compraId, string nuevoEstado)
        {
            if (!Enum.TryParse<Compra.Estado>(nuevoEstado, true, out var nuevoEstadoEnum))
            
                throw new EstadodeCompraInvalido($"El estado '{nuevoEstado}' no es válido.");
            Compra c = await _repositorioCompras.FindByIdAsync(compraId);
            if(c == null)
                throw new EntityNotFound("Compra",compraId);
            if (c.EstadoCompra == nuevoEstadoEnum)
                throw new EstadodeCompraInvalido("El estado insertado es el mismo que el estado actual.");
            c.EstadoCompra = nuevoEstadoEnum;
            try
            {
                await _repositorioCompras.UpdateAsync(c);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }


            
            
        }
    }
}
