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
    public class EdificioController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: Edificio
        public async Task<ActionResult> Index()
        {
            var tb_edificio = db.tb_edificio.Include(t => t.tb_sede);
            return View(await tb_edificio.ToListAsync());
        }

        // GET: Edificio/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_edificio tb_edificio = await db.tb_edificio.FindAsync(id);
            if (tb_edificio == null)
            {
                return HttpNotFound();
            }
            return View(tb_edificio);
        }

        // GET: Edificio/Create
        public ActionResult Create()
        {
            ViewBag.id_sede = new SelectList(db.tb_sede, "id", "nombre");
            return View();
        }

        // POST: Edificio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre,id_sede")] tb_edificio tb_edificio)
        {
            if (ModelState.IsValid)
            {
                db.tb_edificio.Add(tb_edificio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_sede = new SelectList(db.tb_sede, "id", "nombre", tb_edificio.id_sede);
            return View(tb_edificio);
        }

        // GET: Edificio/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_edificio tb_edificio = await db.tb_edificio.FindAsync(id);
            if (tb_edificio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_sede = new SelectList(db.tb_sede, "id", "nombre", tb_edificio.id_sede);
            return View(tb_edificio);
        }

        // POST: Edificio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,id_sede")] tb_edificio tb_edificio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_edificio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_sede = new SelectList(db.tb_sede, "id", "nombre", tb_edificio.id_sede);
            return View(tb_edificio);
        }

        // GET: Edificio/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_edificio tb_edificio = await db.tb_edificio.FindAsync(id);
            if (tb_edificio == null)
            {
                return HttpNotFound();
            }
            return View(tb_edificio);
        }

        // POST: Edificio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_edificio tb_edificio = await db.tb_edificio.FindAsync(id);
            db.tb_edificio.Remove(tb_edificio);
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
