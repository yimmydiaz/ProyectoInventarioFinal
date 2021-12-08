using AccesoDeDatos.DbModel.Asociar;
using AccesoDeDatos.Implementacion.Asociar;
using LogicaNegocio.DTO.Asociar;
using LogicaNegocio.Mapeadores.Asociar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Asociar
{
    public class ImplAsociarLogica
    {
        private ImplAsociarDatos accesoDatos;

        public ImplAsociarLogica()
        {
            this.accesoDatos = new ImplAsociarDatos();
        }

        public IEnumerable<AsociarDTO> ListarRegistros(String filtro,
                                                     int numPagina,
                                                     int registroPorPagina,
                                                     out int totalRegistro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina
                , registroPorPagina, out totalRegistro);
            MapeadorAsociarLogica mapeador = new MapeadorAsociarLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }

        public AsociarDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorAsociarLogica mapeador = new MapeadorAsociarLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(AsociarDTO registro)
        {
            MapeadorAsociarLogica mapeador = new MapeadorAsociarLogica();
            AsociarDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(AsociarDTO registro)
        {
            MapeadorAsociarLogica mapeador = new MapeadorAsociarLogica();
            AsociarDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            return this.accesoDatos.EliminarRegistro(id);
        }

        public IEnumerable<AsociarDTO> ListarAsociars()
        {
            var listado = this.accesoDatos.ListarAsociars();
            MapeadorAsociarLogica mapeador = new MapeadorAsociarLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }
    }
}
