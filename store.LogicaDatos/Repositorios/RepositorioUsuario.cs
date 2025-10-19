using Microsoft.EntityFrameworkCore;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuarios
    {
        private readonly eStoreDBContext _context;

        public RepositorioUsuario(eStoreDBContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Usuario nuevo)
        {
            await _context.Usuarios.AddAsync(nuevo);
            await _context.SaveChangesAsync();
            return nuevo.Id;
        }

        public async Task<List<Usuario>> FindAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> FindByEmail(string email)
        {
           
                return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> FindByNombre(string nombre)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Nombre.Contains(nombre));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Usuario obj)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Guid == obj.Guid);
            if (usuario == null) return false;

            usuario.Nombre = obj.Nombre;
            usuario.Email = obj.Email;
            usuario.Password = obj.Password;
            if (usuario is Cliente cliente && obj is Cliente clienteActualizado)
            {
                cliente.Telefono = clienteActualizado.Telefono;
                cliente.Pais = clienteActualizado.Pais;
            }

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
