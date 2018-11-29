using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Managerhotel.Models;
using Managerhotel.ViewModels;
using Microsoft.AspNet.Identity;

namespace Managerhotel.Controllers
{
    public class DiscoesController : Controller
    {
        private ManagerhotelDbContext db = new ManagerhotelDbContext();

        // GET: Discoes
        public ActionResult Index()
        {
            return View(db.Disco.ToList());
        }
        [Authorize]
        // GET: Discoes/Details/5
        public ActionResult Details(int? id)
        {
            id = User.Identity.GetUserId<int>();//getuserid

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disco disco = db.Disco.Find(id);
            if (disco == null)
            {
                return Content("رزرو برای شما ثبت نشده است ");
            }
            return View(disco);
        }
        [Authorize]
        // GET: Discoes/Create
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiscoCreateViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                Disco disco = new Disco();
                var time= DateTime.Now.Hour;
                var Reservation = User.Identity.GetUserId()+time;
                disco.Drinking = ViewModel.Drinking;
                disco.ReservationnumberDc = Reservation;
                disco.Attendancedate = ViewModel.Attendancedate;
                disco.Attendancetime = ViewModel.Attendancetime;
                disco.Description = ViewModel.Description;
                db.Disco.Add(disco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ViewModel);
        }

        public ActionResult Disconight()
        {

            return View();
        }
        public ActionResult Discoday()
        {

            return View();
        }
        // GET: Discoes/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Disco disco = db.Disco.Find(id);
        //    if (disco == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(disco);
        //}

        // POST: Discoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "DiscoId,ReservationnumberDc,Drinking,Attendance,Plan,Description")] Disco disco)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(disco).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(disco);
        //}

        //// GET: Discoes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Disco disco = db.Disco.Find(id);
        //    if (disco == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(disco);
        //}

        //// POST: Discoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Disco disco = db.Disco.Find(id);
        //    db.Disco.Remove(disco);
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
