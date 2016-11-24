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
    public class SpecialsController : Controller
    {
        private PSStoreContext db = new PSStoreContext();

        /// <summary>
        /// GET: Specials
        /// </summary>
        public ActionResult Index()
        {
            return View(db.Specials.ToList());
        }

        /// <summary>
        /// GET: Specials/Details/5
        /// </summary>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Special special = db.Specials.Find(id);
            if (special == null)
            {
                return HttpNotFound();
            }
            return View(special);
        }

        // GET: Specials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Name,ShortDescription,LongDescription,ThumbnailImage,FullImage,PriceBefore,Price")] Special special)
        {
            if (ModelState.IsValid)
            {
                db.Specials.Add(special);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(special);
        }

        // GET: Specials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Special special = db.Specials.Find(id);
            if (special == null)
            {
                return HttpNotFound();
            }
            return View(special);
        }

        // POST: Specials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Name,ShortDescription,LongDescription,ThumbnailImage,FullImage,PriceBefore,Price")] Special special)
        {
            if (ModelState.IsValid)
            {
                db.Entry(special).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(special);
        }

        // GET: Specials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Special special = db.Specials.Find(id);
            if (special == null)
            {
                return HttpNotFound();
            }
            return View(special);
        }

        // POST: Specials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Special special = db.Specials.Find(id);
            db.Specials.Remove(special);
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
