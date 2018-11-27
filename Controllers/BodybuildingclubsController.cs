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
    public class BodybuildingclubsController : Controller
    {
        private ManagerhotelDbContext db = new ManagerhotelDbContext();

        // GET: Bodybuildingclubs
        public ActionResult Index()
        {
            return View(db.Bodybuildingclub.ToList());
        }

        // GET: Bodybuildingclubs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodybuildingclub bodybuildingclub = db.Bodybuildingclub.Find(id);
            if (bodybuildingclub == null)
            {
                return HttpNotFound();
            }
            return View(bodybuildingclub);
        }

        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bodybuildingclub bodybuildingclub)
        {
            if (ModelState.IsValid)
            {
                db.Bodybuildingclub.Add(bodybuildingclub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bodybuildingclub);
        }
        public ActionResult bodyman()
        {
            return View();
        }
        public ActionResult bodywoman()
        {
            return View();
        }

        //// GET: Bodybuildingclubs/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Bodybuildingclub bodybuildingclub = db.Bodybuildingclub.Find(id);
        //    if (bodybuildingclub == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bodybuildingclub);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Bodybuildingclub bodybuildingclub)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(bodybuildingclub).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(bodybuildingclub);
        //}

        // GET: Bodybuildingclubs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Bodybuildingclub bodybuildingclub = db.Bodybuildingclub.Find(id);
        //    if (bodybuildingclub == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bodybuildingclub);
        //}

        // POST: Bodybuildingclubs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Bodybuildingclub bodybuildingclub = db.Bodybuildingclub.Find(id);
        //    db.Bodybuildingclub.Remove(bodybuildingclub);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
