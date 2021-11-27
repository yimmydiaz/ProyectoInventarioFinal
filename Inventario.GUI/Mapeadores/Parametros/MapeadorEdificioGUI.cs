using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorEdificioGUI : MapeadorBaseGUI<EdificioDTO, ModeloEdificio>
    {
        public override ModeloEdificio MapearTipo1Tipo2(EdificioDTO entrada)
        {
            return new ModeloEdificio()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_Sede  = entrada.Id_Sede,
                NombreSede = entrada.NombreSede
                
                
            };
        }

        public override IEnumerable<ModeloEdificio> MapearTipo1Tipo2(IEnumerable<EdificioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override EdificioDTO MapearTipo2Tipo1(ModeloEdificio entrada)
        {
            return new EdificioDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_Sede = entrada.Id_Sede
            };
        }

        public override IEnumerable<EdificioDTO> MapearTipo2Tipo1(IEnumerable<ModeloEdificio> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}