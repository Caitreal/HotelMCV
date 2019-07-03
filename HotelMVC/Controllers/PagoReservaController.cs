using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelMVC;

namespace HotelMVC.Controllers
{
    public class PagoReservaController : Controller
    {
        private hotel db = new hotel();

        // GET: PagoReserva
        public ActionResult Index()
        {
            var pagoReserva = db.PagoReserva.Include(p => p.Reserva);
            return View(pagoReserva.ToList());
        }

        // GET: PagoReserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagoReserva pagoReserva = db.PagoReserva.Find(id);
            if (pagoReserva == null)
            {
                return HttpNotFound();
            }
            return View(pagoReserva);
        }

        // GET: PagoReserva/Create
        public ActionResult Create()
        {
            ViewBag.ReservaId = new SelectList(db.Reserva, "Id", "Id");
            return View();
        }

        // POST: PagoReserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReservaId,Pago,FechaPago")] PagoReserva pagoReserva)
        {
            if (ModelState.IsValid)
            {
                db.PagoReserva.Add(pagoReserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReservaId = new SelectList(db.Reserva, "Id", "Id", pagoReserva.ReservaId);
            return View(pagoReserva);
        }

        // GET: PagoReserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagoReserva pagoReserva = db.PagoReserva.Find(id);
            if (pagoReserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReservaId = new SelectList(db.Reserva, "Id", "Id", pagoReserva.ReservaId);
            return View(pagoReserva);
        }

        // POST: PagoReserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReservaId,Pago,FechaPago")] PagoReserva pagoReserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagoReserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReservaId = new SelectList(db.Reserva, "Id", "Id", pagoReserva.ReservaId);
            return View(pagoReserva);
        }

        // GET: PagoReserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagoReserva pagoReserva = db.PagoReserva.Find(id);
            if (pagoReserva == null)
            {
                return HttpNotFound();
            }
            return View(pagoReserva);
        }

        // POST: PagoReserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagoReserva pagoReserva = db.PagoReserva.Find(id);
            db.PagoReserva.Remove(pagoReserva);
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
