using store.LogicaDatos;
using store.LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using store.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaDatos
{
    public class DBSeeding
    {
        public static async Task SeedAsync(eStoreDBContext context)
        {
        
            await context.Database.EnsureCreatedAsync();

   
            var adminEmail = "admin@store.com";
            var adminExists = await context.Usuarios.AnyAsync(u => u.Email == adminEmail || u.Rol == "Administrador");
            if (!adminExists)
            {
               
                var rawPassword = "Admin123!"; 
                var hashed = Crypto.HashPasswordConBcrypt(rawPassword, 12);

                var admin = new Administrador(
                    nombre: "Admin Principal",
                    email: adminEmail,
                    password: hashed  // ya hasheada
                );

                context.Usuarios.Add(admin);
            }

           
            if (!await context.Categories.AnyAsync())
            {
                var categorias = new List<Category>
                {
                    new Category("Películas"),
                    new Category("Música"),
                    new Category("Ilustraciones"),
                    new Category("Fotografía"),
                    new Category("Diseño Digital")
                };

                context.Categories.AddRange(categorias);
            }

            await context.SaveChangesAsync();
        }
    }
}




