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
        public int orden { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public ImgProd() { }
        public ImgProd(string url, int ordern, int productoId)
        {
            Url = url;
            orden = ordern;
            ProductoId = productoId;
        }

    }
}
