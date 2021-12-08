using AccesoDeDatos.DbModel.Productos;
using LogicaNegocio.DTO.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Producto
{
    public class MapeadorProductoLogica : MapeadorBaseLogica<ProductoDbModel, ProductoDTO>
    {
        public override ProductoDTO MapearTipo1Tipo2(ProductoDbModel entrada)
        {
            return new ProductoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Fecha = entrada.Fecha,
                SerialProducto= entrada.SerialProducto,
                Id_Marca = entrada.Id_Marca,
                Id_Categoria = entrada.Id_Categoria,
                Id_TipoProducto = entrada.Id_TipoProducto,
                Id_Espacio = entrada.Id_Espacio,
                NombreMarca = entrada.NombreMarca,
                NombreCategoria = entrada.NombreCategoria,
                NombreEspacio = entrada.NombreEspacio,
                NombreTipoProducto = entrada.NombreTipoProducto
            };
        }

        public override IEnumerable<ProductoDTO> MapearTipo1Tipo2(IEnumerable<ProductoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProductoDbModel MapearTipo2Tipo1(ProductoDTO entrada)
        {
            return new ProductoDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Fecha = entrada.Fecha,
                SerialProducto = entrada.SerialProducto,
                Id_Marca = entrada.Id_Marca,
                Id_Categoria = entrada.Id_Categoria,
                Id_TipoProducto = entrada.Id_TipoProducto,
                Id_Espacio = entrada.Id_Espacio
            };
        }

        public override IEnumerable<ProductoDbModel> MapearTipo2Tipo1(IEnumerable<ProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
