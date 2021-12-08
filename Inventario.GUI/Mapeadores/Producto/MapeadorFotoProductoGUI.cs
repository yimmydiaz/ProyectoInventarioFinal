using Inventario.GUI.Models.Producto;
using LogicaNegocio.DTO.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Producto
{
    public class MapeadorFotoProductoGUI : MapeadorBaseGUI<FotoProductoDTO, ModeloFotoProducto>
    {
        public override ModeloFotoProducto MapearTipo1Tipo2(FotoProductoDTO entrada)
        {
            return new ModeloFotoProducto()
            {
                Id = entrada.Id,
                IdProducto = entrada.IdProducto,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<ModeloFotoProducto> MapearTipo1Tipo2(IEnumerable<FotoProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override FotoProductoDTO MapearTipo2Tipo1(ModeloFotoProducto entrada)
        {
            return new FotoProductoDTO()
            {
                Id = entrada.Id,
                IdProducto = entrada.IdProducto,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<FotoProductoDTO> MapearTipo2Tipo1(IEnumerable<ModeloFotoProducto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}