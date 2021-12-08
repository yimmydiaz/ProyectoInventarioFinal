using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorTipoProductoGUI : MapeadorBaseGUI<TipoProductoDTO, ModeloTipoProducto>
    {
        public override ModeloTipoProducto MapearTipo1Tipo2(TipoProductoDTO entrada)
        {
            return new ModeloTipoProducto()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<ModeloTipoProducto> MapearTipo1Tipo2(IEnumerable<TipoProductoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override TipoProductoDTO MapearTipo2Tipo1(ModeloTipoProducto entrada)
        {
            return new TipoProductoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<TipoProductoDTO> MapearTipo2Tipo1(IEnumerable<ModeloTipoProducto> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}