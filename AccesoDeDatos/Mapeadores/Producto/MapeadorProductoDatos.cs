using AccesoDeDatos.DbModel.Productos;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Producto
{
    public class MapeadorProductoDatos : MapeadorbaseDatos<tb_producto, ProductoDbModel>
    {
        public override ProductoDbModel MapearTipo1Tipo2(tb_producto entrada)
        {
            return new ProductoDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Fecha  = entrada.fecha,
                SerialProducto = entrada.serial_producto,
                Id_Marca = entrada.id_marca,
                Id_Categoria = entrada.id_categoria,
                Id_TipoProducto = entrada.id_tipoProducto,
                Id_Espacio = entrada.id_espacio,
                NombreMarca = entrada.tb_marca.nombre,
                NombreCategoria = entrada.tb_categoria.nombre,
                NombreTipoProducto = entrada.tb_tipo_producto.nombre,
                NombreEspacio = entrada.tb_espacio.nombre
            };
        }

        public override IEnumerable<ProductoDbModel> MapearTipo1Tipo2(IEnumerable<tb_producto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_producto MapearTipo2Tipo1(ProductoDbModel entrada)
        {
            return new tb_producto()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                fecha = entrada.Fecha,
                serial_producto= entrada.SerialProducto,
                id_marca = entrada.Id_Marca,
                id_categoria = entrada.Id_Categoria,
                id_tipoProducto = entrada.Id_TipoProducto,
                id_espacio = entrada.Id_Espacio
            };
        }

        public override IEnumerable<tb_producto> MapearTipo2Tipo1(IEnumerable<ProductoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
