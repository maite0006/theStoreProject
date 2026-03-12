using store.DTOs.DTOs.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static store.LogicaNegocio.Entidades.Compra;

namespace store.LogicaNegocio.Entidades
{
    public class Pago
    {
        public int Id { get; set; }

        public int CompraId { get; set; }
        public Compra Compra { get; set; }

        public decimal Monto { get; set; }

        public MetodoPago Metodo { get; set; }

        public DateTime? FechaPago { get; private set; }

        public EstadoPago Estado { get; private set; } = EstadoPago.Pendiente;

        public string? GatewayPaymentId { get; set; }
        public Pago() { }
        public void Confirmar()
        {
            if (Estado == EstadoPago.Aprobado)
                throw new InvalidOperationException("El pago ya fue confirmado");

            Estado = EstadoPago.Aprobado;
            FechaPago = DateTime.Now;
        }
    }

    public enum MetodoPago { MercadoPago, Transferencia }
    public enum EstadoPago { Pendiente, Aprobado, Rechazado }

}
