using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Aministrador: Usuario
    {
        public ICollection<Producto> ProductosPublicados { get; set; } = new List<Producto>();
        public Aministrador() { }
       public Aministrador(string nombre, string email, string password)
        {
            Nombre = nombre;
            Email = email;
            Password = password;
       }
        public override string GetRol()
        {
            return "Administrador";
        }
        public void PublicarProducto(Producto producto)//Reevaluar metodo
        {
            ProductosPublicados.Add(producto);
        }
        public bool EliminarProducto(int productoId)
        {
            var producto = ProductosPublicados.FirstOrDefault(p => p.Id == productoId);
            if (producto != null)
            {
                ProductosPublicados.Remove(producto);
                return true;
            }
            return false;

        }


    }
}
