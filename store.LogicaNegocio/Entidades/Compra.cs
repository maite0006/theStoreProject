using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Compra
    {
        public int Id { get; set; }//PK interna de la base de datos, autoincremental
        public Guid Guid { get; set; } = Guid.NewGuid(); //ID pública para exponer las compras
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public Estado EstadoCompra { get; set; } = Estado.Pendiente;
        public enum Estado
        {
            Pendiente,      // creada pero aún sin pagar
            Pagada,         // pago confirmado
            EnPreparacion,  // preparando envío
            Enviada,
            Completada,
            Cancelada
        }
        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Pago Pago { get; set; }
        public Envio Envio { get; set; }

        public Compra() { }
       
    }
}
