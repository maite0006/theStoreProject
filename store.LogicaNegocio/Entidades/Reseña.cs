using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Reseña
    {
        public int Id { get; set; }
        public int Puntuacion { get; set; } // 1 a 5
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Reseña() { }
        public Reseña(int puntuacion, string comentario, int productoId, int clienteId)
        {
            Puntuacion = puntuacion;
            Comentario = comentario;
            ProductoId = productoId;
            ClienteId = clienteId;
        }
    }
}
