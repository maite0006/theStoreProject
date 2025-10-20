
using store.DTOs.DTOs.Compra;
using store.LogicaAplicacion.ICU.ICUCompra;
using store.LogicaAplicacion.Mappers;
using store.LogicaDatos;
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
    public class CUConfiguracionCompra : ICUConfigurarCompra
    {
        private readonly IRepositorioCompras _repositorioCompras;
        private readonly eStoreDBContext _dbContext;
        public CUConfiguracionCompra(IRepositorioCompras repositorioCompras, eStoreDBContext eStore)
        {
            _repositorioCompras=repositorioCompras;
            _dbContext = eStore;
        }
        public async  Task<int> ConfiguraciónCompra(int compraid, PagoDTO dtoPago, EnvioDTO dtoEnvio)
        {
            Compra c= await _repositorioCompras.FindByIdAsync(compraid);
            if (c==null)
                throw new EntityNotFound("Compra", compraid);
            Pago pago = PagoMapper.FromDTO(dtoPago);
            pago.CompraId=compraid;

            Envio envio= EnvioMapper.FromDTO(dtoEnvio);
            envio.CompraId = compraid;

            c.Envio = envio;
            c.Pago = pago;

            _dbContext.Pagos.Add(pago);
            _dbContext.Envios.Add(envio);

            await _dbContext.SaveChangesAsync();
            return c.Id;


        }
    }
}
