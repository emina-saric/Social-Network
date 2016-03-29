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
    public class RazgovoriController : Controller
    {
        private Social_NetworkContext db = new Social_NetworkContext();

        // GET: Razgovori
        public async Task<ActionResult> Index()
        {
            return View(await db.Razgovors.ToListAsync());
        }

        // GET: Razgovori/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Razgovor razgovor = await db.Razgovors.FindAsync(id);
            if (razgovor == null)
            {
                return HttpNotFound();
            }
            return View(razgovor);
        }

        // GET: Razgovori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Razgovori/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Razgovor razgovor)
        {
            if (ModelState.IsValid)
            {
                db.Razgovors.Add(razgovor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(razgovor);
        }

        // GET: Razgovori/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Razgovor razgovor = await db.Razgovors.FindAsync(id);
            if (razgovor == null)
            {
                return HttpNotFound();
            }
            return View(razgovor);
        }

        // POST: Razgovori/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Razgovor razgovor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(razgovor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(razgovor);
        }

        // GET: Razgovori/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Razgovor razgovor = await db.Razgovors.FindAsync(id);
            if (razgovor == null)
            {
                return HttpNotFound();
            }
            return View(razgovor);
        }

        // POST: Razgovori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Razgovor razgovor = await db.Razgovors.FindAsync(id);
            db.Razgovors.Remove(razgovor);
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
