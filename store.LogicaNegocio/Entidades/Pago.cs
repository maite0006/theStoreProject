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
        public MetodoPago Metodo { get; set; }  
        public EstadoPago Estado { get; set; } = EstadoPago.Pendiente;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int CompraId { get; set; }   
        public Compra Compra { get; set; }

        public Pago() { }
    }

    
    public enum EstadoPago { Pendiente, Aprobado, Rechazado }
}
