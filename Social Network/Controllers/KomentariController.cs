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
    public class KomentariController : Controller
    {
        private Social_NetworkContext db = new Social_NetworkContext();

        // GET: Komentari
        public async Task<ActionResult> Index()
        {
            var komentari = await db.Komentar.ToListAsync();
            return Json(komentari, JsonRequestBehavior.AllowGet);
        }

        // GET: Komentari/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = await db.Komentar.FindAsync(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            return View(komentar);
        }

        // GET: Komentari/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Komentari/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Komentar komentar)
        {
            if (ModelState.IsValid)
            {
                db.Komentar.Add(komentar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(komentar);
        }

        // GET: Komentari/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = await db.Komentar.FindAsync(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            return View(komentar);
        }

        // POST: Komentari/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Komentar komentar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komentar).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(komentar);
        }

        // GET: Komentari/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentar komentar = await db.Komentar.FindAsync(id);
            if (komentar == null)
            {
                return HttpNotFound();
            }
            return View(komentar);
        }

        // POST: Komentari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Komentar komentar = await db.Komentar.FindAsync(id);
            db.Komentar.Remove(komentar);
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
