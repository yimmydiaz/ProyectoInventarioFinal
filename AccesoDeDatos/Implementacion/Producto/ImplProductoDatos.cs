using AccesoDeDatos.DbModel.Productos;
using AccesoDeDatos.Mapeadores.Producto;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Producto
{
    public class ImplProductoDatos
    {

        /// <summary>
        /// Metodo para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        /// {


        ///


        public IEnumerable<ProductoDbModel> ListarRegistrosReporte()
        {
            var lista = new List<ProductoDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                //lista = bd.tb_marca.Where(x => x.nombre.ToUpper()
                //       .Contains(filtro.ToUpper())).Skip(reDescartados).Take(numRegistroPagina).ToList();
                var listaDatos = (from m in bd.tb_producto
                                  select m).ToList();
                lista = new MapeadorProductoDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }



        public IEnumerable<ProductoDbModel> ListarRegistros(string filtro,
                                                    int paginaActual,
                                                    int numRegistroPagina, out int totalRegistro)
        {
            var lista = new List<ProductoDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                int reDescartados = (paginaActual - 1) * numRegistroPagina;
                //lista = bd.tb_marca.Where(x => x.nombre.ToUpper()
                //       .Contains(filtro.ToUpper())).Skip(reDescartados).Take(numRegistroPagina).ToList();
                var listaDatos = (from m in bd.tb_producto
                                  where m.nombre.Contains(filtro)
                                  select m).ToList();
                totalRegistro = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(reDescartados).Take(numRegistroPagina).ToList();
                lista = new MapeadorProductoDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Metodo para guardar una marca 
        /// </summary>
        /// <param name="registro">El registro  a almacenar </param>
        /// <returns>True cuando se almaneca y false cuando ya existe un registro igual o una excepcion </returns>
        public bool GuardarRegistro(ProductoDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // Verificacion de la existencia de un registro con el mismo nombre
                    if (bd.tb_producto.Where(x => x.serial_producto.ToLower().Equals(registro.SerialProducto.ToLower())).Count() > 0)
                    {
                        return false;
                    }

                    MapeadorProductoDatos mapeador = new MapeadorProductoDatos();
                    var regis = mapeador.MapearTipo2Tipo1(registro);
                    //regis.fecha = DateTime.Now;
                    bd.tb_producto.Add(regis);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo de busqueda de un registro
        /// </summary>
        /// <param name="id">id del registro buscado</param>
        /// <returns>El objeto con el id buscado o null cuando no exista</returns>
        public ProductoDbModel BuscarRegistro(int id)
        {

            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                tb_producto registro = bd.tb_producto.Find(id);
                return new MapeadorProductoDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Metodo para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>True cuando se edita y false cuando no existe el registro igual o una excepcion</returns>

        public bool EditarRegistro(ProductoDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // Verificacion de la existencia de un registro con el mismo nombre
                    if (bd.tb_producto.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }

                    MapeadorProductoDatos mapeador = new MapeadorProductoDatos();
                    var regis = mapeador.MapearTipo2Tipo1(registro);
                    bd.Entry(regis).State = EntityState.Modified;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }



        }



        /// <summary>
        /// Metodo de eliminar un registro
        /// </summary>
        /// <param name="id">id del registro a eliminar</param>
        /// <returns>True cuando se elimina, False cuando no existe o una excepcion</returns>
        public bool EliminarRegistro(int id)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    tb_producto registro = bd.tb_producto.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }

                    bd.tb_producto.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public IEnumerable<ProductoDbModel> ListarProductos()
        {
            var lista = new List<ProductoDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                //lista = bd.tb_marca.Where(x => x.nombre.ToUpper()
                //       .Contains(filtro.ToUpper())).Skip(reDescartados).Take(numRegistroPagina).ToList();
                var listaDatos = (from m in bd.tb_producto
                                  select m).ToList();

                lista = new MapeadorProductoDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        public bool EliminarRegistroFoto(int id)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    tb_fotos registro = bd.tb_fotos.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    //registro.estado = false;
                    //bd.tb_producto.Remove(registro);
                    bd.tb_fotos.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }
        public bool GuardarFotoProducto(FotoProductoDbModel dbModel)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    if (bd.tb_producto.Where(x => x.id == dbModel.IdProducto).Count() > 0)
                    {
                        MapeadorFotoProductoDatos mapeador = new MapeadorFotoProductoDatos();
                        tb_fotos foto = mapeador.MapearTipo2Tipo1(dbModel);
                        bd.tb_fotos.Add(foto);
                        bd.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IEnumerable<FotoProductoDbModel> ListarFotosProductoPorId(int id)
        {
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                //var lista = bd.tb_fotos.Where(x => x.id_vehiculo == id).ToList(); // forma landa
                var lista = (from f in bd.tb_fotos
                             where f.id_producto == id //&& f.estado
                             select f).ToList(); // de forma linkiu
                MapeadorFotoProductoDatos mapeador = new MapeadorFotoProductoDatos();
                IEnumerable<FotoProductoDbModel> listaDbModel = mapeador.MapearTipo1Tipo2(lista);
                return listaDbModel;

            }
        }
    }

}
