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

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();


        public Category() { }
        public Category( string nombre)
        {
            
            Nombre = nombre;
           
        }
    }
}
