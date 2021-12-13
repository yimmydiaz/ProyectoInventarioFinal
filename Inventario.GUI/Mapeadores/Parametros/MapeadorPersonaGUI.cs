using Inventario.GUI.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.GUI.Mapeadores.Parametros
{
    public class MapeadorPersonaGUI : MapeadorBaseGUI<PersonaDTO, ModeloPersona>
    {
        public override ModeloPersona MapearTipo1Tipo2(PersonaDTO entrada)
        {
            return new ModeloPersona()
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

        public override IEnumerable<ModeloPersona> MapearTipo1Tipo2(IEnumerable<PersonaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override PersonaDTO MapearTipo2Tipo1(ModeloPersona entrada)
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

        public override IEnumerable<PersonaDTO> MapearTipo2Tipo1(IEnumerable<ModeloPersona> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}