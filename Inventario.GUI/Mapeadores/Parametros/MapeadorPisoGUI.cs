using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorPisoGUI : MapeadorBaseGUI<PisoDTO, ModeloPiso>
    {
        public override ModeloPiso MapearTipo1Tipo2(PisoDTO entrada)
        {
            return new ModeloPiso()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                NumeroPiso = entrada.NumeroPiso,
                Id_Edificio = entrada.Id_Edificio,
                NombreEdificio = entrada.NombreEdificio


            };
        }

        public override IEnumerable<ModeloPiso> MapearTipo1Tipo2(IEnumerable<PisoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PisoDTO MapearTipo2Tipo1(ModeloPiso entrada)
        {
            return new PisoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                NumeroPiso = entrada.NumeroPiso,
                Id_Edificio = entrada.Id_Edificio
            };
        }

        public override IEnumerable<PisoDTO> MapearTipo2Tipo1(IEnumerable<ModeloPiso> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}