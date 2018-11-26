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
    public class CoffeeShopsController : Controller
    {
        private ManagerhotelDbContext db = new ManagerhotelDbContext();

        // GET: CoffeeShops
        public ActionResult Index()
        {
            return View(db.CoffeeShop.ToList());
        }

        // GET: CoffeeShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoffeeShop coffeeShop = db.CoffeeShop.Find(id);
            if (coffeeShop == null)
            {
                return HttpNotFound();
            }
            return View(coffeeShop);
        }

        // GET: CoffeeShops/Create
        public ActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoffeeShopsCreateViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {  CoffeeShop CoffeeShopp = new CoffeeShop();
                var time = DateTime.Now.Hour;
                var Reservation = User.Identity.GetUserId()+time;
                
                CoffeeShopp.Eating = ViewModel.Eating;
                CoffeeShopp.Attendancetime = ViewModel.Attendancetime;
                CoffeeShopp.Attendancedate = ViewModel.Attendancedate;
                CoffeeShopp.Description = ViewModel.Description;
                CoffeeShopp.ReservationNumberCo = Reservation;
                db.CoffeeShop.Add(CoffeeShopp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ViewModel);
        }

        // GET: CoffeeShops/Edit/5
        public ActionResult Modern()
        {
          
            return View();
        }
        public ActionResult Sonati()
        {

            return View();
        }

        //// POST: CoffeeShops/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CoffeeShopId,ReservationNumberCo,Eating,Attendance,Description")] CoffeeShop coffeeShop)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(coffeeShop).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(coffeeShop);
        //}

        //// GET: CoffeeShops/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CoffeeShop coffeeShop = db.CoffeeShop.Find(id);
        //    if (coffeeShop == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(coffeeShop);
        //}

        //// POST: CoffeeShops/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CoffeeShop coffeeShop = db.CoffeeShop.Find(id);
        //    db.CoffeeShop.Remove(coffeeShop);
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
