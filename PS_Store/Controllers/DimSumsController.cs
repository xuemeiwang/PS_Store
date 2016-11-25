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
    public class DimSumsController : Controller
    {
        private PSStoreContext db = new PSStoreContext();

        // GET: DimSums
        public ActionResult Index()
        {
            return View(db.DimSums.ToList());
        }

        // GET: DimSums/Details/5
        public ActionResult Details(int? id)
        {
            // dimsums/details is not valid
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimSum dimSum = db.DimSums.Find(id);
            if (dimSum == null)
            {
                return HttpNotFound();
            }
            return View(dimSum);
        }

        // GET: DimSums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DimSums/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Name,ShortDescription,LongDescription,ThumbnailImage,FullImage,Price")] DimSum dimSum)
        {
            if (ModelState.IsValid)
            {
                db.DimSums.Add(dimSum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dimSum);
        }

        // GET: DimSums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimSum dimSum = db.DimSums.Find(id);
            if (dimSum == null)
            {
                return HttpNotFound();
            }
            return View(dimSum);
        }

        // POST: DimSums/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Name,ShortDescription,LongDescription,ThumbnailImage,FullImage,Price")] DimSum dimSum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimSum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dimSum);
        }

        // GET: DimSums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimSum dimSum = db.DimSums.Find(id);
            if (dimSum == null)
            {
                return HttpNotFound();
            }
            return View(dimSum);
        }

        // POST: DimSums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DimSum dimSum = db.DimSums.Find(id);
            db.DimSums.Remove(dimSum);
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
