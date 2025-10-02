using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public abstract class Producto
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }= true;
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;
        public string Medidas { get; set; }
        public string Url { get; set; }
        ICollection<Category> Categorias { get; set; }



    }
}
