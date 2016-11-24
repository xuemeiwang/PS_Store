using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PS_Store.Models;

namespace PS_Store.Controllers
{
    public class EntreesController : Controller
    {
        private PSStoreContext db = new PSStoreContext();

        // GET: Entrees
        public ActionResult Index()
        {
            return View(db.Entrees.ToList());
        }

        // GET: Entrees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entree entree = db.Entrees.Find(id);
            if (entree == null)
            {
                return HttpNotFound();
            }
            return View(entree);
        }

        // GET: Entrees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Name,ShortDescription,LongDescription,ThumbnailImage,FullImage,Price")] Entree entree)
        {
            if (ModelState.IsValid)
            {
                db.Entrees.Add(entree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entree);
        }

        // GET: Entrees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entree entree = db.Entrees.Find(id);
            if (entree == null)
            {
                return HttpNotFound();
            }
            return View(entree);
        }

        // POST: Entrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Name,ShortDescription,LongDescription,ThumbnailImage,FullImage,Price")] Entree entree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entree);
        }

        // GET: Entrees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entree entree = db.Entrees.Find(id);
            if (entree == null)
            {
                return HttpNotFound();
            }
            return View(entree);
        }

        // POST: Entrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entree entree = db.Entrees.Find(id);
            db.Entrees.Remove(entree);
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
