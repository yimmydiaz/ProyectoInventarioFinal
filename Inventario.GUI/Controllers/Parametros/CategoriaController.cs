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
using LogicaNegocio.DTO.Parametros;
using Inventario.GUI.Mapeadores.Parametros;
using Inventario.GUI.Models.Parametros;
using PagedList;
using Inventario.GUI.Helpers;

namespace Inventario.GUI.Controllers.Parametros
{
    public class CategoriaController : Controller
    {
        private ImplCategoriaLogica logica = new ImplCategoriaLogica();

        // GET: Categoria
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<CategoriaDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            IEnumerable<ModeloCategoria> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloCategoria>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }

        // GET: Categoria/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO CategoriaDTO = logica.BuscarRegistro(id.Value);
            if (CategoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoria modelo = mapper.MapearTipo1Tipo2(CategoriaDTO);
            return View(modelo);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre")] ModeloCategoria modelo)
        {

            if (ModelState.IsValid)
            {
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                CategoriaDTO categoriaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(categoriaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Categoria/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO categoriaDTO = logica.BuscarRegistro(id.Value);
            if (categoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoria modelo = mapper.MapearTipo1Tipo2(categoriaDTO);
            return View(modelo);
        }

        // POST: Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre")] ModeloCategoria modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                CategoriaDTO categoriaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(categoriaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Categoria/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaDTO categoriaDTO = logica.BuscarRegistro(id.Value);
            if (categoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
            ModeloCategoria modelo = mapper.MapearTipo1Tipo2(categoriaDTO);
            return View(modelo);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            bool respuesta = logica.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                CategoriaDTO categoriaDTO = logica.BuscarRegistro(id);
                if (categoriaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorCategoriaGUI mapper = new MapeadorCategoriaGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloCategoria modelo = mapper.MapearTipo1Tipo2(categoriaDTO);
                return View(modelo);
            }
        }

        
    }
}
