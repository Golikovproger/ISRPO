using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kursovaya.Models;

namespace Kursovaya.Controllers
{
    public class DriversOnRoutesController : Controller
    {
        private CargoDataEntities db = new CargoDataEntities();

        // GET: DriversOnRoutes
        public ActionResult Index()
        {
            var driversOnRoutes = db.DriversOnRoutes.Include(d => d.Drivers).Include(d => d.Order);
            return View(driversOnRoutes.ToList());
        }

        // GET: DriversOnRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriversOnRoutes driversOnRoutes = db.DriversOnRoutes.Find(id);
            if (driversOnRoutes == null)
            {
                return HttpNotFound();
            }
            return View(driversOnRoutes);
        }

        // GET: DriversOnRoutes/Create
        public ActionResult Create()
        {
            ViewBag.IdDriver = new SelectList(db.Drivers, "Id", "Surname");
            ViewBag.IdOrder = new SelectList(db.Order, "Id", "Id");
            return View();
        }

        // POST: DriversOnRoutes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDriver,IdOrder,Award")] DriversOnRoutes driversOnRoutes)
        {
            if (ModelState.IsValid)
            {
                db.DriversOnRoutes.Add(driversOnRoutes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDriver = new SelectList(db.Drivers, "Id", "Surname", driversOnRoutes.IdDriver);
            ViewBag.IdOrder = new SelectList(db.Order, "Id", "Id", driversOnRoutes.IdOrder);
            return View(driversOnRoutes);
        }

        // GET: DriversOnRoutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriversOnRoutes driversOnRoutes = db.DriversOnRoutes.Find(id);
            if (driversOnRoutes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDriver = new SelectList(db.Drivers, "Id", "Surname", driversOnRoutes.IdDriver);
            ViewBag.IdOrder = new SelectList(db.Order, "Id", "Id", driversOnRoutes.IdOrder);
            return View(driversOnRoutes);
        }

        // POST: DriversOnRoutes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDriver,IdOrder,Award")] DriversOnRoutes driversOnRoutes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driversOnRoutes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDriver = new SelectList(db.Drivers, "Id", "Surname", driversOnRoutes.IdDriver);
            ViewBag.IdOrder = new SelectList(db.Order, "Id", "Id", driversOnRoutes.IdOrder);
            return View(driversOnRoutes);
        }

        // GET: DriversOnRoutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriversOnRoutes driversOnRoutes = db.DriversOnRoutes.Find(id);
            if (driversOnRoutes == null)
            {
                return HttpNotFound();
            }
            return View(driversOnRoutes);
        }

        // POST: DriversOnRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriversOnRoutes driversOnRoutes = db.DriversOnRoutes.Find(id);
            db.DriversOnRoutes.Remove(driversOnRoutes);
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
