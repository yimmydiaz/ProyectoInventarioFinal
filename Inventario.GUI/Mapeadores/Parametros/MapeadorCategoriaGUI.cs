using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorCategoriaGUI : MapeadorBaseGUI<CategoriaDTO, ModeloCategoria>
    {
        public override ModeloCategoria MapearTipo1Tipo2(CategoriaDTO entrada)
        {
            return new ModeloCategoria()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<ModeloCategoria> MapearTipo1Tipo2(IEnumerable<CategoriaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override CategoriaDTO MapearTipo2Tipo1(ModeloCategoria entrada)
        {
            return new CategoriaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<CategoriaDTO> MapearTipo2Tipo1(IEnumerable<ModeloCategoria> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}