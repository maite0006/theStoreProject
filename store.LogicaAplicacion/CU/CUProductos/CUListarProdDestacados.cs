using store.DTOs.DTOs.Producto;
using store.LogicaAplicacion.ICU.ICUProductos;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUProductos
{
    public class CUListarProductosDestacados : ICUListarProdDestacados
    {
        private readonly IRepositorioProductos _repo;

        public CUListarProductosDestacados(IRepositorioProductos repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProdDestacadoDTO>> Ejecutar()
        {
            var productos = await _repo.FindAllAsync();

            return productos
                .Where(p => p.Activo && p.EsDestacado)
                .Select(p => new ProdDestacadoDTO
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    Precio = p.Precio,
                    ImagenUrl= p.Imagenes
                    .OrderBy(i => i.orden)
                    .Select(i => i.Url)
                    .FirstOrDefault(),
                })
                .ToList();
        }
    }

}
