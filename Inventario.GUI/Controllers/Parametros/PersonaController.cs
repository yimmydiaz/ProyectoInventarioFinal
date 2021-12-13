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
using Inventario.GUI.Helpers;
using LogicaNegocio.DTO.Parametros;
using Inventario.GUI.Mapeadores.Parametros;
using Inventario.GUI.Models.Parametros;
using PagedList;
using LogicaNegocio.Implementacion.Parametros;

namespace Inventario.GUI.Controllers.Parametros
{
    public class PersonaController : Controller
    {
        private ImplPersonaLogica logica = new ImplPersonaLogica();

        // GET: Persona
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<PersonaDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            IEnumerable<ModeloPersona> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloPersona>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonaDTO PersonaDTO = logica.BuscarRegistro(id.Value);
            if (PersonaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            ModeloPersona modelo = mapper.MapearTipo1Tipo2(PersonaDTO);
            return View(modelo);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cedula,nombre,apellido,edad,correo,celular")] ModeloPersona modelo)
        {

            if (ModelState.IsValid)
            {
                MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
                PersonaDTO personaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(personaDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonaDTO personaDTO = logica.BuscarRegistro(id.Value);
            if (personaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            ModeloPersona modelo = mapper.MapearTipo1Tipo2(personaDTO);
            return View(modelo);
        }

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cedula,nombre,apellido,edad,correo,celular")] ModeloPersona modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
                PersonaDTO personaDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(personaDTO);
                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonaDTO personaDTO = logica.BuscarRegistro(id.Value);
            if (personaDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
            ModeloPersona modelo = mapper.MapearTipo1Tipo2(personaDTO);
            return View(modelo);
        }

        // POST: Persona/Delete/5
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
                PersonaDTO personaDTO = logica.BuscarRegistro(id);
                if (personaDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorPersonaGUI mapper = new MapeadorPersonaGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloPersona modelo = mapper.MapearTipo1Tipo2(personaDTO);
                return View(modelo);
            }
        }
    }
}
