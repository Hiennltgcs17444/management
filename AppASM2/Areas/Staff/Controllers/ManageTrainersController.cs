using AppASM2.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AppASM2.Areas.Staff.Controllers
{
    [Authorize(Roles = "Staff")]
    public class ManageTrainersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Staff/ManageTrainee
        public ActionResult Index()
        {
            return View(db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains("Trainer")).ToList());
        }
        // GET: Staff/ManageTrainee/Edit/5
        // GET: Admin/ManageUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }
    }
}
