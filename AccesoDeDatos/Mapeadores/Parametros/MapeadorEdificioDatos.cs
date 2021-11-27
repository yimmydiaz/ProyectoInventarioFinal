using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorEdificioDatos : MapeadorbaseDatos<tb_edificio, EdificioDbModel>
    {
        public override EdificioDbModel MapearTipo1Tipo2(tb_edificio entrada)
        {
            return new EdificioDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                Id_Sede = entrada.id_sede,
                NombreSede = entrada.tb_sede.nombre

            };
        }

        public override IEnumerable<EdificioDbModel> MapearTipo1Tipo2(IEnumerable<tb_edificio> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_edificio MapearTipo2Tipo1(EdificioDbModel entrada)
        {
            return new tb_edificio()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                id_sede = entrada.Id_Sede 
            };
        }

        public override IEnumerable<tb_edificio> MapearTipo2Tipo1(IEnumerable<EdificioDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
