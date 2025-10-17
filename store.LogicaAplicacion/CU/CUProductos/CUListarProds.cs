using store.DTOs.DTOs.Producto;
using store.LogicaAplicacion.ICU.ICUProductos;
using store.LogicaAplicacion.Mappers;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUProductos
{
    public class CUListarProds : ICUListarProds
    {
        private readonly IRepositorioProductos _repositorioProds;
        public CUListarProds(IRepositorioProductos repositorioProds)
        {
            _repositorioProds = repositorioProds;
        }

        public async Task<ICollection<ProdDTO>> obtenerActivos()
        {
           ICollection<ProdDTO> activoDTOs= new List<ProdDTO>();
            ICollection<Producto> activos = await _repositorioProds.FindAvailable();
            foreach (Producto prod in activos)
            {
                ProdDTO prodDTO = ProdsMapper.fromProdtoDTO(prod);
                activoDTOs.Add(prodDTO);
            }
            return activoDTOs;

        }

        public async Task<ICollection<ProdDTO>> obtenerbyCategoria(string categoria)
        {
            ICollection<ProdDTO> prodsCatDTOs = new List<ProdDTO>();
            ICollection<Producto> prodsCat = await _repositorioProds.FindByCategoria(categoria);
            foreach (Producto prod in prodsCat)
            {
                ProdDTO prodDTO = ProdsMapper.fromProdtoDTO(prod);
                prodsCatDTOs.Add(prodDTO);
            }
            return prodsCatDTOs;
        }

        public async Task<ICollection<ProdDTO>> obtenerbyNameOrDescription(string texto)
        {
            ICollection<ProdDTO> prodsDesctDTOs = new List<ProdDTO>();
            ICollection<Producto> prodsDesc = await _repositorioProds.FindByNameOrDescription(texto);
            foreach (Producto prod in prodsDesc)
            {
                ProdDTO prodDTO = ProdsMapper.fromProdtoDTO(prod);
                prodsDesctDTOs.Add(prodDTO);
            }
            return prodsDesctDTOs;
        }

        public async Task<ICollection<ProdDTO>> obtenerbyPriceRange(int min, int max)
        {
            ICollection<ProdDTO> prodsPriceRangeDTOs = new List<ProdDTO>();
            ICollection<Producto> prodsPriceRange = await _repositorioProds.FindByPriceRange(min, max);
            foreach (Producto prod in prodsPriceRange)
            {
                ProdDTO prodDTO = ProdsMapper.fromProdtoDTO(prod);
                prodsPriceRangeDTOs.Add(prodDTO);
            }
            return prodsPriceRangeDTOs;
        }

        public async Task<ICollection<ProdDTO>> obtenerbytype(string type)
        {
            ICollection<ProdDTO> prodsTypeDTOs = new List<ProdDTO>();
            ICollection<Producto> prodsType = await _repositorioProds.FindByType(type);
            foreach (Producto prod in prodsType)
            {
                ProdDTO prodDTO = ProdsMapper.fromProdtoDTO(prod);
                prodsTypeDTOs.Add(prodDTO);
            }
            return prodsTypeDTOs;
        }

        public async Task<ICollection<ProdDTO>> obtenerTodos()
        {
            ICollection<ProdDTO> prodsDTOs = new List<ProdDTO>();
            ICollection<Producto> prods = await _repositorioProds.FindAllAsync();
            foreach (Producto prod in prods)
            {
                ProdDTO prodDTO = ProdsMapper.fromProdtoDTO(prod);
                prodsDTOs.Add(prodDTO);
            }
            return prodsDTOs;
        }
    }
}
