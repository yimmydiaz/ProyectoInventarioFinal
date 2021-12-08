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
        private ImplMarcaLogica logica = new ImplMarcaLogica();

        // GET: Marca
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<MarcaDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
            IEnumerable<ModeloMarca> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloMarca>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaDTO MarcaDTO = logica.BuscarRegistro(id.Value);
            if (MarcaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
            ModeloMarca modelo = mapper.MapearTipo1Tipo2(MarcaDTO);
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
        public ActionResult Create([Bind(Include = "id,nombre")] ModeloMarca modelo)
        {

            if (ModelState.IsValid)
            {
                MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
                MarcaDTO MarcaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(MarcaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaDTO MarcaDTO = logica.BuscarRegistro(id.Value);
            if (MarcaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
            ModeloMarca modelo = mapper.MapearTipo1Tipo2(MarcaDTO);
            return View(modelo);
        }

        // POST: TipoProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] ModeloMarca modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
                MarcaDTO MarcaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(MarcaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaDTO MarcaDTO = logica.BuscarRegistro(id.Value);
            if (MarcaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
            ModeloMarca modelo = mapper.MapearTipo1Tipo2(MarcaDTO);
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
                MarcaDTO MarcaDTO = logica.BuscarRegistro(id);
                if (MarcaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorMarcaGUI mapper = new MapeadorMarcaGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloMarca modelo = mapper.MapearTipo1Tipo2(MarcaDTO);
                return View(modelo);
            }
        }


    }
}
