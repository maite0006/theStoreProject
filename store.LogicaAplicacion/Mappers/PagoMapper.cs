using store.DTOs.Pago;
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
        public static Pago FromDTO(CrearPagoDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Metodo))
                throw new ArgumentException("El método de pago es obligatorio.");

            string metodoNormalizado = dto.Metodo.Trim().ToLower();

            MetodoPago metodo = metodoNormalizado switch
            {
                "transferencia" => MetodoPago.Transferencia,
                "mercadopago" => MetodoPago.MercadoPago,
                _ => throw new ArgumentException("Método de pago inválido.")
            };

            return new Pago
            {
                Metodo = metodo
            };
        }

        public static PagoDTO FromPago(Pago pago)
        {
            return new PagoDTO
            {
                Monto = pago.Monto,
                Metodo = pago.Metodo.ToString(),
                Estado = pago.Estado.ToString(),
                FechaPago = pago.FechaPago
            };
        }

    }
}
