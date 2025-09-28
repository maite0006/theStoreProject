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
        public List<Articulo> Articulos { get; set; } = new List<Articulo>();

        public Precompra() { }
    }
}
