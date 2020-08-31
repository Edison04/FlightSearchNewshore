using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlightSearhcNewshore.Models;

namespace FlightSearhcNewshore.Controllers
{
    public class FlightsController : Controller
    {
        private FlightEntities db = new FlightEntities();

        // GET: Flights
        public ActionResult Index()
        {
            var flight = db.Flight.Include(f => f.Transport);
            return View(flight.ToList());
        }

        // GET: Flights/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.IdTransport = new SelectList(db.Transport, "Id", "FlightNumber");
            return View();
        }

        // POST: Flights/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartureStation,ArribalStation,DepartureDate,Price,Currency,IdTransport")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flight.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTransport = new SelectList(db.Transport, "Id", "FlightNumber", flight.IdTransport);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTransport = new SelectList(db.Transport, "Id", "FlightNumber", flight.IdTransport);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartureStation,ArribalStation,DepartureDate,Price,Currency,IdTransport")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTransport = new SelectList(db.Transport, "Id", "FlightNumber", flight.IdTransport);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Flight flight = db.Flight.Find(id);
            db.Flight.Remove(flight);
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
