using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.Compra
{
    public class PagoDTO
    {
        public decimal Monto { get; set; }             // Total a pagar
        public MetodoPago Metodo { get; set; }         // Enum: MercadoPago, Transferencia
        public string? NumeroTarjeta { get; set; }     // Opcional: si se simula tarjeta
        public string? CodigoSeguridad { get; set; }  // Opcional
        public string? Expiracion { get; set; }
        public DateTime? fechaPago { get; set; }
        public string? estado { get; set; }
    }
    public enum MetodoPago { MercadoPago, Transferencia }
}
