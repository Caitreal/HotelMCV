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
    public class TipoHabitacionController : Controller
    {
        private hotel db = new hotel();

        // GET: TipoHabitacion
        public ActionResult Index()
        {
            return View(db.TipoHabitacion.ToList());
        }

        // GET: TipoHabitacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoHabitacion tipoHabitacion = db.TipoHabitacion.Find(id);
            if (tipoHabitacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoHabitacion);
        }

        // GET: TipoHabitacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoHabitacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,CantidadPersonas")] TipoHabitacion tipoHabitacion)
        {
            if (ModelState.IsValid)
            {
                db.TipoHabitacion.Add(tipoHabitacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoHabitacion);
        }

        // GET: TipoHabitacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoHabitacion tipoHabitacion = db.TipoHabitacion.Find(id);
            if (tipoHabitacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoHabitacion);
        }

        // POST: TipoHabitacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,CantidadPersonas")] TipoHabitacion tipoHabitacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoHabitacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoHabitacion);
        }

        // GET: TipoHabitacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoHabitacion tipoHabitacion = db.TipoHabitacion.Find(id);
            if (tipoHabitacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoHabitacion);
        }

        // POST: TipoHabitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoHabitacion tipoHabitacion = db.TipoHabitacion.Find(id);
            db.TipoHabitacion.Remove(tipoHabitacion);
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
