
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public  class Articulo
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int? CompraId { get; set; }
        public Compra? Compra { get; set; }
        public int? PrecompraId { get; set; }
        public Precompra? Precompra { get; set; }
        public Articulo() { }
        

        
        public Articulo(int productoId, int cantidad, decimal precioUnitario, int precompraId)
        {
            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            PrecompraId = precompraId;
        }

        public Articulo(int productoId, int cantidad, decimal precioUnitario, int compraId, bool esCompra)
        {
            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            CompraId = compraId;
        }


    }
}
