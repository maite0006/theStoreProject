using store.DTOs.DTOs.Producto;
using store.LogicaAplicacion.ICU.ICUProductos;
using store.LogicaAplicacion.Mappers;
using store.LogicaDatos.Repositorios;
using store.LogicaNegocio.CustomExceptions;
using store.LogicaNegocio.CustomExceptions.ProdExceptions;
using store.LogicaNegocio.Entidades;
using store.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaAplicacion.CU.CUProductos
{
    public class CUAltaProd : ICUAltaProd
    {
        private readonly IRepositorioProductos _repoProductos;
        private readonly IRepositorioCategorias _repoCategorias;
        private readonly IRepositorioUsuarios _repositorioUsuarios;
        public CUAltaProd(IRepositorioProductos repoProductos, IRepositorioCategorias repoCategorias,IRepositorioUsuarios repositorioUsuarios)
        {
            _repoProductos = repoProductos;
            _repoCategorias = repoCategorias;
            _repositorioUsuarios = repositorioUsuarios;
        }
        public async Task<AltaProdOutDTO> AgregarP(AltaProdInDTO dto, int admID)
        {
            Administrador adm = (Administrador)await _repositorioUsuarios.FindByIdAsync(admID);
            if (adm == null)
                throw new EntityNotFound("Administrador", admID);
            AltaProdOutDTO dtoOut= new AltaProdOutDTO();
            if (dto.Tipo != "tapiz" && dto.Tipo != "cuadro" && dto.Tipo != "poster")
            {
                throw new ProdInvalido("Tipo de producto no valido");
            }
            switch (dto.Tipo.ToLower())
            {
                case "tapiz":
                    Tapiz tapiz = ProdsMapper.MapToTapiz(dto);
                    dtoOut = await MapearCatsGuardar(tapiz, dto.Categorias);
                    adm.AsociarProducto(tapiz);
                    break;
                case "cuadro":
                    Cuadro cuadro = ProdsMapper.MapToCuadro(dto);
                    dtoOut = await MapearCatsGuardar(cuadro, dto.Categorias);
                    adm.AsociarProducto(cuadro);
                    break;
                case "poster":
                    Poster poster = ProdsMapper.MapToPoster(dto);
                    dtoOut = await MapearCatsGuardar(poster, dto.Categorias);
                    adm.AsociarProducto(poster);
                    break;
            }
            return dtoOut;

        }

        public async Task<AltaProdOutDTO> MapearCatsGuardar(Producto producto, List<int> categorias)
        {
            producto.Categorias = new List<Category>();
            foreach (var cat in categorias)
            {
                var Cat = await _repoCategorias.FindByIdAsync(cat);
                if (Cat == null) throw new EntityNotFound("Categoria", cat);
                producto.Categorias.Add(Cat);
            }
            await _repoProductos.AddAsync(producto);
            AltaProdOutDTO dtoOut= ProdsMapper.MapToAltaProdOutDTO(producto);
            return dtoOut;
        }
    }
}
