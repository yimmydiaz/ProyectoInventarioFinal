using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Implementacion.Parametros;
using LogicaNegocio.DTO;
using LogicaNegocio.Mapeadores.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Parametros
{
    public class ImplPisoLogica
    {
        private ImplPisoDatos accesoDatos;

        public ImplPisoLogica()
        {
            this.accesoDatos = new ImplPisoDatos();
        }

        public IEnumerable<PisoDTO> ListarRegistros(String filtro,
                                                     int numPagina,
                                                     int registroPorPagina,
                                                     out int totalRegistro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina
                , registroPorPagina, out totalRegistro);
            MapeadorPisoLogica mapeador = new MapeadorPisoLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }

        public PisoDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorPisoLogica mapeador = new MapeadorPisoLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(PisoDTO registro)
        {
            MapeadorPisoLogica mapeador = new MapeadorPisoLogica();
            PisoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(PisoDTO registro)
        {
            MapeadorPisoLogica mapeador = new MapeadorPisoLogica();
            PisoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            return this.accesoDatos.EliminarRegistro(id);
        }

        public IEnumerable<PisoDTO> ListarPisos()
        {
            var listado = this.accesoDatos.ListarPisos();
            MapeadorPisoLogica mapeador = new MapeadorPisoLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }
    }
}
