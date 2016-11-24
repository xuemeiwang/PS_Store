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
    public class SoupsController : Controller
    {
        private PSStoreContext db = new PSStoreContext();

        // GET: Soups
        public ActionResult Index()
        {
            return View(db.Soups.ToList());
        }

        // GET: Soups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soup soup = db.Soups.Find(id);
            if (soup == null)
            {
                return HttpNotFound();
            }
            return View(soup);
        }

        // GET: Soups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Soups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Name,ShortDescription,LongDescription,ThumbnailImage,FullImage,Price")] Soup soup)
        {
            if (ModelState.IsValid)
            {
                db.Soups.Add(soup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soup);
        }

        // GET: Soups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soup soup = db.Soups.Find(id);
            if (soup == null)
            {
                return HttpNotFound();
            }
            return View(soup);
        }

        // POST: Soups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Name,ShortDescription,LongDescription,ThumbnailImage,FullImage,Price")] Soup soup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soup);
        }

        // GET: Soups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soup soup = db.Soups.Find(id);
            if (soup == null)
            {
                return HttpNotFound();
            }
            return View(soup);
        }

        // POST: Soups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soup soup = db.Soups.Find(id);
            db.Soups.Remove(soup);
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
