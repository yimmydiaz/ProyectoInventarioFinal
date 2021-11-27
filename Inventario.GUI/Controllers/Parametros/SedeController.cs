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
    public class SedeController : Controller
    {
        private ImplSedeLogica logica = new ImplSedeLogica();

        // GET: Sede
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<SedeDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            IEnumerable<ModeloSede> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloSede>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }

        // GET: Sede/Details/5
        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SedeDTO SedeDTO = logica.BuscarRegistro(id.Value);
            if (SedeDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            ModeloSede modelo = mapper.MapearTipo1Tipo2(SedeDTO);
            return View(modelo);
        }

        // GET: Sede/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sede/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre,direccion")] ModeloSede modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorSedeGUI mapper = new MapeadorSedeGUI();
                SedeDTO categoriaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(categoriaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Sede/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SedeDTO categoriaDTO = logica.BuscarRegistro(id.Value);
            if (categoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            ModeloSede modelo = mapper.MapearTipo1Tipo2(categoriaDTO);
            return View(modelo);
        }

        // POST: Sede/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,direccion")] ModeloSede modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorSedeGUI mapper = new MapeadorSedeGUI();
                SedeDTO categoriaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(categoriaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Sede/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SedeDTO categoriaDTO = logica.BuscarRegistro(id.Value);
            if (categoriaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            ModeloSede modelo = mapper.MapearTipo1Tipo2(categoriaDTO);
            return View(modelo);
        }

        // POST: Sede/Delete/5
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
                SedeDTO categoriaDTO = logica.BuscarRegistro(id);
                if (categoriaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorSedeGUI mapper = new MapeadorSedeGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloSede modelo = mapper.MapearTipo1Tipo2(categoriaDTO);
                return View(modelo);
            }
        }

    }
}
