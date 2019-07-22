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
    public class ReservaController : Controller
    {
        private hotel db = new hotel();

        // GET: Reserva
        public ActionResult Index()
        {
            var reserva = db.Reserva.Include(r => r.Cliente).Include(r => r.Habitacion).Include(r => r.Usuario);
            return View(reserva.ToList());
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reserva/Create
        public ActionResult Create()
        {

            var fechahoy = DateTime.Now;
            ViewBag.FechaHoy = fechahoy;
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Rut");
            ViewBag.HabitacionId = new SelectList(db.Habitacion, "Id", "Descripcion");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "NombreUsuario");
            return View();
        }

        // POST: Reserva/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,FechaInicio,NumeroNoches,ClienteId,UsuarioId,HabitacionId,CantidadPersonas")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FechaHoy = DateTime.Today;
                db.Reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Rut", reserva.ClienteId);
            ViewBag.HabitacionId = new SelectList(db.Habitacion, "Id", "Descripcion", reserva.HabitacionId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "NombreUsuario", reserva.UsuarioId);
            return View(reserva);
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Rut", reserva.ClienteId);
            ViewBag.HabitacionId = new SelectList(db.Habitacion, "Id", "Descripcion", reserva.HabitacionId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "NombreUsuario", reserva.UsuarioId);
            return View(reserva);
        }

        // POST: Reserva/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,FechaInicio,NumeroNoches,ClienteId,UsuarioId,HabitacionId,CantidadPersonas")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Rut", reserva.ClienteId);
            ViewBag.HabitacionId = new SelectList(db.Habitacion, "Id", "Descripcion", reserva.HabitacionId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "NombreUsuario", reserva.UsuarioId);
            return View(reserva);
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reserva.Find(id);
            db.Reserva.Remove(reserva);
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
