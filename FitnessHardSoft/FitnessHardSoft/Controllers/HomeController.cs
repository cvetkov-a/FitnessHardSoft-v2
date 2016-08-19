using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FitnessHardSoft.Models;

namespace FitnessHardSoft.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET POSTS
        public ActionResult Index()
        {
            wholeInfo allInfo = new wholeInfo();
            allInfo.Posts = db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(6).ToList();
            allInfo.Trainers = db.Users.Where(p => p.IsTrainer==true).OrderByDescending(p => p.Id).Take(4).ToList();
            return View(allInfo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Trainers()
        {
            ViewBag.Message = "Your trainer page.";

            return View();
        }
    }
}