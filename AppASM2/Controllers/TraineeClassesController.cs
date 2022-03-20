using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppASM2.Models;

namespace AppASM2.Controllers
{
    public class TraineeClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TraineeClasses
        public ActionResult Index()
        {
            var traineeClasses = db.TraineeClasses.Include(t => t.Class);
            return View(traineeClasses.ToList());
        }

        // GET: TraineeClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeClass traineeClass = db.TraineeClasses.Find(id);
            if (traineeClass == null)
            {
                return HttpNotFound();
            }
            return View(traineeClass);
        }

        // GET: TraineeClasses/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "Code");
            return View();
        }

        // POST: TraineeClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TraineeClassId,Grade,ClassId,ApplicationUserId")] TraineeClass traineeClass)
        {
            if (ModelState.IsValid)
            {
                db.TraineeClasses.Add(traineeClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "Code", traineeClass.ClassId);
            return View(traineeClass);
        }

        // GET: TraineeClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeClass traineeClass = db.TraineeClasses.Find(id);
            if (traineeClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "Code", traineeClass.ClassId);
            return View(traineeClass);
        }

        // POST: TraineeClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraineeClassId,Grade,ClassId,ApplicationUserId")] TraineeClass traineeClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traineeClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "Code", traineeClass.ClassId);
            return View(traineeClass);
        }

        // GET: TraineeClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraineeClass traineeClass = db.TraineeClasses.Find(id);
            if (traineeClass == null)
            {
                return HttpNotFound();
            }
            return View(traineeClass);
        }

        // POST: TraineeClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraineeClass traineeClass = db.TraineeClasses.Find(id);
            db.TraineeClasses.Remove(traineeClass);
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
