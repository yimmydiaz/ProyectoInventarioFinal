using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Implementacion.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Mapeadores.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Parametros
{
    public class ImplPersonaLogica
    {
        private ImplPersonaDatos accesoDatos;

        public ImplPersonaLogica()
        {
            this.accesoDatos = new ImplPersonaDatos();
        }

        public IEnumerable<PersonaDTO> ListarRegistros(String filtro,
                                                     int numPagina,
                                                     int registroPorPagina,
                                                     out int totalRegistro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina
                , registroPorPagina, out totalRegistro);
            MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }

        public PersonaDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(PersonaDTO registro)
        {
            MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
            PersonaDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(PersonaDTO registro)
        {
            MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
            PersonaDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            return this.accesoDatos.EliminarRegistro(id);
        }

        public IEnumerable<PersonaDTO> ListarPersonas()
        {
            var listado = this.accesoDatos.ListarPersonas();
            MapeadorPersonaLogica mapeador = new MapeadorPersonaLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }
    }
}
