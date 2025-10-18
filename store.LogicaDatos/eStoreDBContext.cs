using Microsoft.EntityFrameworkCore;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaDatos
{
    public class eStoreDBContext : DbContext
    {
        public eStoreDBContext(DbContextOptions<eStoreDBContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Precompra> Precompras { get; set; }
        public DbSet<Reseña> Reseñas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ImgProd> ImgProds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración para la herencia TPH (Table Per Hierarchy)
            modelBuilder.Entity<Producto>()
                .HasDiscriminator<string>("ProductoTipo")
                .HasValue<Tapiz>("Tapiz")
                .HasValue<Cuadro>("Cuadro")
                .HasValue<Poster>("Poster");
            modelBuilder.Entity<Usuario>()
                .HasDiscriminator<string>("UsuarioTipo")
                .HasValue<Cliente>("Cliente")
                .HasValue<Administrador>("Administrador");

            // Configuración para las relaciones muchos a muchos entre Producto y Category
            modelBuilder.Entity<Producto>()
                .HasMany(p => p.Categorias)
                .WithMany(c => c.Productos)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductoCategory");
            // Configuración para las relaciones uno a muchos entre Cliente y Compra
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.HistorialCompras)
                .WithOne(HC => HC.Cliente)
                .HasForeignKey(cmp => cmp.ClienteId);
            // Configuración para las relaciones uno a uno entre Cliente y Precompra
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Precompra)
                .WithOne(pc => pc.Cliente)
                .HasForeignKey<Precompra>(pc => pc.ClienteId);

            // Configuración para las relaciones uno a muchos entre Cliente y Reseña
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Reseñas)
                .WithOne(r => r.Cliente)
                .HasForeignKey(r => r.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración para las relaciones uno a muchos entre Producto y Reseña
            modelBuilder.Entity<Producto>()
                .HasMany(p => p.Reseñas)
                .WithOne(r => r.Producto)
                .HasForeignKey(r => r.ProductoId)
                .OnDelete(DeleteBehavior.Cascade); 

            // Configuración para las relaciones uno a muchos entre Compra y Articulo   
            modelBuilder.Entity<Compra>()
                .HasMany(c => c.Articulos)
                .WithOne(a => a.Compra)
                .HasForeignKey(a => a.CompraId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración para las relaciones uno a muchos entre Precompra y Articulo
            modelBuilder.Entity<Precompra>()
                .HasMany(p => p.Articulos)
                .WithOne(a => a.Precompra)
                .HasForeignKey(a => a.PrecompraId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Producto ↔ ImgProd (1:N)
            modelBuilder.Entity<ImgProd>()
                .HasOne(i => i.Producto)
                .WithMany(p => p.Imagenes)
                .HasForeignKey(i => i.ProductoId);

            //Configuracion para campos unicos 
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Producto>().HasIndex(p => p.Nombre).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(c => c.Nombre).IsUnique();
            modelBuilder.Entity<Compra>().HasIndex(c => c.Guid).IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(u => u.Guid).IsUnique();
            modelBuilder.Entity<Producto>().HasIndex(p => p.Guid).IsUnique();

            //Keys
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Producto>().HasKey(p => p.Id);
            modelBuilder.Entity<Compra>().HasKey(c => c.Id);
            modelBuilder.Entity<Precompra>().HasKey(p => p.Id);
            modelBuilder.Entity<Reseña>().HasKey(r => new { r.ClienteId, r.ProductoId });
            modelBuilder.Entity<Articulo>().HasKey(a => a.Id);
            modelBuilder.Entity<Category>().HasKey(c => c.Id);

            //conf escalas en decimales
            modelBuilder.Entity<Producto>()
               .Property(p => p.Precio)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Compra>()
                .Property(c => c.Total)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Articulo>()
                .Property(a => a.PrecioUnitario)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Precompra>()
                .Property(pc => pc.Total)
                .HasColumnType("decimal(18,2)");

        }
    }
}
