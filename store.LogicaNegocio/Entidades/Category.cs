using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Category
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public Category() { }
        public Category( string nombre, int productoId)
        {
            
            Nombre = nombre;
            ProductoId = productoId;
        }
    }
}
