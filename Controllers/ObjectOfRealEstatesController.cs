using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    public class ObjectOfRealEstatesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ObjectOfRealEstates
        public ActionResult Index()
        {
            return View(db.ObjectOfRealEstates.ToList());
        }

        // GET: ObjectOfRealEstates/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectOfRealEstate objectOfRealEstate = db.ObjectOfRealEstates.Find(id);
            if (objectOfRealEstate == null)
            {
                return HttpNotFound();
            }
            return View(objectOfRealEstate);
        }

        // GET: ObjectOfRealEstates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ObjectOfRealEstates/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price")] ObjectOfRealEstate objectOfRealEstate)
        {
            if (ModelState.IsValid)
            {
                objectOfRealEstate.Id = Guid.NewGuid();
                db.ObjectOfRealEstates.Add(objectOfRealEstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objectOfRealEstate);
        }

        // GET: ObjectOfRealEstates/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectOfRealEstate objectOfRealEstate = db.ObjectOfRealEstates.Find(id);
            if (objectOfRealEstate == null)
            {
                return HttpNotFound();
            }
            return View(objectOfRealEstate);
        }

        // POST: ObjectOfRealEstates/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price")] ObjectOfRealEstate objectOfRealEstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objectOfRealEstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objectOfRealEstate);
        }

        // GET: ObjectOfRealEstates/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectOfRealEstate objectOfRealEstate = db.ObjectOfRealEstates.Find(id);
            if (objectOfRealEstate == null)
            {
                return HttpNotFound();
            }
            return View(objectOfRealEstate);
        }

        // POST: ObjectOfRealEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ObjectOfRealEstate objectOfRealEstate = db.ObjectOfRealEstates.Find(id);
            db.ObjectOfRealEstates.Remove(objectOfRealEstate);
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
