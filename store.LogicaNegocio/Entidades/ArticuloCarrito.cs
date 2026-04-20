
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public  class ArticuloCarrito
    {
        public int Id { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int PrecompraId { get; set; }
        public Precompra Precompra { get; set; }

       
        public bool EvaluarDisponibilidad(int stockActual, bool productoActivo)
            => productoActivo && stockActual >= Cantidad;


      public ArticuloCarrito(int cantidad, decimal precioUnitario, int productoId)
        {
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            ProductoId = productoId;
        }
        public ArticuloCarrito()
        {
        }



    }
}
