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
    public class MarcaController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: Marca
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_marca.ToListAsync());
        }

        // GET: Marca/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = await db.tb_marca.FindAsync(id);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            return View(tb_marca);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,nombre")] tb_marca tb_marca)
        {
            if (ModelState.IsValid)
            {
                db.tb_marca.Add(tb_marca);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_marca);
        }

        // GET: Marca/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = await db.tb_marca.FindAsync(id);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            return View(tb_marca);
        }

        // POST: Marca/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre")] tb_marca tb_marca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_marca).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_marca);
        }

        // GET: Marca/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_marca tb_marca = await db.tb_marca.FindAsync(id);
            if (tb_marca == null)
            {
                return HttpNotFound();
            }
            return View(tb_marca);
        }

        // POST: Marca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_marca tb_marca = await db.tb_marca.FindAsync(id);
            db.tb_marca.Remove(tb_marca);
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
