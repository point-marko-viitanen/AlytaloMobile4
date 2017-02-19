using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlytaloMobile4.Database;

namespace AlytaloMobile4.Dropdown
{
    public class DropdownController : Controller
    {
        private AlytaloMobile2Entities db = new AlytaloMobile2Entities();

        // GET: Dropdown
        public ActionResult Index()
        {
            return View(db.Hallintas.ToList());
        }

        // GET: Dropdown/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hallinta hallinta = db.Hallintas.Find(id);
            if (hallinta == null)
            {
                return HttpNotFound();
            }
            return View(hallinta);
        }

        // GET: Dropdown/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dropdown/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Huone,Valot,Lämpötila,Pvm")] Hallinta hallinta)
        {
            if (ModelState.IsValid)
            {
                db.Hallintas.Add(hallinta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hallinta);
        }

        // GET: Dropdown/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hallinta hallinta = db.Hallintas.Find(id);
            if (hallinta == null)
            {
                return HttpNotFound();
            }
            return View(hallinta);
        }

        // POST: Dropdown/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Huone,Valot,Lämpötila,Pvm")] Hallinta hallinta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hallinta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hallinta);
        }

        // GET: Dropdown/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hallinta hallinta = db.Hallintas.Find(id);
            if (hallinta == null)
            {
                return HttpNotFound();
            }
            return View(hallinta);
        }

        // POST: Dropdown/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hallinta hallinta = db.Hallintas.Find(id);
            db.Hallintas.Remove(hallinta);
            db.SaveChanges();
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
