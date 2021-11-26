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

namespace Inventario.GUI.Controllers.Parametros
{
    public class EspacioController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: Espacio
        public async Task<ActionResult> Index()
        {
            var tb_espacio = db.tb_espacio.Include(t => t.tb_piso);
            return View(await tb_espacio.ToListAsync());
        }

        // GET: Espacio/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_espacio tb_espacio = await db.tb_espacio.FindAsync(id);
            if (tb_espacio == null)
            {
                return HttpNotFound();
            }
            return View(tb_espacio);
        }

        // GET: Espacio/Create
        public ActionResult Create()
        {
            ViewBag.id_piso = new SelectList(db.tb_piso, "id", "nombre");
            return View();
        }

        // POST: Espacio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre,id_piso")] tb_espacio tb_espacio)
        {
            if (ModelState.IsValid)
            {
                db.tb_espacio.Add(tb_espacio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_piso = new SelectList(db.tb_piso, "id", "nombre", tb_espacio.id_piso);
            return View(tb_espacio);
        }

        // GET: Espacio/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_espacio tb_espacio = await db.tb_espacio.FindAsync(id);
            if (tb_espacio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_piso = new SelectList(db.tb_piso, "id", "nombre", tb_espacio.id_piso);
            return View(tb_espacio);
        }

        // POST: Espacio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,id_piso")] tb_espacio tb_espacio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_espacio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_piso = new SelectList(db.tb_piso, "id", "nombre", tb_espacio.id_piso);
            return View(tb_espacio);
        }

        // GET: Espacio/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_espacio tb_espacio = await db.tb_espacio.FindAsync(id);
            if (tb_espacio == null)
            {
                return HttpNotFound();
            }
            return View(tb_espacio);
        }

        // POST: Espacio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_espacio tb_espacio = await db.tb_espacio.FindAsync(id);
            db.tb_espacio.Remove(tb_espacio);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
