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
    public class SlikeController : Controller
    {
        private Social_NetworkContext db = new Social_NetworkContext();

        // GET: Slike
        public async Task<ActionResult> Index()
        {
            var slike = await db.Slikas.ToListAsync();
            return Json(slike, JsonRequestBehavior.AllowGet);
            //return View(await db.Slikas.ToListAsync());
        }

        // GET: Slike/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = await db.Slikas.FindAsync(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // GET: Slike/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Slike/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Slika slika)
        {
            if (ModelState.IsValid)
            {
                db.Slikas.Add(slika);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(slika);
        }

        // GET: Slike/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = await db.Slikas.FindAsync(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // POST: Slike/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Slika slika)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slika).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(slika);
        }

        // GET: Slike/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = await db.Slikas.FindAsync(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // POST: Slike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Slika slika = await db.Slikas.FindAsync(id);
            db.Slikas.Remove(slika);
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
