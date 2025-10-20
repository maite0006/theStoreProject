using store.DTOs.DTOs.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Pago
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public MetodoPago Metodo { get; set; }  // enum: MercadoPago, Transferencia, etc.
        public EstadoPago Estado { get; set; } = EstadoPago.Pendiente;// enum: Pendiente, Aprobado, Rechazado
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int CompraId { get; set; }   // FK explícita opcional
        public Compra Compra { get; set; }

        public Pago() { }
    }

    
    public enum EstadoPago { Pendiente, Aprobado, Rechazado }
}
