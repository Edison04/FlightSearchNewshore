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
    public class TransportsController : Controller
    {
        private FlightEntities db = new FlightEntities();

        // GET: Transports
        public ActionResult Index()
        {
            return View(db.Transport.ToList());
        }

        // GET: Transports/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transport.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // GET: Transports/Create
        public ActionResult Create(DateTime DepartureDate, string FlightNumber, float Price, string Currency, string DepartureStation, string ArrivalStation)
        {
           
            if (DepartureStation != null && ArrivalStation != null)
            {
                Transport newTransport = new Transport
                {
                    FlightNumber = FlightNumber
                };
                Flight newFlight = new Flight
                {
                    DepartureStation = DepartureStation,
                    ArribalStation = ArrivalStation,
                    DepartureDate = DepartureDate,
                    Price = (decimal?)Price,
                    Currency = Currency

                 };

                ViewBag.Vuelo = newTransport.FlightNumber;
                ViewBag.Origin = newFlight.DepartureStation;
                ViewBag.Destination = newFlight.ArribalStation;
                ViewBag.Date = newFlight.DepartureDate;
                ViewBag.Price = "$"+newFlight.Price;
                ViewBag.Currency = newFlight.Currency;
            }


            return View();
        }

        // POST: Transports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create(DateTime DepartureDate, string FlightNumber, float Price, string Currency, string DepartureStation, string ArrivalStation, Transport transport)
        {

            if (DepartureStation != null && ArrivalStation != null)
            {
                Transport newTransport = new Transport
                {
                    FlightNumber = FlightNumber
                };
                Flight newFlight = new Flight
                {
                    DepartureStation = DepartureStation,
                    ArribalStation = ArrivalStation,
                    DepartureDate = DepartureDate,
                    Price = (decimal?)Price,
                    Currency = Currency
                };

                db.Transport.Add(newTransport);
                db.Flight.Add(newFlight);
                db.SaveChanges();

                
            }
            if (ModelState.IsValid)
            {
                //db.Transport.Add(transport);
                //db.SaveChanges();
                return RedirectToAction("Index", "Flights");
            }

            return View(transport);
        }

        // GET: Transports/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transport.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // POST: Transports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FlightNumber")] Transport transport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transport);
        }

        // GET: Transports/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transport transport = db.Transport.Find(id);
            if (transport == null)
            {
                return HttpNotFound();
            }
            return View(transport);
        }

        // POST: Transports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Transport transport = db.Transport.Find(id);
            db.Transport.Remove(transport);
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
