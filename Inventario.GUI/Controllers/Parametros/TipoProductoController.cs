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
    public class TipoProductoController : Controller
    {
        private InventarioBDEntities db = new InventarioBDEntities();

        // GET: TipoProducto
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_tipo_producto.ToListAsync());
        }

        // GET: TipoProducto/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipo_producto tb_tipo_producto = await db.tb_tipo_producto.FindAsync(id);
            if (tb_tipo_producto == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipo_producto);
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
        public async Task<ActionResult> Create([Bind(Include = "id,nombre")] tb_tipo_producto tb_tipo_producto)
        {
            if (ModelState.IsValid)
            {
                db.tb_tipo_producto.Add(tb_tipo_producto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_tipo_producto);
        }

        // GET: TipoProducto/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipo_producto tb_tipo_producto = await db.tb_tipo_producto.FindAsync(id);
            if (tb_tipo_producto == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipo_producto);
        }

        // POST: TipoProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,nombre")] tb_tipo_producto tb_tipo_producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_tipo_producto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_tipo_producto);
        }

        // GET: TipoProducto/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_tipo_producto tb_tipo_producto = await db.tb_tipo_producto.FindAsync(id);
            if (tb_tipo_producto == null)
            {
                return HttpNotFound();
            }
            return View(tb_tipo_producto);
        }

        // POST: TipoProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_tipo_producto tb_tipo_producto = await db.tb_tipo_producto.FindAsync(id);
            db.tb_tipo_producto.Remove(tb_tipo_producto);
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
