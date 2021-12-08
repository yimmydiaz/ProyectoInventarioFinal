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
using LogicaNegocio.Implementacion.Asociar;
using Inventario.GUI.Helpers;
using LogicaNegocio.DTO.Asociar;
using Inventario.GUI.Mapeadores.Asociar;
using Inventario.GUI.Models.Asociar;
using PagedList;
using LogicaNegocio.Implementacion.Producto;
using LogicaNegocio.DTO.Producto;
using Inventario.GUI.Mapeadores.Producto;

namespace Inventario.GUI.Controllers.Asociar
{
    public class AsociarController : Controller
    {
        private ImplAsociarLogica logica = new ImplAsociarLogica();
        private ImplProductoLogica implProducto = new ImplProductoLogica();

        // GET: Asociar
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<AsociarDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorAsociarGUI mapper = new MapeadorAsociarGUI();
            IEnumerable<ModeloAsociar> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloAsociar>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }
        // GET: Asociar/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsociarDTO AsociarDTO = logica.BuscarRegistro(id.Value);
            if (AsociarDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAsociarGUI mapper = new MapeadorAsociarGUI();
            ModeloAsociar modelo = mapper.MapearTipo1Tipo2(AsociarDTO);
            return View(modelo);
        }

        // GET: Asociar/Create
        public ActionResult Create()
        {
            IEnumerable<ProductoDTO> listaDatos = implProducto.ListarProductos();
            MapeadorProductoGUI mapper = new MapeadorProductoGUI();

           // ViewBag.id_persona = new SelectList(db.tb_persona, "id", "cedula");
           // ViewBag.id_producto = new SelectList(mapper.MapearTipo1Tipo2(listaDatos), "id", "nombre");
            return View();
        }

        // POST: Asociar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ubicacion,id_producto,id_persona")] ModeloAsociar modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorAsociarGUI mapper = new MapeadorAsociarGUI();
                AsociarDTO asociarDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(asociarDTO);
                return RedirectToAction("Index");
            }
            IEnumerable<ProductoDTO> listaDatos = implProducto.ListarProductos();
            MapeadorProductoGUI mapper1 = new MapeadorProductoGUI();

           // ViewBag.id_persona = new SelectList(db.tb_persona, "id", "cedula", tb_asociar.id_persona);
            ViewBag.id_producto = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre", modelo.NombreProducto);
            return View(modelo);
        }

        // GET: Asociar/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsociarDTO asociarDTO = logica.BuscarRegistro(id.Value);
            if (asociarDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAsociarGUI mapper = new MapeadorAsociarGUI();
            ModeloAsociar modelo = mapper.MapearTipo1Tipo2(asociarDTO);

            IEnumerable<ProductoDTO> listaDatos = implProducto.ListarProductos();
            MapeadorProductoGUI mapper1 = new MapeadorProductoGUI();

            //ViewBag.id_persona = new SelectList(db.tb_persona, "id", "cedula", tb_asociar.id_persona);
            ViewBag.id_producto = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre", asociarDTO.NombreProducto);
            return View(modelo);
        }

        // POST: Asociar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ubicacion,id_producto,id_persona")] ModeloAsociar modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorAsociarGUI mapper = new MapeadorAsociarGUI();
                AsociarDTO edificioDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(edificioDTO);
                return RedirectToAction("Index");
            }

            IEnumerable<ProductoDTO> listaDatos = implProducto.ListarProductos();
            MapeadorProductoGUI mapper1 = new MapeadorProductoGUI();

           // ViewBag.id_persona = new SelectList(db.tb_persona, "id", "cedula", tb_asociar.id_persona);
            ViewBag.id_producto = new SelectList(mapper1.MapearTipo1Tipo2(listaDatos), "id", "nombre", modelo.NombreProducto);
            return View(modelo);
        }

        // GET: Asociar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsociarDTO asociarDTO = logica.BuscarRegistro(id.Value);
            if (asociarDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorAsociarGUI mapper = new MapeadorAsociarGUI();
            ModeloAsociar modelo = mapper.MapearTipo1Tipo2(asociarDTO);
            return View(modelo);
        }


        // POST: Asociar/Delete/5
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
                AsociarDTO asociarDTO = logica.BuscarRegistro(id);
                if (asociarDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorAsociarGUI mapper = new MapeadorAsociarGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloAsociar modelo = mapper.MapearTipo1Tipo2(asociarDTO);
                return View(modelo);
            }
        }
    }
}
