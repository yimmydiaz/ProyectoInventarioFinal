using Inventario.GUI.Models.Asociar;
using LogicaNegocio.DTO.Asociar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Asociar
{
    public class MapeadorAsociarGUI : MapeadorBaseGUI<AsociarDTO, ModeloAsociar>
    {
        public override ModeloAsociar MapearTipo1Tipo2(AsociarDTO entrada)
        {
            return new ModeloAsociar()
            {
                Id = entrada.Id,
                Ubicacion = entrada.Ubicacion,
                Id_Producto = entrada.Id_Producto,
                Id_Persona = entrada.Id_Persona,
                NombreProducto = entrada.NombreProducto,
                NombrePersona = entrada.NombrePersona


            };
        }

        public override IEnumerable<ModeloAsociar> MapearTipo1Tipo2(IEnumerable<AsociarDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override AsociarDTO MapearTipo2Tipo1(ModeloAsociar entrada)
        {
            return new AsociarDTO()
            {
                Id = entrada.Id,
                Ubicacion = entrada.Ubicacion,
                Id_Producto = entrada.Id_Producto,
                Id_Persona = entrada.Id_Persona
            };
        }

        public override IEnumerable<AsociarDTO> MapearTipo2Tipo1(IEnumerable<ModeloAsociar> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}