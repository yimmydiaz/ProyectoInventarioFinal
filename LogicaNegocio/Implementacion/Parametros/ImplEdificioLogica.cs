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
    public class ImplEdificioLogica
    {
        private ImplEdificioDatos accesoDatos;

        public ImplEdificioLogica()
        {
            this.accesoDatos = new ImplEdificioDatos();
        }

        public IEnumerable<EdificioDTO> ListarRegistros(String filtro,
                                                     int numPagina,
                                                     int registroPorPagina,
                                                     out int totalRegistro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina
                , registroPorPagina, out totalRegistro);
            MapeadorEdificioLogica mapeador = new MapeadorEdificioLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }

        public EdificioDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorEdificioLogica mapeador = new MapeadorEdificioLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(EdificioDTO registro)
        {
            MapeadorEdificioLogica mapeador = new MapeadorEdificioLogica();
            EdificioDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(EdificioDTO registro)
        {
            MapeadorEdificioLogica mapeador = new MapeadorEdificioLogica();
            EdificioDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            return this.accesoDatos.EliminarRegistro(id);
        }

        public IEnumerable<EdificioDTO> ListarEdificios()
        {
            var listado = this.accesoDatos.ListarEdificios();
            MapeadorEdificioLogica mapeador = new MapeadorEdificioLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }
    }
}
