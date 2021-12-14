using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario.GUI.ModeloBD;
using LogicaNegocio.Implementacion.Producto;
using Inventario.GUI.Helpers;
using LogicaNegocio.DTO.Producto;
using Inventario.GUI.Mapeadores.Producto;
using Inventario.GUI.Models.Producto;
using PagedList;
using System.IO;
using LogicaNegocio.Implementacion.Parametros;
using LogicaNegocio.DTO.Parametros;
using Inventario.GUI.Mapeadores.Parametros;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Inventario.GUI.Controllers.Producto
{
    public class ProductoController : Controller
    {
        private ImplProductoLogica logica = new ImplProductoLogica();

        /// <summary>
        /// Listado para crear un producto
        /// </summary>
        private ImplCategoriaLogica logicaCategoria = new ImplCategoriaLogica();
        private ImplEspacioLogica logicaEspacio = new ImplEspacioLogica();
        private ImplMarcaLogica logicaMarca = new ImplMarcaLogica();
        private ImplTipoProductoLogica logicaTipoProducto = new ImplTipoProductoLogica();



        // GET: Producto
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<ProductoDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            IEnumerable<ModeloProducto> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloProducto>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }


        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO ProductoDTO = logica.BuscarRegistro(id.Value);
            if (ProductoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProducto modelo = mapper.MapearTipo1Tipo2(ProductoDTO);
            return View(modelo);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            IEnumerable<CategoriaDTO> listaCategoria = logicaCategoria.ListarCategorias();
            MapeadorCategoriaGUI mapperCategoria = new MapeadorCategoriaGUI();

            IEnumerable<EspacioDTO> listaEspacio = logicaEspacio.ListarEspacios() ;
            MapeadorEspacioGUI mapperEspacio = new MapeadorEspacioGUI();

            IEnumerable<MarcaDTO> listaMarca = logicaMarca.ListarMarcas();
            MapeadorMarcaGUI mapperMarca = new MapeadorMarcaGUI();

            IEnumerable<TipoProductoDTO> listaTipoProducto = logicaTipoProducto.ListarTipoProductos();
            MapeadorTipoProductoGUI mapperTipoProducto = new MapeadorTipoProductoGUI();

            ViewBag.id_categoria = new SelectList(mapperCategoria.MapearTipo1Tipo2(listaCategoria), "id", "nombre");
            ViewBag.id_espacio = new SelectList(mapperEspacio.MapearTipo1Tipo2(listaEspacio), "id", "nombre");
            ViewBag.id_marca = new SelectList(mapperMarca.MapearTipo1Tipo2(listaMarca), "id", "nombre");
            ViewBag.id_tipoProducto = new SelectList(mapperTipoProducto.MapearTipo1Tipo2(listaTipoProducto), "id", "nombre");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,fecha,serial_producto,id_marca,id_categoria,id_tipoProducto,id_espacio")] ModeloProducto modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ProductoDTO productoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(productoDTO);
                return RedirectToAction("Index");
            }

            // Mapeadores
            IEnumerable<CategoriaDTO> listaCategoria = logicaCategoria.ListarCategorias();
            MapeadorCategoriaGUI mapperCategoria = new MapeadorCategoriaGUI();

            IEnumerable<EspacioDTO> listaEspacio = logicaEspacio.ListarEspacios();
            MapeadorEspacioGUI mapperEspacio = new MapeadorEspacioGUI();

            IEnumerable<MarcaDTO> listaMarca = logicaMarca.ListarMarcas();
            MapeadorMarcaGUI mapperMarca = new MapeadorMarcaGUI();

            IEnumerable<TipoProductoDTO> listaTipoProducto = logicaTipoProducto.ListarTipoProductos();
            MapeadorTipoProductoGUI mapperTipoProducto = new MapeadorTipoProductoGUI();


            ViewBag.id_categoria = new SelectList(mapperCategoria.MapearTipo1Tipo2(listaCategoria), "id", "nombre", modelo.NombreCategoria);
            ViewBag.id_espacio = new SelectList(mapperEspacio.MapearTipo1Tipo2(listaEspacio), "id", "nombre", modelo.NombreEspacio);
            ViewBag.id_marca = new SelectList(mapperMarca.MapearTipo1Tipo2(listaMarca), "id", "nombre", modelo.NombreMarca);
            ViewBag.id_tipoProducto = new SelectList(mapperTipoProducto.MapearTipo1Tipo2(listaTipoProducto), "id", "nombre", modelo.NombreTipoProducto);
            return View(modelo);
        }

        // GET: Producto/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO productoDTO = logica.BuscarRegistro(id.Value);
            if (productoDTO == null)
            {
                return HttpNotFound();
            }

            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProducto modelo = mapper.MapearTipo1Tipo2(productoDTO);
            // Mapeadores
            IEnumerable<CategoriaDTO> listaCategoria = logicaCategoria.ListarCategorias();
            MapeadorCategoriaGUI mapperCategoria = new MapeadorCategoriaGUI();

            IEnumerable<EspacioDTO> listaEspacio = logicaEspacio.ListarEspacios();
            MapeadorEspacioGUI mapperEspacio = new MapeadorEspacioGUI();

            IEnumerable<MarcaDTO> listaMarca = logicaMarca.ListarMarcas();
            MapeadorMarcaGUI mapperMarca = new MapeadorMarcaGUI();

            IEnumerable<TipoProductoDTO> listaTipoProducto = logicaTipoProducto.ListarTipoProductos();
            MapeadorTipoProductoGUI mapperTipoProducto = new MapeadorTipoProductoGUI();

            ViewBag.id_categoria = new SelectList(mapperCategoria.MapearTipo1Tipo2(listaCategoria), "id", "nombre", productoDTO.NombreCategoria);
            ViewBag.id_espacio = new SelectList(mapperEspacio.MapearTipo1Tipo2(listaEspacio), "id", "nombre", productoDTO.NombreEspacio);
            ViewBag.id_marca = new SelectList(mapperMarca.MapearTipo1Tipo2(listaMarca), "id", "nombre", productoDTO.NombreMarca);
            ViewBag.id_tipoProducto = new SelectList(mapperTipoProducto.MapearTipo1Tipo2(listaTipoProducto), "id", "nombre", productoDTO.NombreTipoProducto);
            return View(modelo);
           
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,fecha,serial_producto,id_marca,id_categoria,id_tipoProducto,id_espacio")] ModeloProducto modelo)
        {
            
            if (ModelState.IsValid)
            {
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ProductoDTO productoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(productoDTO);
                return RedirectToAction("Index");
            }


            // Mapeadores
            IEnumerable<CategoriaDTO> listaCategoria = logicaCategoria.ListarCategorias();
            MapeadorCategoriaGUI mapperCategoria = new MapeadorCategoriaGUI();

            IEnumerable<EspacioDTO> listaEspacio = logicaEspacio.ListarEspacios();
            MapeadorEspacioGUI mapperEspacio = new MapeadorEspacioGUI();

            IEnumerable<MarcaDTO> listaMarca = logicaMarca.ListarMarcas();
            MapeadorMarcaGUI mapperMarca = new MapeadorMarcaGUI();

            IEnumerable<TipoProductoDTO> listaTipoProducto = logicaTipoProducto.ListarTipoProductos();
            MapeadorTipoProductoGUI mapperTipoProducto = new MapeadorTipoProductoGUI();

            ViewBag.id_categoria = new SelectList(mapperCategoria.MapearTipo1Tipo2(listaCategoria), "id", "nombre", modelo.Id_Categoria);
            ViewBag.id_espacio = new SelectList(mapperEspacio.MapearTipo1Tipo2(listaEspacio), "id", "nombre", modelo.Id_Espacio);
            ViewBag.id_marca = new SelectList(mapperMarca.MapearTipo1Tipo2(listaMarca), "id", "nombre", modelo.Id_Marca);
            ViewBag.id_tipoProducto = new SelectList(mapperTipoProducto.MapearTipo1Tipo2(listaTipoProducto), "id", "nombre",modelo.Id_TipoProducto);
            return View(modelo);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoDTO edificioDTO = logica.BuscarRegistro(id.Value);
            if (edificioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();
            ModeloProducto modelo = mapper.MapearTipo1Tipo2(edificioDTO);
            return View(modelo);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool respuesta = logica.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ProductoDTO edificioDTO = logica.BuscarRegistro(id);
                if (edificioDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorProductoGUI mapper = new MapeadorProductoGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloProducto modelo = mapper.MapearTipo1Tipo2(edificioDTO);
                return View(modelo);
            }
        }

        [HttpGet]
        public ActionResult UploadFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloCargaImagenProducto modelo = CrearModeloCargarImagenProducto(id);
            return View(modelo);
        }

        private ModeloCargaImagenProducto CrearModeloCargarImagenProducto(int? id)
        {
            IEnumerable<FotoProductoDTO> listaDTO = logica.ListaFotosProductoPorId(id.Value);
            MapeadorFotoProductoGUI mapeador = new MapeadorFotoProductoGUI();
            IEnumerable<ModeloFotoProducto> listaFotos = mapeador.MapearTipo1Tipo2(listaDTO);
            if (listaFotos == null)
            {
                listaFotos = new List<ModeloFotoProducto>();
            }
            ModeloCargaImagenProducto modelo = new ModeloCargaImagenProducto()
            {
                Id = id.Value,
                ListaImagenesProducto = listaFotos
            };
            return modelo;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFile(ModeloCargaImagenProducto modelo)
        {
            try
            {
                if (modelo.Archivo.ContentLength > 0)
                {
                    try
                    {
                        DateTime ahora = DateTime.Now;
                        string fecha_nombre = String.Format("{0}_{1}_{2}_{3}_{4}_{5}_",
                                                ahora.Day, ahora.Month, ahora.Year, ahora.Hour,
                                                ahora.Minute, ahora.Millisecond);

                        string nombreArchivo = String.Concat(fecha_nombre, "_",
                                               Path.GetFileName(modelo.Archivo.FileName));

                        string rutaCarpeta = DatosGenerales.RutaArchivosProductos;
                        string rutaCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreArchivo);
                        modelo.Archivo.SaveAs(rutaCompletaArchivo);
                        FotoProductoDTO dto = new FotoProductoDTO()
                        {
                            IdProducto = modelo.Id,
                            NombreFoto = nombreArchivo

                        };

                        logica.GuardarNombreFoto(dto);
                        ViewBag.UploadFileMessage = "Archivo cargado correctamente";
                        ModeloCargaImagenProducto modeloView = CrearModeloCargarImagenProducto(modelo.Id);
                        return View(modeloView);
                    }
                    catch
                    {

                    }

                }
                ViewBag.UploadFileMessage = "Por favor selecciones un archivo";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.UploadFileMessage = "Error al cargar el archivo";
                return View();
            }
        }

        [HttpPost]
        public ActionResult EliminarFoto(int idFotoProducto, string nombreFotoProducto)
        {
            bool respuesta = logica.EliminarRegistroFoto(idFotoProducto);
            if (respuesta)
            {
                string rutaCarpeta = DatosGenerales.RutaArchivosProductos;
                string CarpetaEliminados = DatosGenerales.CarpetaFotosProductosEliminadas;

                string rutaOrigenCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreFotoProducto);
                string rutaDestinoCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), CarpetaEliminados, nombreFotoProducto);
                System.IO.File.Move(rutaOrigenCompletaArchivo, rutaDestinoCompletaArchivo);
            }
            return RedirectToAction("Index");
        }

        public FileStreamResult Print() 
        {
            DateTime hoy = DateTime.Now;
            string fecha_creacion = String.Format("{0}_{1}_{2}_{3}", hoy.Day, hoy.Hour, hoy.Minute, hoy.Millisecond);
            string nombreArchivo = string.Concat("Productos_" + fecha_creacion +".pdf");
            string ruta = Server.MapPath("~/pdfReports/Profuctos/" + nombreArchivo);
            MapeadorProductoGUI mapeador = new MapeadorProductoGUI();
            IEnumerable<ModeloProducto> listaDatos = mapeador.MapearTipo1Tipo2(logica.ListarRegistrosReporte());
            FabricaArchivosPDF fabrica = new FabricaArchivosPDF();
            bool archivoCreado = fabrica.CrearListadoProductosEnPDF(ruta, "Listado Productos", listaDatos);
            if (archivoCreado)
            {
                var fileStream = new FileStream(ruta,
                                                FileMode.Open,
                                                FileAccess.Read
                                                );
                var fsResult = new FileStreamResult(fileStream, "application/pdf");
                return fsResult;
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}
