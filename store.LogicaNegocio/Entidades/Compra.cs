using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Compra
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }
        public enum EstadoCompra
        {
            Pendiente,
            Procesando,
            Completada,
            Cancelada
        }
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Compra() { }
        public Compra(decimal total, string metodoPago, int clienteId)
        {
            Total = total;
            MetodoPago = metodoPago;
            ClienteId = clienteId;
        }
    }
}
