using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Cuadro: Producto
    {
        public string Autor { get; set; }
        public string Lienzo { get; set; }

        public Cuadro() { }
        public Cuadro(string nombre, decimal precio, string descripcion, int stock, string medidas, string autor, string lienzo)
        {
            Nombre = nombre;
            Precio = precio;
            Descripcion = descripcion;
            Stock = stock;
            Medidas = medidas;
            Autor = autor;
            Lienzo = lienzo;
        }
    }
}
