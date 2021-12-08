using AccesoDeDatos.DbModel.Asociar;
using LogicaNegocio.DTO.Asociar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Asociar
{
    public class MapeadorAsociarLogica : MapeadorBaseLogica<AsociarDbModel, AsociarDTO>
    {
        public override AsociarDTO MapearTipo1Tipo2(AsociarDbModel entrada)
        {
            return new AsociarDTO()
            {
                Id = entrada.Id,
                Ubicacion = entrada.Ubicacion,
                Id_Producto = entrada.Id_Producto,
                Id_Persona = entrada.Id_Persona,
                NombreProducto = entrada.NombreProducto,
                NombrePersona = entrada.NombrePersona
            };
        }

        public override IEnumerable<AsociarDTO> MapearTipo1Tipo2(IEnumerable<AsociarDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override AsociarDbModel MapearTipo2Tipo1(AsociarDTO entrada)
        {
            return new AsociarDbModel()
            {
                Id = entrada.Id,
                Ubicacion = entrada.Ubicacion,
                Id_Producto = entrada.Id_Producto,
                Id_Persona = entrada.Id_Persona
            };
        }

        public override IEnumerable<AsociarDbModel> MapearTipo2Tipo1(IEnumerable<AsociarDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
