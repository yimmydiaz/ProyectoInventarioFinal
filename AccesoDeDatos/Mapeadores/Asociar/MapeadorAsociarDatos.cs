using AccesoDeDatos.DbModel.Asociar;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Asociar
{
    public class MapeadorAsociarDatos : MapeadorbaseDatos<tb_asociar, AsociarDbModel>
    {
        public override AsociarDbModel MapearTipo1Tipo2(tb_asociar entrada)
        {
            return new AsociarDbModel()
            {
                Id = entrada.id,
                Ubicacion = entrada.ubicacion,
                Id_Producto = entrada.id_producto,
                Id_Persona = entrada.id_persona,
                NombreProducto = entrada.tb_producto.nombre,
                NombrePersona = entrada.tb_persona.nombre

            };
        }

        public override IEnumerable<AsociarDbModel> MapearTipo1Tipo2(IEnumerable<tb_asociar> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_asociar MapearTipo2Tipo1(AsociarDbModel entrada)
        {
            return new tb_asociar()
            {
                id = entrada.Id,
                ubicacion = entrada.Ubicacion,
                id_producto = entrada.Id_Producto,
                id_persona = entrada.Id_Persona
            };
        }

        public override IEnumerable<tb_asociar> MapearTipo2Tipo1(IEnumerable<AsociarDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
