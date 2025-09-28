using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Aministrador: Usuario
    {
        public List<Producto> ProductosPublicados { get; set; } = new List<Producto>();
        public Aministrador() { }
       public Aministrador(string nombre, string email, string password)
        {
            Nombre = nombre;
            Email = email;
            Password = password;
        }
    }
}
