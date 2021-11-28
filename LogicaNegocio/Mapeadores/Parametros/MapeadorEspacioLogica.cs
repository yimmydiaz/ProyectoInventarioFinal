using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorEspacioLogica : MapeadorBaseLogica<EspacioDbModel, EspacioDTO>
    {
        public override EspacioDTO MapearTipo1Tipo2(EspacioDbModel entrada)
        {
            return new EspacioDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_Piso = entrada.Id_Piso,
                NombrePiso = entrada.NombrePiso
            };
        }

        public override IEnumerable<EspacioDTO> MapearTipo1Tipo2(IEnumerable<EspacioDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override EspacioDbModel MapearTipo2Tipo1(EspacioDTO entrada)
        {
            return new EspacioDbModel()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                Id_Piso = entrada.Id_Piso
            };
        }

        public override IEnumerable<EspacioDbModel> MapearTipo2Tipo1(IEnumerable<EspacioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
