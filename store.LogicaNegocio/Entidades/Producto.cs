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
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public bool Activo { get; set; }= true;
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;
        public string Medidas { get; set; }
        public ICollection<Category> Categorias { get; set; }= new List<Category>();
        public ICollection<Reseña> Reseñas { get; set; } = new List<Reseña>();

        public ICollection<ImgProd> Imagenes { get; set; } = new List<ImgProd>();

    }
}
