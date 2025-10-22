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
        public void AgregarArticulo(Articulo articulo)
        {
            var articuloExistente = Articulos.FirstOrDefault(a => a.ProductoId == articulo.ProductoId);
            if (articuloExistente != null)
            {
                articuloExistente.Cantidad += articulo.Cantidad;
                articuloExistente.PrecioUnitario = articulo.PrecioUnitario; // Actualiza el precio unitario si es necesario
            }
            else
            {
                Articulos.Add(articulo);
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
                return Articulos.Sum(a => a.Cantidad * a.PrecioUnitario);
            }
            catch
            {
                return 0;
            }


        }

        
    }


}

