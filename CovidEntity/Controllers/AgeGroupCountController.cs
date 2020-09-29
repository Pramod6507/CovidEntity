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
    public class AgeGroupCountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AgeGroupCount
        public ActionResult Index()
        {
            var ageGroupCount = db.AgeGroupCount.Include(a => a.CovidCount);
            return View(ageGroupCount.ToList());
        }

        // GET: AgeGroupCount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgeGroupCount ageGroupCount = db.AgeGroupCount.Find(id);
            if (ageGroupCount == null)
            {
                return HttpNotFound();
            }
            return View(ageGroupCount);
        }

        // GET: AgeGroupCount/Create
        public ActionResult Create()
        {
            ViewBag.CovidCountId = new SelectList(db.CovidCount, "Day", "Day");
            return View();
        }

        // POST: AgeGroupCount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartAge,EndAge,AgeCount,CovidCountId")] AgeGroupViewModel ageGroupCountVM)
        {
            if (ModelState.IsValid)
            {
                var ageGroupCount = new AgeGroupCount();
                var agedate = DateTime.Parse(ageGroupCountVM.CovidCountId.ToString());
                ageGroupCount.CovidCountId = db.CovidCount.Single(c => c.Day == agedate).Id;
                ageGroupCount.AgeCount = ageGroupCountVM.AgeCount;
                ageGroupCount.StartAge = ageGroupCountVM.StartAge;
                ageGroupCount.EndAge = ageGroupCountVM.EndAge;
                ageGroupCount.AgeCount = ageGroupCountVM.AgeCount;

                db.AgeGroupCount.Add(ageGroupCount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CovidCountId = new SelectList(db.CovidCount, "Id", "Id", ageGroupCountVM.CovidCountId);
            return View(ageGroupCountVM);
        }

        // GET: AgeGroupCount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgeGroupCount ageGroupCount = db.AgeGroupCount.Find(id);
            if (ageGroupCount == null)
            {
                return HttpNotFound();
            }
            ViewBag.CovidCountId = new SelectList(db.CovidCount, "Id", "Id", ageGroupCount.CovidCountId);
            return View(ageGroupCount);
        }

        // POST: AgeGroupCount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartAge,EndAge,AgeCount,CovidCountId")] AgeGroupCount ageGroupCount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ageGroupCount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CovidCountId = new SelectList(db.CovidCount, "Id", "Id", ageGroupCount.CovidCountId);
            return View(ageGroupCount);
        }

        // GET: AgeGroupCount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgeGroupCount ageGroupCount = db.AgeGroupCount.Find(id);
            if (ageGroupCount == null)
            {
                return HttpNotFound();
            }
            return View(ageGroupCount);
        }

        // POST: AgeGroupCount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgeGroupCount ageGroupCount = db.AgeGroupCount.Find(id);
            db.AgeGroupCount.Remove(ageGroupCount);
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
