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

namespace Inventario.GUI.Controllers.Asociar
{
    public class AsociarController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: Asociar
        public async Task<ActionResult> Index()
        {
            var tb_asociar = db.tb_asociar.Include(t => t.tb_persona).Include(t => t.tb_producto);
            return View(await tb_asociar.ToListAsync());
        }

        // GET: Asociar/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_asociar tb_asociar = await db.tb_asociar.FindAsync(id);
            if (tb_asociar == null)
            {
                return HttpNotFound();
            }
            return View(tb_asociar);
        }

        // GET: Asociar/Create
        public ActionResult Create()
        {
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "cedula");
            ViewBag.id_producto = new SelectList(db.tb_producto, "id", "nombre");
            return View();
        }

        // POST: Asociar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,ubicacion,id_producto,id_persona")] tb_asociar tb_asociar)
        {
            if (ModelState.IsValid)
            {
                db.tb_asociar.Add(tb_asociar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "cedula", tb_asociar.id_persona);
            ViewBag.id_producto = new SelectList(db.tb_producto, "id", "nombre", tb_asociar.id_producto);
            return View(tb_asociar);
        }

        // GET: Asociar/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_asociar tb_asociar = await db.tb_asociar.FindAsync(id);
            if (tb_asociar == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "cedula", tb_asociar.id_persona);
            ViewBag.id_producto = new SelectList(db.tb_producto, "id", "nombre", tb_asociar.id_producto);
            return View(tb_asociar);
        }

        // POST: Asociar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,ubicacion,id_producto,id_persona")] tb_asociar tb_asociar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_asociar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_persona = new SelectList(db.tb_persona, "id", "cedula", tb_asociar.id_persona);
            ViewBag.id_producto = new SelectList(db.tb_producto, "id", "nombre", tb_asociar.id_producto);
            return View(tb_asociar);
        }

        // GET: Asociar/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_asociar tb_asociar = await db.tb_asociar.FindAsync(id);
            if (tb_asociar == null)
            {
                return HttpNotFound();
            }
            return View(tb_asociar);
        }

        // POST: Asociar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_asociar tb_asociar = await db.tb_asociar.FindAsync(id);
            db.tb_asociar.Remove(tb_asociar);
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
