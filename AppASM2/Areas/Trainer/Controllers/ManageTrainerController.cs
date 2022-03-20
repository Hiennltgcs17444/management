using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using AppASM2.Models;
using Microsoft.AspNet.Identity;

namespace AppASM2.Areas.Trainer.Controllers
{
    [Authorize(Roles = "Trainer")]
    public class ManageTrainerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Trainee/ApplicationUsers
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var classes = db.Classes.Include(c => c.Course).Include(c => c.Course.Category).Include(t => t.Topics);
            return View(classes.Where(x => x.Topics.Select(y => y.ApplicationUserId).Contains(userID)).ToList());
        }
         public ActionResult Details()
        {
            var userID = User.Identity.GetUserId();
            var classes = db.Classes.Include(c => c.Course).Include(c => c.Course.Category).Include(t => t.Topics);
            return View(classes.Where(x => x.Topics.Select(y => y.ApplicationUserId).Contains(userID)).ToList());
        }
    }
}
