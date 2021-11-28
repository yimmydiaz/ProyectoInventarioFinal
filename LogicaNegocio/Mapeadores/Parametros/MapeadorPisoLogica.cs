using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
    class MapeadorPisoLogica : MapeadorBaseLogica<PisoDbModel, PisoDTO>
    {
        public override PisoDTO MapearTipo1Tipo2(PisoDbModel entrada)
        {
            return new PisoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                NumeroPiso = entrada.NumeroPiso,
                Id_Edificio = entrada.Id_Edificio,
                NombreEdificio = entrada.NombreEdificio
            };
        }

        public override IEnumerable<PisoDTO> MapearTipo1Tipo2(IEnumerable<PisoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PisoDbModel MapearTipo2Tipo1(PisoDTO entrada)
        {
            return new PisoDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                NumeroPiso = entrada.NumeroPiso,
                Id_Edificio = entrada.Id_Edificio
            };
        }

        public override IEnumerable<PisoDbModel> MapearTipo2Tipo1(IEnumerable<PisoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
