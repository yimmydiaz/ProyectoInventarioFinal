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
    public class PisoController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: Piso
        public async Task<ActionResult> Index()
        {
            var tb_piso = db.tb_piso.Include(t => t.tb_edificio);
            return View(await tb_piso.ToListAsync());
        }

        // GET: Piso/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_piso tb_piso = await db.tb_piso.FindAsync(id);
            if (tb_piso == null)
            {
                return HttpNotFound();
            }
            return View(tb_piso);
        }

        // GET: Piso/Create
        public ActionResult Create()
        {
            ViewBag.id_edificio = new SelectList(db.tb_edificio, "id", "nombre");
            return View();
        }

        // POST: Piso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre,numeroPiso,id_edificio")] tb_piso tb_piso)
        {
            if (ModelState.IsValid)
            {
                db.tb_piso.Add(tb_piso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_edificio = new SelectList(db.tb_edificio, "id", "nombre", tb_piso.id_edificio);
            return View(tb_piso);
        }

        // GET: Piso/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_piso tb_piso = await db.tb_piso.FindAsync(id);
            if (tb_piso == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_edificio = new SelectList(db.tb_edificio, "id", "nombre", tb_piso.id_edificio);
            return View(tb_piso);
        }

        // POST: Piso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre,numeroPiso,id_edificio")] tb_piso tb_piso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_piso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_edificio = new SelectList(db.tb_edificio, "id", "nombre", tb_piso.id_edificio);
            return View(tb_piso);
        }

        // GET: Piso/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_piso tb_piso = await db.tb_piso.FindAsync(id);
            if (tb_piso == null)
            {
                return HttpNotFound();
            }
            return View(tb_piso);
        }

        // POST: Piso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_piso tb_piso = await db.tb_piso.FindAsync(id);
            db.tb_piso.Remove(tb_piso);
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
