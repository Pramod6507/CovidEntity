using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CovidEntity.Models;
using CovidEntity.Models.ViewModels;

namespace CovidEntity.Controllers
{
    public class RegionalCountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegionalCount
        public ActionResult Index()
        {
            var regionalCount = db.RegionalCount.Include(r => r.CovidCount);
            return View(regionalCount.ToList());
        }

        // GET: RegionalCount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionalCount regionalCount = db.RegionalCount.Find(id);
            if (regionalCount == null)
            {
                return HttpNotFound();
            }
            return View(regionalCount);
        }

        // GET: RegionalCount/Create
        public ActionResult Create()
        {
            ViewBag.CovidCountId = new SelectList(db.CovidCount, "Day", "Day");
            return View();
        }

        // POST: RegionalCount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Region,RegionTotal,RegionConfirmed,RegionInpatientHospitalization,RegionIcuHospitalization,RegionRecovered,RegionDeath,CovidCountId")] RegionalCountViewModel regionalCountVM)
        {
            if (ModelState.IsValid)
            {
                var regionalCount = new RegionalCount();
                var agedate = DateTime.Parse(regionalCountVM.CovidCountId.ToString());
                regionalCount.CovidCountId = db.CovidCount.Single(c => c.Day == agedate).Id;
                regionalCount.Region = regionalCountVM.Region;
                regionalCount.RegionTotal = regionalCountVM.RegionTotal;
                regionalCount.RegionConfirmed = regionalCountVM.RegionConfirmed;
                regionalCount.RegionInpatientHospitalization = regionalCountVM.RegionInpatientHospitalization;
                regionalCount.RegionIcuHospitalization = regionalCountVM.RegionIcuHospitalization;
                regionalCount.RegionRecovered = regionalCountVM.RegionRecovered;
                regionalCount.RegionDeath = regionalCountVM.RegionDeath;

                db.RegionalCount.Add(regionalCount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CovidCountId = new SelectList(db.CovidCount, "Id", "Id", regionalCountVM.CovidCountId);
            return View(regionalCountVM);
        }

        // GET: RegionalCount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionalCount regionalCount = db.RegionalCount.Find(id);
            if (regionalCount == null)
            {
                return HttpNotFound();
            }
            ViewBag.CovidCountId = new SelectList(db.CovidCount, "Id", "Id", regionalCount.CovidCountId);
            return View(regionalCount);
        }

        // POST: RegionalCount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Region,RegionTotal,RegionConfirmed,RegionInpatientHospitalization,RegionIcuHospitalization,RegionRecovered,RegionDeath,CovidCountId")] RegionalCount regionalCount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regionalCount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CovidCountId = new SelectList(db.CovidCount, "Id", "Id", regionalCount.CovidCountId);
            return View(regionalCount);
        }

        // GET: RegionalCount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionalCount regionalCount = db.RegionalCount.Find(id);
            if (regionalCount == null)
            {
                return HttpNotFound();
            }
            return View(regionalCount);
        }

        // POST: RegionalCount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegionalCount regionalCount = db.RegionalCount.Find(id);
            db.RegionalCount.Remove(regionalCount);
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
