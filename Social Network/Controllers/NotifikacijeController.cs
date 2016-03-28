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
    public class NotifikacijeController : Controller
    {
        private Social_NetworkContext db = new Social_NetworkContext();

        // GET: Notifikacije
        public async Task<ActionResult> Index()
        {
            return View(await db.Notifikacijas.ToListAsync());
        }

        // GET: Notifikacije/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notifikacija notifikacija = await db.Notifikacijas.FindAsync(id);
            if (notifikacija == null)
            {
                return HttpNotFound();
            }
            return View(notifikacija);
        }

        // GET: Notifikacije/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notifikacije/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id")] Notifikacija notifikacija)
        {
            if (ModelState.IsValid)
            {
                db.Notifikacijas.Add(notifikacija);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(notifikacija);
        }

        // GET: Notifikacije/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notifikacija notifikacija = await db.Notifikacijas.FindAsync(id);
            if (notifikacija == null)
            {
                return HttpNotFound();
            }
            return View(notifikacija);
        }

        // POST: Notifikacije/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Notifikacija notifikacija)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notifikacija).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(notifikacija);
        }

        // GET: Notifikacije/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notifikacija notifikacija = await db.Notifikacijas.FindAsync(id);
            if (notifikacija == null)
            {
                return HttpNotFound();
            }
            return View(notifikacija);
        }

        // POST: Notifikacije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Notifikacija notifikacija = await db.Notifikacijas.FindAsync(id);
            db.Notifikacijas.Remove(notifikacija);
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
