using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kursovaya.Models;

namespace Kursovaya.Controllers
{
    public class DriversController : Controller
    {
        private CargoDataEntities db = new CargoDataEntities();

        // GET: Drivers
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View(db.Drivers.ToList());
        //}

        //[HttpPost]
        public ActionResult Index(string SearchString, string sortOrder)
        {
            ViewBag.NameSortParm = sortOrder == "Name_desc" ? "Name" : "Name_desc";
            

            var value = from s in db.Drivers
                        select s;
            switch(sortOrder)
            {
                case "Name":
                    value = value.OrderBy(s => s.Name);
                    break;
                case "Name_desc":
                    value = value.OrderByDescending(s => s.Name);
                    break;
                
            }

            if(!String.IsNullOrEmpty(SearchString))
            {
                value = value.Where(s => s.Name.Contains(SearchString)
                               || s.Name.Contains(SearchString));
            }
            return View(value.ToList());
            //if (SearchString == "")
            //{
            //    return View(db.Drivers.ToList());
            //}

            //var drivers = db.Drivers;

            //var neee = drivers.Where(s => s.Surname.Contains(SearchString)
            //                   || s.Name.Contains(SearchString)).ToList();


            //return View(neee);
        }

        // GET: Drivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drivers drivers = db.Drivers.Find(id);
            if (drivers == null)
            {
                return HttpNotFound();
            }
            return View(drivers);
        }

        // GET: Drivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Surname,Name,Patronymic,PhoneNumber,Experience,Image")] Drivers drivers, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        drivers.Image = reader.ReadBytes(upload.ContentLength);
                    }
                }
                db.Drivers.Add(drivers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

         

            return View(drivers);
        }

        // GET: Drivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drivers drivers = db.Drivers.Find(id);
            if (drivers == null)
            {
                return HttpNotFound();
            }
            return View(drivers);
        }

        // POST: Drivers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Surname,Name,Patronymic,PhoneNumber,Experience,Image")] Drivers drivers, HttpPostedFileBase upload)
        {
            
                if (ModelState.IsValid)
                {
                    db.Entry(drivers).State = EntityState.Modified;
                    if (upload != null && upload.ContentLength > 0)
                    {
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            drivers.Image = reader.ReadBytes(upload.ContentLength);
                        }
                        db.SaveChanges();
                    }

                    else
                    {
                        db.Entry(drivers).Property(m => m.Image).IsModified = false;
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }

                return View(drivers);
            

        }

        // GET: Drivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drivers drivers = db.Drivers.Find(id);
            if (drivers == null)
            {
                return HttpNotFound();
            }
            return View(drivers);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drivers drivers = db.Drivers.Find(id);
            db.Drivers.Remove(drivers);
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
