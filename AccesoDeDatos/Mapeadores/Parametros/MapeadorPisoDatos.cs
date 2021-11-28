using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorPisoDatos : MapeadorbaseDatos<tb_piso, PisoDbModel>
    {
        public override PisoDbModel MapearTipo1Tipo2(tb_piso entrada)
        {
            return new PisoDbModel()
            {
                Id = entrada.id,
                Nombre = entrada.nombre,
                NumeroPiso = entrada.numeroPiso,
                Id_Edificio = entrada.id_edificio,
                NombreEdificio = entrada.tb_edificio.nombre

            };
        }

        public override IEnumerable<PisoDbModel> MapearTipo1Tipo2(IEnumerable<tb_piso> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_piso MapearTipo2Tipo1(PisoDbModel entrada)
        {
            return new tb_piso()
            {
                id = entrada.Id,
                nombre = entrada.Nombre,
                numeroPiso = entrada.NumeroPiso,
                id_edificio= entrada.Id_Edificio
            };
        }

        public override IEnumerable<tb_piso> MapearTipo2Tipo1(IEnumerable<PisoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
