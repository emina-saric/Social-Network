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
    public class PorukeController : Controller
    {
        private Social_NetworkContext db = new Social_NetworkContext();

        // GET: Poruke
        public async Task<ActionResult> Index()
        {
            var poruke = await db.Poruka.ToListAsync();
            return Json(poruke, JsonRequestBehavior.AllowGet);
        }

        // GET: Poruke/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poruka poruka = await db.Poruka.FindAsync(id);
            if (poruka == null)
            {
                return HttpNotFound();
            }
            return View(poruka);
        }

        // GET: Poruke/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Poruke/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Poruka poruka)
        {
            if (ModelState.IsValid)
            {
                db.Poruka.Add(poruka);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(poruka);
        }

        // GET: Poruke/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poruka poruka = await db.Poruka.FindAsync(id);
            if (poruka == null)
            {
                return HttpNotFound();
            }
            return View(poruka);
        }

        // POST: Poruke/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Poruka poruka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poruka).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(poruka);
        }

        // GET: Poruke/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poruka poruka = await db.Poruka.FindAsync(id);
            if (poruka == null)
            {
                return HttpNotFound();
            }
            return View(poruka);
        }

        // POST: Poruke/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Poruka poruka = await db.Poruka.FindAsync(id);
            db.Poruka.Remove(poruka);
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
