using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DdacAssignment;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DdacAssignment.Controllers
{
    public class ShipmentsController : Controller
    {
        private ERDContainer db = new ERDContainer();

        // GET: Shipments
        public ActionResult Index()
        {
            var shipments = db.Shipments.Include(s => s.Customer).Include(s => s.Yard).Include(s => s.Ship);
            return View(shipments.ToList());
        }

        // GET: Shipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // GET: Shipments/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "name");
            ViewBag.YardId = new SelectList(db.Yards, "Id", "yard_name");
            ViewBag.ShipId = new SelectList(db.Ships, "Id", "name");
            return View();
        }

        // POST: Shipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,type,insured_value,weight,destination,status,CustomerId,YardId,ShipId,payment_status")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
               db.Shipments.Add(shipment);          
                db.SaveChanges();
                int id = shipment.Id;

                //   return RedirectToAction("Index");
                return RedirectToAction("Create", "Payments", new { shipmentid = id});
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "name", shipment.CustomerId);
            ViewBag.YardId = new SelectList(db.Yards, "Id", "yard_name", shipment.YardId);
            ViewBag.ShipId = new SelectList(db.Ships, "Id", "name", shipment.ShipId);
            return View(shipment);
          
        }

        // GET: Shipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "name", shipment.CustomerId);
            ViewBag.YardId = new SelectList(db.Yards, "Id", "yard_name", shipment.YardId);
            ViewBag.ShipId = new SelectList(db.Ships, "Id", "name", shipment.ShipId);
            return View(shipment);
        }

        // POST: Shipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,type,insured_value,weight,destination,status,CustomerId,YardId,ShipId,payment_status")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "name", shipment.CustomerId);
            ViewBag.YardId = new SelectList(db.Yards, "Id", "yard_name", shipment.YardId);
            ViewBag.ShipId = new SelectList(db.Ships, "Id", "name", shipment.ShipId);
            return View(shipment);
        }

        // GET: Shipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipment shipment = db.Shipments.Find(id);
            db.Shipments.Remove(shipment);
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
