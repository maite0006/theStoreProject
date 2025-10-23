using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Administrador: Usuario
    {
        public ICollection<Producto> ProductosPublicados { get; set; } = new List<Producto>();
        public Administrador() { }
       public Administrador(string nombre, string email, string password)
        {
            Nombre = nombre;
            Email = email;
            Password = password;
            Rol = "Administrador";
        }
        public override string GetRol()
        {
            return "Administrador";
        }
        public void AsociarProducto(Producto producto)
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
        public bool EliminarProducto(Guid productoGuid)
        {
            var producto = ProductosPublicados.FirstOrDefault(p => p.Guid == productoGuid);
            if (producto != null)
            {
                ProductosPublicados.Remove(producto);
                return true;
            }
            return false;

        }


    }
}
