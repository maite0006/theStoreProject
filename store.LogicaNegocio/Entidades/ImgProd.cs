using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class ImgProd
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Orden { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public ImgProd() { }
        public ImgProd( string url, int orden, int productoId)
        {
            Url = url;
            Orden = orden;
            ProductoId = productoId;
        }
    }
}
