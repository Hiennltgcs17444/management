using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AppASM2.Controllers;
using AppASM2.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AppASM2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageRoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ManageRole
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }
        // GET: Admin/ManageRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ManageRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IdentityRole Role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(Role);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Role);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdentityRole role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Staff/ManageCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Admin/Role/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var Role = await db.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Role == null)
            {
                return HttpNotFound();
            }

            return View(Role);
        }

        // POST: Admin/Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var Role = await db.Roles.FirstAsync(m => m.Id == id);
            db.Roles.Remove(Role);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(string id)
        {
            return db.Roles.Any(e => e.Id == id);
        }
    }
}

