using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Social_Network.Models;

namespace Social_Network.Controllers
{
    [Authorize]
    public class ObjaveController : Controller
    {
        private Social_NetworkContext db = new Social_NetworkContext();

        // GET: Objave
        public async Task<ActionResult> Index()
        {
            return View(await db.Objavas.ToListAsync());
        }

        // GET: Objave/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objava objava = await db.Objavas.FindAsync(id);
            if (objava == null)
            {
                return HttpNotFound();
            }
            return View(objava);
        }

        // GET: Objave/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Objave/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] Objava objava)
        {
            if (ModelState.IsValid)
            {
                db.Objavas.Add(objava);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(objava);
        }

        // GET: Objave/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objava objava = await db.Objavas.FindAsync(id);
            if (objava == null)
            {
                return HttpNotFound();
            }
            return View(objava);
        }

        // POST: Objave/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Objava objava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objava).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(objava);
        }

        // GET: Objave/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objava objava = await db.Objavas.FindAsync(id);
            if (objava == null)
            {
                return HttpNotFound();
            }
            return View(objava);
        }

        // POST: Objave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Objava objava = await db.Objavas.FindAsync(id);
            db.Objavas.Remove(objava);
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
