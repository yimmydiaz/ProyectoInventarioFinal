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
using LogicaNegocio.DTO;
using Inventario.GUI.Helpers;
using Inventario.GUI.Mapeadores.Parametros;
using Inventario.GUI.Models.Parametros;
using PagedList;
using LogicaNegocio.DTO.Parametros;

namespace Inventario.GUI.Controllers.Parametros
{
    public class PisoController : Controller
    {
        private ImplPisoLogica logica = new ImplPisoLogica();
        private ImplEdificioLogica edificioLogica = new ImplEdificioLogica();

        // GET: Piso
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<PisoDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorPisoGUI mapper = new MapeadorPisoGUI();
            IEnumerable<ModeloPiso> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloPiso>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }


        // GET: Piso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PisoDTO PisoDTO = logica.BuscarRegistro(id.Value);
            if (PisoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPisoGUI mapper = new MapeadorPisoGUI();
            ModeloPiso modelo = mapper.MapearTipo1Tipo2(PisoDTO);
            return View(modelo);
        }

        // GET: Piso/Create
        public ActionResult Create()
        {
            IEnumerable<EdificioDTO> listaDatos = edificioLogica.ListarEdificios();
            MapeadorEdificioGUI mapper = new MapeadorEdificioGUI();
            ViewBag.id_edificio = new SelectList(mapper.MapearTipo1Tipo2(listaDatos), "id", "nombre");
            return View();
        }

        // POST: Piso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,numeroPiso,id_edificio")] ModeloPiso modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorPisoGUI mapper = new MapeadorPisoGUI();
                PisoDTO edificioDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(edificioDTO);
                return RedirectToAction("Index");
            }
            IEnumerable<EdificioDTO> listaDatos = edificioLogica.ListarEdificios();
            MapeadorEdificioGUI mapper1 = new MapeadorEdificioGUI();
            ViewBag.id_edificio = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre", modelo.NombreEdificio);
            return View(modelo);
        }

        // GET: Piso/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PisoDTO pisoDTO = logica.BuscarRegistro(id.Value);
            if (pisoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPisoGUI mapper = new MapeadorPisoGUI();
            ModeloPiso modelo = mapper.MapearTipo1Tipo2(pisoDTO);

            IEnumerable<EdificioDTO> listaDatos = edificioLogica.ListarEdificios();
            MapeadorEdificioGUI mapper1 = new MapeadorEdificioGUI();
            ViewBag.id_edificio = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre",pisoDTO.NombreEdificio);
            return View(modelo);
        }

        // POST: Piso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,numeroPiso,id_edificio")] ModeloPiso modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorPisoGUI mapper = new MapeadorPisoGUI();
                PisoDTO edificioDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(edificioDTO);
                return RedirectToAction("Index");
            }
            IEnumerable<EdificioDTO> listaDatos = edificioLogica.ListarEdificios();
            MapeadorEdificioGUI mapper1 = new MapeadorEdificioGUI();
            ViewBag.id_edificio = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre", modelo.NombreEdificio);
            return View(modelo);
        }

        // GET: Piso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PisoDTO edificioDTO = logica.BuscarRegistro(id.Value);
            if (edificioDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPisoGUI mapper = new MapeadorPisoGUI();
            ModeloPiso modelo = mapper.MapearTipo1Tipo2(edificioDTO);
            return View(modelo);
        }

        // POST: Piso/Delete/5
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
                PisoDTO edificioDTO = logica.BuscarRegistro(id);
                if (edificioDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorPisoGUI mapper = new MapeadorPisoGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloPiso modelo = mapper.MapearTipo1Tipo2(edificioDTO);
                return View(modelo);
            }
        }
    }
}
