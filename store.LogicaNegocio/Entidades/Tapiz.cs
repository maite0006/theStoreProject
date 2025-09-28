using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Tapiz : Producto
    {
        public string TipoTela { get; set; }
        public string Grosor { get; set; }

        public Tapiz(){}
        public Tapiz(string nombre, decimal precio, string descripcion, int stock, string medidas, string tipoTela, string grosor)
        {
            Nombre = nombre;
            Precio = precio;
            Descripcion = descripcion;
            Stock = stock;
            Medidas = medidas;
            TipoTela = tipoTela;
            Grosor = grosor;
        }

    }
}
