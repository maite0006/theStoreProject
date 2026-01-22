using store.LogicaNegocio.CustomExceptions.ArticuloExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Precompra
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();

        public Precompra() { }
        public Precompra(int clienteId)
        {
            ClienteId = clienteId;
        }
        public void ActualizarCantidadArticulo(Producto producto, int cantidadDelta)
        {
            if (!producto.Activo)
                throw new ErrorFlujoArticulo("El producto no está activo.");

            Articulo articulo = Articulos
                .FirstOrDefault(a => a.ProductoId == producto.Id);
            if (articulo == null)
            {
                if (cantidadDelta <= 0)
                    throw new ErrorFlujoArticulo(
                        "No se puede quitar un artículo que no existe en el carrito."
                    );

                if (cantidadDelta > producto.Stock)
                    throw new CantidadArticuloInvalida(
                        "No hay stock suficiente para agregar el artículo."
                    );
                Articulo nuevo = new Articulo();
                nuevo.ProductoId = producto.Id;
                nuevo.Producto= producto;
                nuevo.Cantidad = cantidadDelta;
                nuevo.PrecioUnitario = producto.Precio;
                Articulos.Add(nuevo);

                CalcularTotal();
                return;
            }
            int nuevaCantidad = articulo.Cantidad + cantidadDelta;

            if (nuevaCantidad > producto.Stock)
                throw new CantidadArticuloInvalida(
                    "No hay stock suficiente para la cantidad solicitada."
                );

            if (nuevaCantidad <= 0)
            {
                Articulos.Remove(articulo);
            }
            else
            {
                articulo.Cantidad = nuevaCantidad;
                articulo.PrecioUnitario = producto.Precio;
            }
            CalcularTotal();
        }

        public void EliminarArticulo(int productoId)
        {
            var articulo = Articulos.FirstOrDefault(a => a.ProductoId == productoId);
            if (articulo != null)
            {
                Articulos.Remove(articulo);
                CalcularTotal();
            }
        }
        
           
        public decimal CalcularTotal()
        {
            try
            {
                decimal total = 0;
                foreach (var art in Articulos)
                {
                    if (art.EvaluarDisponibilidad(art.Producto.Stock, art.Producto.Activo))
                    {
                        total += art.Cantidad * art.PrecioUnitario;
                    }
                }
                return total;
            }
            catch
            {
                return 0;
            }


        }

        public void Vaciar()
        {
            Articulos.Clear();
        }


    }


}

