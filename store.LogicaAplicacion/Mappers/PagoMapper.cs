using store.DTOs.DTOs.Compra;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.Mappers
{
    public static class PagoMapper
    {
        public static Pago FromDTO(PagoDTO dto)
        {
            Pago pago = new Pago();

            pago.Monto = dto.Monto;
            if(pago.Metodo.ToString().ToLower()== "transferencia ")
                dto.Metodo="transferencia";
            if(pago.Metodo.ToString().ToLower()== "mercadopago")
                dto.Metodo="mercadopago";
            return pago;
        }

        public static PagoDTO FromPago(Pago pago)
        {
            PagoDTO dto = new PagoDTO();

            dto.Monto = pago.Monto;
            if(dto.Metodo.ToLower() == "transferencia ")
                pago.Metodo = MetodoPago.Transferencia;
            if(dto.Metodo.ToLower() == "mercadopago") 
                pago.Metodo = MetodoPago.MercadoPago;

            return dto;
        }
    
    }
}
