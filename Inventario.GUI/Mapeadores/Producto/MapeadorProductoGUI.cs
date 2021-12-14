using Inventario.GUI.Models.Producto;
using LogicaNegocio.DTO.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Producto
{
    public class MapeadorProductoGUI : MapeadorBaseGUI<ProductoDTO, ModeloProducto>
    {
        public override ModeloProducto MapearTipo1Tipo2(ProductoDTO entrada)
        {
            return new ModeloProducto()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Fecha = entrada.Fecha,
                SerialProducto = entrada.SerialProducto,
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

        public override IEnumerable<ModeloProducto> MapearTipo1Tipo2(IEnumerable<ProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProductoDTO MapearTipo2Tipo1(ModeloProducto entrada)
        {
            return new ProductoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Fecha = DateTime.Now,
                SerialProducto ="8e9321kk1j11", //entrada.SerialProducto,
                Id_Marca = entrada.Id_Marca,
                Id_Categoria = entrada.Id_Categoria,
                Id_TipoProducto = entrada.Id_TipoProducto,
                Id_Espacio = entrada.Id_Espacio
            };
        }

        public override IEnumerable<ProductoDTO> MapearTipo2Tipo1(IEnumerable<ModeloProducto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}