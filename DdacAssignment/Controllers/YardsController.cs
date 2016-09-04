using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DdacAssignment;

namespace DdacAssignment.Controllers
{
    
    public class YardsController : Controller
    {
        private ERDContainer db = new ERDContainer();

        // GET: Yards
        public ActionResult Index()
        {
            return View(db.Yards.ToList());
        }

        // GET: Yards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yard yard = db.Yards.Find(id);
            if (yard == null)
            {
                return HttpNotFound();
            }
            return View(yard);
        }

        // GET: Yards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Yards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,yard_name,port")] Yard yard)
        {
            if (ModelState.IsValid)
            {
                db.Yards.Add(yard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yard);
        }

        // GET: Yards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yard yard = db.Yards.Find(id);
            if (yard == null)
            {
                return HttpNotFound();
            }
            return View(yard);
        }

        // POST: Yards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,yard_name,port")] Yard yard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yard);
        }

        // GET: Yards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yard yard = db.Yards.Find(id);
            if (yard == null)
            {
                return HttpNotFound();
            }
            return View(yard);
        }

        // POST: Yards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yard yard = db.Yards.Find(id);
            db.Yards.Remove(yard);
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
