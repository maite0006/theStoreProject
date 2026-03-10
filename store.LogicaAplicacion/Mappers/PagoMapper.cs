using store.DTOs.DTOs.Compra;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.Mappers
{
    public class PagoMapper
    {
        public static Pago FromDTO(PagoDTO dto)
        {
            Pago pago = new Pago();
            pago.Monto= dto.Monto;
            if(dto.Metodo.ToLower() == "mercadopago") 
                pago.Metodo = MetodoPago.MercadoPago;
            else if(dto.Metodo.ToLower() == "transferencia")
                pago.Metodo = MetodoPago.Transferencia;
            return pago;
        }
        public static PagoDTO FromPago(Pago pago)
        {
            PagoDTO dto = new PagoDTO();
            dto.Monto = pago.Monto;
            dto.Metodo = pago.Metodo.ToString();
            dto.estado=pago.Estado.ToString();
            if(pago.Fecha!=null)
                dto.fechaPago=pago.Fecha;
            return dto;
        }
    }
}
