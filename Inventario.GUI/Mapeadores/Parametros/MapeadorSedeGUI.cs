using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorSedeGUI : MapeadorBaseGUI<SedeDTO, ModeloSede>
    {
        public override ModeloSede MapearTipo1Tipo2(SedeDTO entrada)
        {
            return new ModeloSede()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Direccion = entrada.Direccion                
            };
        }

        public override IEnumerable<ModeloSede> MapearTipo1Tipo2(IEnumerable<SedeDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override SedeDTO MapearTipo2Tipo1(ModeloSede entrada)
        {
            return new SedeDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Direccion = entrada.Direccion
            };
        }

        public override IEnumerable<SedeDTO> MapearTipo2Tipo1(IEnumerable<ModeloSede> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}