using AccesoDeDatos.DbModel.Productos;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Producto
{
    public class MapeadorFotoProductoDatos : MapeadorbaseDatos<tb_fotos, FotoProductoDbModel>
    {
        public override FotoProductoDbModel MapearTipo1Tipo2(tb_fotos entrada)
        {
            return new FotoProductoDbModel()
            {
                Id = entrada.id,
                IdProducto = entrada.id_producto,
                NombreFoto = entrada.ruta
            };
        }

        public override IEnumerable<FotoProductoDbModel> MapearTipo1Tipo2(IEnumerable<tb_fotos> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_fotos MapearTipo2Tipo1(FotoProductoDbModel entrada)
        {
            return new tb_fotos()
            {
                id = entrada.Id,
                id_producto = entrada.IdProducto,
                ruta = entrada.NombreFoto
            };
        }

        public override IEnumerable<tb_fotos> MapearTipo2Tipo1(IEnumerable<FotoProductoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
