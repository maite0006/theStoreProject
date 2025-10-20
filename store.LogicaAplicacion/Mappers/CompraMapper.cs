using store.DTOs.DTOs.Articulo;
using store.DTOs.DTOs.Compra;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.Mappers
{
    public class CompraMapper
    {
        public static CompraDTO fromCompra(Compra compra)
        {
            CompraDTO ret = new CompraDTO();
            ret.CompraId = compra.Id;
            ret.Total=compra.Total;
            ret.EstadoCompra=compra.EstadoCompra.ToString();
            foreach (var item in compra.Articulos) {
                ArticuloCarritoDTO art = ArticuloMapper.fromArticulo(item);
                ret.Articulos.Add(art);
            }
            if (compra.Pago != null)
                ret.Pago=PagoMapper.FromPago(compra.Pago);

            if (compra.Envio != null)
                  ret.Envio=EnvioMapper.FromEnvio(compra.Envio);
          
            return ret;
        }

    }
}
