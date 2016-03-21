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
    public class PrijateljiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prijatelji
        public async Task<ActionResult> Index()
        {
            return View(await db.Prijateljs.ToListAsync());
        }

        // GET: Prijatelji/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijatelj prijatelj = await db.Prijateljs.FindAsync(id);
            if (prijatelj == null)
            {
                return HttpNotFound();
            }
            return View(prijatelj);
        }

        // GET: Prijatelji/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prijatelji/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] Prijatelj prijatelj)
        {
            if (ModelState.IsValid)
            {
                db.Prijateljs.Add(prijatelj);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(prijatelj);
        }

        // GET: Prijatelji/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijatelj prijatelj = await db.Prijateljs.FindAsync(id);
            if (prijatelj == null)
            {
                return HttpNotFound();
            }
            return View(prijatelj);
        }

        // POST: Prijatelji/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Prijatelj prijatelj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijatelj).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(prijatelj);
        }

        // GET: Prijatelji/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijatelj prijatelj = await db.Prijateljs.FindAsync(id);
            if (prijatelj == null)
            {
                return HttpNotFound();
            }
            return View(prijatelj);
        }

        // POST: Prijatelji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Prijatelj prijatelj = await db.Prijateljs.FindAsync(id);
            db.Prijateljs.Remove(prijatelj);
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
