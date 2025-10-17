using store.DTOs.DTOs.Producto;
using store.LogicaNegocio.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace store.LogicaAplicacion.Mappers
{
    public class ProdsMapper
    {
        public static ProdDTO fromProdtoDTO(Producto prod)
        {
            ProdDTO prodDTO = new ProdDTO
            {
                Nombre = prod.Nombre,
                Tipo = prod.GetType().Name,
                Precio = prod.Precio,
                Descripcion = prod.Descripcion,
                Stock = prod.Stock,
                Medidas = prod.Medidas,

            };
            switch(prod)
            {
                case Tapiz t:

                    prodDTO.Grosor = t.Grosor;
                    prodDTO.TipoTela = t.TipoTela;
                    break;
                case Cuadro c:
                    prodDTO.Autor = c.Autor;
                    prodDTO.Lienzo = c.Lienzo;
                    break;
                case Poster p:
                    prodDTO.Acabado = p.Acabado;
                    prodDTO.TipoPapel = p.TipoPapel;
                    break;
                }

            return prodDTO;
            }
       public static Tapiz MapToTapiz(AltaProdInDTO dto)
        {
            Tapiz tapiz = new Tapiz
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Medidas = dto.Medidas,
                TipoTela = dto.TipoTela,
                Grosor = dto.Grosor
                 
            };
            return tapiz;
        }
        public static Cuadro MapToCuadro(AltaProdInDTO dto)
        {
            Cuadro cuadro = new Cuadro
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Medidas = dto.Medidas,
                Autor = dto.Autor,
                Lienzo = dto.Lienzo
            };
            return cuadro;
        }
        public static Poster MapToPoster(AltaProdInDTO dto)
        {
            Poster poster = new Poster
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Medidas = dto.Medidas,
                TipoPapel = dto.TipoPapel,
                Acabado = dto.Acabado
            };
            return poster;
        }
        public static AltaProdOutDTO MapToAltaProdOutDTO(Producto producto)
        {
            return new AltaProdOutDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Tipo = producto.GetType().Name.ToLower()
            };
        }
    }
}
