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
    public class ImplMarcaLogica
    {
        private ImplMarcaDatos accesoDatos;

        public ImplMarcaLogica()
        {
            this.accesoDatos = new ImplMarcaDatos();
        }

        public IEnumerable<MarcaDTO> ListarRegistros(String filtro,
                                                     int numPagina,
                                                     int registroPorPagina,
                                                     out int totalRegistro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina
                , registroPorPagina, out totalRegistro);
            MapeadorMarcaLogica mapeador = new MapeadorMarcaLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }

        public MarcaDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorMarcaLogica mapeador = new MapeadorMarcaLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(MarcaDTO registro)
        {
            MapeadorMarcaLogica mapeador = new MapeadorMarcaLogica();
            MarcaDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(MarcaDTO registro)
        {
            MapeadorMarcaLogica mapeador = new MapeadorMarcaLogica();
            MarcaDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            return this.accesoDatos.EliminarRegistro(id);
        }

        public IEnumerable<MarcaDTO> ListarMarcas()
        {
            var listado = this.accesoDatos.ListarMarcas();
            MapeadorMarcaLogica mapeador = new MapeadorMarcaLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }
    }
}
