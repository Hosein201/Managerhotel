using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Managerhotel.Models;

namespace Managerhotel.Controllers
{
    public class MassagesalonsController : Controller
    {
        private ManagerhotelDbContext db = new ManagerhotelDbContext();

        // GET: Massagesalons
        public ActionResult Index()
        {
            return View(db.Massagesalon.ToList());
        }

        // GET: Massagesalons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Massagesalon massagesalon = db.Massagesalon.Find(id);
            if (massagesalon == null)
            {
                return HttpNotFound();
            }
            return View(massagesalon);
        }

        // GET: Massagesalons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Massagesalons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MassagesalonId,Attendance,PlanWoman,PlanMan,Massagelist,Description")] Massagesalon massagesalon)
        {
            if (ModelState.IsValid)
            {
                db.Massagesalon.Add(massagesalon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(massagesalon);
        }

        // GET: Massagesalons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Massagesalon massagesalon = db.Massagesalon.Find(id);
            if (massagesalon == null)
            {
                return HttpNotFound();
            }
            return View(massagesalon);
        }

        // POST: Massagesalons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MassagesalonId,Attendance,PlanWoman,PlanMan,Massagelist,Description")] Massagesalon massagesalon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(massagesalon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(massagesalon);
        }

        // GET: Massagesalons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Massagesalon massagesalon = db.Massagesalon.Find(id);
            if (massagesalon == null)
            {
                return HttpNotFound();
            }
            return View(massagesalon);
        }

        // POST: Massagesalons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Massagesalon massagesalon = db.Massagesalon.Find(id);
            db.Massagesalon.Remove(massagesalon);
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
