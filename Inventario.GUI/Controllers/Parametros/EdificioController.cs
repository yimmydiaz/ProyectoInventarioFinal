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
    public class EdificioController : Controller
    {
        private ImplEdificioLogica logica = new ImplEdificioLogica();
        private ImplSedeLogica sede = new ImplSedeLogica();

        // GET: Edificio
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<EdificioDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorEdificioGUI mapper = new MapeadorEdificioGUI();
            IEnumerable<ModeloEdificio> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloEdificio>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }

        // GET: Edificio/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EdificioDTO EdificioDTO = logica.BuscarRegistro(id.Value);
            if (EdificioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorEdificioGUI mapper = new MapeadorEdificioGUI();
            ModeloEdificio modelo = mapper.MapearTipo1Tipo2(EdificioDTO);
            return View(modelo);
        }

        // GET: Edificio/Create
        public ActionResult Create()
        {
            IEnumerable<SedeDTO> listaDatos = sede.ListarSedes();
            MapeadorSedeGUI mapper = new MapeadorSedeGUI();
            
            ViewBag.id_sede = new SelectList(mapper.MapearTipo1Tipo2(listaDatos), "id", "nombre");
            return View();
        }

        // POST: Edificio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,id_sede")] ModeloEdificio modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorEdificioGUI mapper = new MapeadorEdificioGUI();
                EdificioDTO edificioDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(edificioDTO);
                return RedirectToAction("Index");
            }
            IEnumerable<SedeDTO> listaDatos = sede.ListarSedes();
            MapeadorSedeGUI mapper1 = new MapeadorSedeGUI();
            ViewBag.id_sede = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre",modelo.NombreSede);
            return View(modelo);
        }

        // GET: Edificio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EdificioDTO edificioDTO = logica.BuscarRegistro(id.Value);
            if (edificioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorEdificioGUI mapper = new MapeadorEdificioGUI();
            ModeloEdificio modelo = mapper.MapearTipo1Tipo2(edificioDTO);

            IEnumerable<SedeDTO> listaDatos = sede.ListarSedes();
            MapeadorSedeGUI mapper1 = new MapeadorSedeGUI();
            ViewBag.id_sede = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre",edificioDTO.NombreSede);
            return View(modelo);
        }

        // POST: Edificio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,id_sede")] ModeloEdificio modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorEdificioGUI mapper = new MapeadorEdificioGUI();
                EdificioDTO edificioDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(edificioDTO);
                return RedirectToAction("Index");
            }
            IEnumerable<SedeDTO> listaDatos = sede.ListarSedes();
            MapeadorSedeGUI mapper1 = new MapeadorSedeGUI();
            ViewBag.id_sede = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre", modelo.Id_Sede);
            return View(modelo);
        }

        // GET: Edificio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EdificioDTO edificioDTO = logica.BuscarRegistro(id.Value);
            if (edificioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorEdificioGUI mapper = new MapeadorEdificioGUI();
            ModeloEdificio modelo = mapper.MapearTipo1Tipo2(edificioDTO);
            return View(modelo);
        }

        // POST: Edificio/Delete/5
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
                EdificioDTO edificioDTO = logica.BuscarRegistro(id);
                if (edificioDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorEdificioGUI mapper = new MapeadorEdificioGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloEdificio modelo = mapper.MapearTipo1Tipo2(edificioDTO);
                return View(modelo);
            }
        }

        
    }
}
