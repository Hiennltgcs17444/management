using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppASM2.Models;

namespace AppASM2.Areas.Staff.Controllers
{
    [Authorize(Roles = "Staff")]
    public class ManageTraineeClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Staff/ManageTraineeClasses
        public ActionResult Index()
        {
            var traineeClasses = db.TraineeClasses.Include(t => t.Class).Include(a=>a.Trainee);
            return View(traineeClasses.ToList());
        }

        // GET: Staff/ManageTraineeClasses/Details/5
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

        // GET: Staff/ManageTraineeClasses/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "Code","Topics");
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.TopicId = new SelectList(db.Topics, "TopicId", "Name");
            return View();
        }

        // POST: Staff/ManageTraineeClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TraineeClass traineeClass)
        {
            if (ModelState.IsValid)
            {
                db.TraineeClasses.Add(traineeClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "Code", "Topics", traineeClass.ClassId);
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", traineeClass.ApplicationUserId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code",traineeClass.Class.Course.Code);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", traineeClass.Class.Course.Category.Name);
            ViewBag.TopicId = new SelectList(db.Topics, "TopicId", "Name", traineeClass.Class.Topics);
            return View(traineeClass);
        }

        // GET: Staff/ManageTraineeClasses/Edit/5
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
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", traineeClass.ApplicationUserId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", traineeClass.Class.Course.Code);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", traineeClass.Class.Course.Category.Name);
            ViewBag.TopicId = new SelectList(db.Topics, "TopicId", "Name", traineeClass.Class.Topics);
            return View(traineeClass);
        }

        // POST: Staff/ManageTraineeClasses/Edit/5
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
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", traineeClass.ApplicationUserId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Code", traineeClass.Class.Course.Code);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", traineeClass.Class.Course.Category.Name);
            ViewBag.TopicId = new SelectList(db.Topics, "TopicId", "Name", traineeClass.Class.Topics);
            return View(traineeClass);
        }

        // GET: Staff/ManageTraineeClasses/Delete/5
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

        // POST: Staff/ManageTraineeClasses/Delete/5
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
