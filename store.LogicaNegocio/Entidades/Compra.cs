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
            Creada,
            Pendiente,      
            Pagada,          
            Fallida,
            Cancelada
        }
        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Envio Envio { get; set; }
        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
        public Compra() { }
       
    }
}
