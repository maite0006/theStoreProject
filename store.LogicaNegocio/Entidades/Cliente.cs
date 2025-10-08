using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Cliente : Usuario
    {
        public string Pais { get; set; }
        public string Telefono { get; set; }
        public ICollection<Compra> HistorialCompras { get; set; } = new List<Compra>();
        public ICollection<Producto> ProductosFavoritos { get; set; } = new List<Producto>();
        public ICollection<Reseña> Reseñas { get; set; } = new List<Reseña>();
        public int PrecompraId { get; set; }
        public Precompra Precompra { get; set; }

        public Cliente() { }
        public Cliente(string nombre, string email, string password, string pais, string telefono)
        {
            Nombre = nombre;
            Email = email;
            Pais = pais;
            Telefono = telefono;
            setPassword(password);
        }

        public void AgregarProductoFavorito(Producto producto)
        {
            if (!ProductosFavoritos.Any(p => p.Id == producto.Id))
            {
                ProductosFavoritos.Add(producto);
            }
        }
        public void EliminarProductoFavorito(int productoId)
        {
            var producto = ProductosFavoritos.FirstOrDefault(p => p.Id == productoId);
            if (producto != null)
            {
                ProductosFavoritos.Remove(producto);
            }
        }

        public void AgregarReseña(Reseña reseña)
        {
            Reseñas.Add(reseña);
        }
        public void AgregarCompra(Compra compra)
        {
            HistorialCompras.Add(compra);
        }
        public void VaciarPrecompra()
        {
            Precompra = new Precompra { ClienteId = this.Id };
        }
        public override string GetRol()
        {
            return "Cliente";
        }
    }   
       
}
