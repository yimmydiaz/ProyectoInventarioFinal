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
    public class ImplTipoProductoLogica
    {
        private ImplTipoProductoDatos accesoDatos;

        public ImplTipoProductoLogica()
        {
            this.accesoDatos = new ImplTipoProductoDatos();
        }

        public IEnumerable<TipoProductoDTO> ListarRegistros(String filtro,
                                                     int numPagina,
                                                     int registroPorPagina,
                                                     out int totalRegistro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina
                , registroPorPagina, out totalRegistro);
            MapeadorTipoProductoLogica mapeador = new MapeadorTipoProductoLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }

        public TipoProductoDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorTipoProductoLogica mapeador = new MapeadorTipoProductoLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(TipoProductoDTO registro)
        {
            MapeadorTipoProductoLogica mapeador = new MapeadorTipoProductoLogica();
            TipoProductoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(TipoProductoDTO registro)
        {
            MapeadorTipoProductoLogica mapeador = new MapeadorTipoProductoLogica();
            TipoProductoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            return this.accesoDatos.EliminarRegistro(id);
        }

        public IEnumerable<TipoProductoDTO> ListarTipoProductos()
        {
            var listado = this.accesoDatos.ListarTipoProductos();
            MapeadorTipoProductoLogica mapeador = new MapeadorTipoProductoLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }
    }
}
