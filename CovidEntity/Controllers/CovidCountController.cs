using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CovidEntity.Models;

namespace CovidEntity.Controllers
{
    public class CovidCountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CovidCount
        public ActionResult Index()
        {
            return View(db.CovidCount.OrderBy(c => c.Day).ToList());
        }

        // GET: CovidCount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CovidCount covidCount = db.CovidCount.Find(id);
            if (covidCount == null)
            {
                return HttpNotFound();
            }
            return View(covidCount);
        }

        // GET: CovidCount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CovidCount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day,TotalCases,Confirmed,Recovered,Deaths")] CovidCount covidCount)
        {
            if (ModelState.IsValid)
            {
                db.CovidCount.Add(covidCount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(covidCount);
        }

        // GET: CovidCount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CovidCount covidCount = db.CovidCount.Find(id);
            if (covidCount == null)
            {
                return HttpNotFound();
            }
            return View(covidCount);
        }

        // POST: CovidCount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day,TotalCases,Confirmed,Recovered,Deaths")] CovidCount covidCount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(covidCount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(covidCount);
        }

        // GET: CovidCount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CovidCount covidCount = db.CovidCount.Find(id);
            if (covidCount == null)
            {
                return HttpNotFound();
            }
            return View(covidCount);
        }

        // POST: CovidCount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CovidCount covidCount = db.CovidCount.Find(id);
            db.CovidCount.Remove(covidCount);
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
