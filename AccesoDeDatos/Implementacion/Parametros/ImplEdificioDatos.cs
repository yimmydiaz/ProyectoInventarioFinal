using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Mapeadores.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Parametros
{
    public class ImplEdificioDatos
    {
        /// <summary>
        /// Metodo para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<EdificioDbModel> ListarRegistros(string filtro,
                                                    int paginaActual,
                                                    int numRegistroPagina, out int totalRegistro)
        {
            var lista = new List<EdificioDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                int reDescartados = (paginaActual - 1) * numRegistroPagina;
                //lista = bd.tb_marca.Where(x => x.nombre.ToUpper()
                //       .Contains(filtro.ToUpper())).Skip(reDescartados).Take(numRegistroPagina).ToList();
                var listaDatos = (from m in bd.tb_edificio
                                  where m.nombre.Contains(filtro)
                                  select m).ToList();
                totalRegistro = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(reDescartados).Take(numRegistroPagina).ToList();
                lista = new MapeadorEdificioDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Metodo para guardar una marca 
        /// </summary>
        /// <param name="registro">El registro  a almacenar </param>
        /// <returns>True cuando se almaneca y false cuando ya existe un registro igual o una excepcion </returns>
        public bool GuardarRegistro(EdificioDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // Verificacion de la existencia de un registro con el mismo nombre
                    if (bd.tb_edificio.Where(x => x.nombre.ToLower().Equals(registro.Nombre.ToLower())).Count() > 0)
                    {
                        return false;
                    }

                    MapeadorEdificioDatos mapeador = new MapeadorEdificioDatos();
                    var regis = mapeador.MapearTipo2Tipo1(registro);
                    bd.tb_edificio.Add(regis);
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
        public EdificioDbModel BuscarRegistro(int id)
        {

            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                tb_edificio registro = bd.tb_edificio.Find(id);
                return new MapeadorEdificioDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Metodo para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>True cuando se edita y false cuando no existe el registro igual o una excepcion</returns>

        public bool EditarRegistro(EdificioDbModel registro)
        {
            try
            {
                using (InventarioBDEntities bd = new InventarioBDEntities())
                {
                    // Verificacion de la existencia de un registro con el mismo nombre
                    if (bd.tb_edificio.Where(x => x.id == registro.Id).Count() == 0)
                    {
                        return false;
                    }

                    MapeadorEdificioDatos mapeador = new MapeadorEdificioDatos();
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
                    tb_edificio registro = bd.tb_edificio.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }

                    bd.tb_edificio.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public IEnumerable<EdificioDbModel> ListarEdificios()
        {
            var lista = new List<EdificioDbModel>();
            using (InventarioBDEntities bd = new InventarioBDEntities())
            {
                //lista = bd.tb_marca.Where(x => x.nombre.ToUpper()
                //       .Contains(filtro.ToUpper())).Skip(reDescartados).Take(numRegistroPagina).ToList();
                var listaDatos = (from m in bd.tb_edificio
                                  select m).ToList();

                lista = new MapeadorEdificioDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }
    }
}
