using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorEspacioGUI : MapeadorBaseGUI<EspacioDTO, ModeloEspacio>
    {
        public override ModeloEspacio MapearTipo1Tipo2(EspacioDTO entrada)
        {
            return new ModeloEspacio()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_Piso = entrada.Id_Piso,
                NombrePiso = entrada.NombrePiso


            };
        }

        public override IEnumerable<ModeloEspacio> MapearTipo1Tipo2(IEnumerable<EspacioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override EspacioDTO MapearTipo2Tipo1(ModeloEspacio entrada)
        {
            return new EspacioDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_Piso = entrada.Id_Piso
            };
        }

        public override IEnumerable<EspacioDTO> MapearTipo2Tipo1(IEnumerable<ModeloEspacio> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}