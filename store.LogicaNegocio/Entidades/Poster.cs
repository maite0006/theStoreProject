using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Poster: Producto
    {
        public string TipoPapel { get; set; }
        public string Acabado { get; set; }

        public Poster() { }
        public Poster(string nombre, decimal precio, string descripcion, int stock, string medidas, string tipoPapel, string acabado)
        {
            Nombre = nombre;
            Precio = precio;
            Descripcion = descripcion;
            Stock = stock;
            Medidas = medidas;
            TipoPapel = tipoPapel;
            Acabado = acabado;
        }
    }
}
