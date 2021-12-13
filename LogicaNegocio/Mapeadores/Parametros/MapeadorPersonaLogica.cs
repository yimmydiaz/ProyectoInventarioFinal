using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorPersonaLogica : MapeadorBaseLogica<PersonaDbModel, PersonaDTO>
    {
        public override PersonaDTO MapearTipo1Tipo2(PersonaDbModel entrada)
        {
            return new PersonaDTO()
            {
                Id = entrada.Id,
                Cedula = entrada.Cedula,
                Nombre = entrada.Nombre,
                Apellido = entrada.Apellido,
                Edad = entrada.Edad,
                Correo = entrada.Correo,
                Celular = entrada.Celular
            };
        }

        public override IEnumerable<PersonaDTO> MapearTipo1Tipo2(IEnumerable<PersonaDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PersonaDbModel MapearTipo2Tipo1(PersonaDTO entrada)
        {
            return new PersonaDbModel()
            {
                Id = entrada.Id,
                Cedula = entrada.Cedula,
                Nombre = entrada.Nombre,
                Apellido = entrada.Apellido,
                Edad = entrada.Edad,
                Correo = entrada.Correo,
                Celular = entrada.Celular
            };
        }

        public override IEnumerable<PersonaDbModel> MapearTipo2Tipo1(IEnumerable<PersonaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
