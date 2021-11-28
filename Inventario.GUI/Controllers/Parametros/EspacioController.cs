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
using Inventario.GUI.Models.Parametros;
using Inventario.GUI.Mapeadores.Parametros;
using PagedList;
using LogicaNegocio.DTO;

namespace Inventario.GUI.Controllers.Parametros
{
    public class EspacioController : Controller
    {
        private ImplEspacioLogica logica = new ImplEspacioLogica();
        private ImplPisoLogica sede = new ImplPisoLogica();

        // GET: Espacio
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<EspacioDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
            IEnumerable<ModeloEspacio> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloEspacio>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }

        // GET: Espacio/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspacioDTO EspacioDTO = logica.BuscarRegistro(id.Value);
            if (EspacioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
            ModeloEspacio modelo = mapper.MapearTipo1Tipo2(EspacioDTO);
            return View(modelo);
        }

        // GET: Espacio/Create
        public ActionResult Create()
        {
            IEnumerable<PisoDTO> listaDatos = sede.ListarPisos();
            MapeadorPisoGUI mapper = new MapeadorPisoGUI();

            ViewBag.id_piso = new SelectList(mapper.MapearTipo1Tipo2(listaDatos), "id", "nombre");
            return View();
        }

        // POST: Espacio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,id_piso")] ModeloEspacio modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
                EspacioDTO edificioDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(edificioDTO);
                return RedirectToAction("Index");
            }
            IEnumerable<PisoDTO> listaDatos = sede.ListarPisos();
            MapeadorPisoGUI mapper1 = new MapeadorPisoGUI();
            ViewBag.id_piso = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre", modelo.NombrePiso);
            return View(modelo);
        }

        // GET: Espacio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspacioDTO edificioDTO = logica.BuscarRegistro(id.Value);
            if (edificioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
            ModeloEspacio modelo = mapper.MapearTipo1Tipo2(edificioDTO);

            IEnumerable<PisoDTO> listaDatos = sede.ListarPisos();
            MapeadorPisoGUI mapper1 = new MapeadorPisoGUI();
            ViewBag.id_piso = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre", edificioDTO.NombrePiso);
            return View(modelo);
        }

        // POST: Espacio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,id_piso")] ModeloEspacio modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
                EspacioDTO edificioDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(edificioDTO);
                return RedirectToAction("Index");
            }
            IEnumerable<PisoDTO> listaDatos = sede.ListarPisos();
            MapeadorPisoGUI mapper1 = new MapeadorPisoGUI();
            ViewBag.id_piso = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre", modelo.Id_Piso);
            return View(modelo);
        }

        // GET: Espacio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspacioDTO edificioDTO = logica.BuscarRegistro(id.Value);
            if (edificioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
            ModeloEspacio modelo = mapper.MapearTipo1Tipo2(edificioDTO);
            return View(modelo);
        }

        // POST: Espacio/Delete/5
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
                EspacioDTO edificioDTO = logica.BuscarRegistro(id);
                if (edificioDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorEspacioGUI mapper = new MapeadorEspacioGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloEspacio modelo = mapper.MapearTipo1Tipo2(edificioDTO);
                return View(modelo);
            }
        }

    }
}
