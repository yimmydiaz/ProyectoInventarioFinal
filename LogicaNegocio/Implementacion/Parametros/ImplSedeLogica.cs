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
    public class ImplSedeLogica
    {
        private ImplSedeDatos accesoDatos;

        public ImplSedeLogica()
        {
            this.accesoDatos = new ImplSedeDatos();
        }

        public IEnumerable<SedeDTO> ListarRegistros(String filtro,
                                                     int numPagina,
                                                     int registroPorPagina,
                                                     out int totalRegistro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina
                , registroPorPagina, out totalRegistro);
            MapeadorSedeLogica mapeador = new MapeadorSedeLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }

        public SedeDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorSedeLogica mapeador = new MapeadorSedeLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(SedeDTO registro)
        {
            MapeadorSedeLogica mapeador = new MapeadorSedeLogica();
            SedeDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(SedeDTO registro)
        {
            MapeadorSedeLogica mapeador = new MapeadorSedeLogica();
            SedeDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            return this.accesoDatos.EliminarRegistro(id);
        }

        public IEnumerable<SedeDTO> ListarSedes()
        {
            var listado = this.accesoDatos.ListarSedes();
            MapeadorSedeLogica mapeador = new MapeadorSedeLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }
    }
}
