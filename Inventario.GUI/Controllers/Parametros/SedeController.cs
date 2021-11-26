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
    public class SedeController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: Sede
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_sede.ToListAsync());
        }

        // GET: Sede/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sede tb_sede = await db.tb_sede.FindAsync(id);
            if (tb_sede == null)
            {
                return HttpNotFound();
            }
            return View(tb_sede);
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
        public async Task<ActionResult> Create([Bind(Include = "id,nombre,direccion")] tb_sede tb_sede)
        {
            if (ModelState.IsValid)
            {
                db.tb_sede.Add(tb_sede);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_sede);
        }

        // GET: Sede/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sede tb_sede = await db.tb_sede.FindAsync(id);
            if (tb_sede == null)
            {
                return HttpNotFound();
            }
            return View(tb_sede);
        }

        // POST: Sede/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,direccion")] tb_sede tb_sede)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_sede).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_sede);
        }

        // GET: Sede/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_sede tb_sede = await db.tb_sede.FindAsync(id);
            if (tb_sede == null)
            {
                return HttpNotFound();
            }
            return View(tb_sede);
        }

        // POST: Sede/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_sede tb_sede = await db.tb_sede.FindAsync(id);
            db.tb_sede.Remove(tb_sede);
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
