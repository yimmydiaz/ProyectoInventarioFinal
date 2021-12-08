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
using LogicaNegocio.Implementacion.Parametros;
using Inventario.GUI.Helpers;
using LogicaNegocio.DTO.Parametros;
using Inventario.GUI.Mapeadores.Parametros;
using Inventario.GUI.Models.Parametros;
using PagedList;

namespace Inventario.GUI.Controllers.Parametros
{
    public class MarcaController : Controller
    {
        private ImplTipoProductoLogica logica = new ImplTipoProductoLogica();

        // GET: TipoProducto
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<TipoProductoDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            IEnumerable<ModeloTipoProducto> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloTipoProducto>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }

        // GET: TipoProducto/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProductoDTO TipoProductoDTO = logica.BuscarRegistro(id.Value);
            if (TipoProductoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            ModeloTipoProducto modelo = mapper.MapearTipo1Tipo2(TipoProductoDTO);
            return View(modelo);
        }

        // GET: TipoProducto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] ModeloTipoProducto modelo)
        {

            if (ModelState.IsValid)
            {
                MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
                TipoProductoDTO categoriaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(categoriaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: TipoProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProductoDTO categoriaDTO = logica.BuscarRegistro(id.Value);
            if (categoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            ModeloTipoProducto modelo = mapper.MapearTipo1Tipo2(categoriaDTO);
            return View(modelo);
        }

        // POST: TipoProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] ModeloTipoProducto modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
                TipoProductoDTO categoriaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(categoriaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: TipoProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProductoDTO categoriaDTO = logica.BuscarRegistro(id.Value);
            if (categoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
            ModeloTipoProducto modelo = mapper.MapearTipo1Tipo2(categoriaDTO);
            return View(modelo);
        }

        // POST: TipoProducto/Delete/5
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
                TipoProductoDTO categoriaDTO = logica.BuscarRegistro(id);
                if (categoriaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorTipoProductoGUI mapper = new MapeadorTipoProductoGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloTipoProducto modelo = mapper.MapearTipo1Tipo2(categoriaDTO);
                return View(modelo);
            }
        }

    }
}
