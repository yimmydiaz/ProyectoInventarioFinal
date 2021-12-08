using AccesoDeDatos.DbModel.Productos;
using AccesoDeDatos.Implementacion.Producto;
using LogicaNegocio.DTO.Producto;
using LogicaNegocio.Mapeadores.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Producto
{
    public class ImplProductoLogica
    {
        private ImplProductoDatos accesoDatos;

        public ImplProductoLogica()
        {
            this.accesoDatos = new ImplProductoDatos();
        }

        public IEnumerable<ProductoDTO> ListarRegistros(String filtro,
                                                     int numPagina,
                                                     int registroPorPagina,
                                                     out int totalRegistro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina
                , registroPorPagina, out totalRegistro);
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }

        public ProductoDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(ProductoDTO registro)
        {
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            ProductoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(ProductoDTO registro)
        {
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            ProductoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            return this.accesoDatos.EliminarRegistro(id);
        }

        public IEnumerable<ProductoDTO> ListarProductos()
        {
            var listado = this.accesoDatos.ListarProductos();
            MapeadorProductoLogica mapeador = new MapeadorProductoLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }

        public Boolean EliminarRegistroFoto(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistroFoto(id);
            return res;
        }


        public Boolean GuardarNombreFoto(FotoProductoDTO dto)
        {
            MapeadorFotoProductoLogica mapeador = new MapeadorFotoProductoLogica();
            FotoProductoDbModel dbModel = mapeador.MapearTipo2Tipo1(dto);
            bool res = this.accesoDatos.GuardarFotoProducto(dbModel);
            return res;

        }

        public IEnumerable<FotoProductoDTO> ListaFotosProductoPorId(int idProducto)
        {
            IEnumerable<FotoProductoDbModel> listaDBModel =
                                             this.accesoDatos.ListarFotosProductoPorId(idProducto);
            MapeadorFotoProductoLogica mapeador = new MapeadorFotoProductoLogica();
            IEnumerable<FotoProductoDTO> lista = mapeador.MapearTipo1Tipo2(listaDBModel);
            return lista;

        }
    }
}
