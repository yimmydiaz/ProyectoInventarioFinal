using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorPersonaDatos : MapeadorbaseDatos<tb_persona, PersonaDbModel>
    {
        public override PersonaDbModel MapearTipo1Tipo2(tb_persona entrada)
        {
            return new PersonaDbModel()
            {
                Id = entrada.id,
                Cedula = entrada.cedula,
                Nombre = entrada.nombre,
                Apellido = entrada.apellido,
                Edad = entrada.edad,
                Correo = entrada.correo,
                Celular = entrada.celular

            };
        }

        public override IEnumerable<PersonaDbModel> MapearTipo1Tipo2(IEnumerable<tb_persona> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_persona MapearTipo2Tipo1(PersonaDbModel entrada)
        {
            return new tb_persona()
            {
                id = entrada.Id,
                cedula = entrada.Cedula,
                nombre = entrada.Nombre,
                apellido = entrada.Apellido,
                edad = entrada.Edad,
                correo = entrada.Correo,
                celular = entrada.Celular
            };
        }

        public override IEnumerable<tb_persona> MapearTipo2Tipo1(IEnumerable<PersonaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
