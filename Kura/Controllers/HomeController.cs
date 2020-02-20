using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Koora.Models;
using Koora.Models.MyModels;
namespace Koora.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public HomeController()
        {
            db = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var events = db.Events.OrderByDescending(x => x.id).ToList();
            return View(events);
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult faq()
        {
            return View();
        }

        public ActionResult info()
        {
            return View();
        }

        [HttpPost]
        public void changeTheme(string link)
        {
            Session["Theme"] = link; 
        }
    }
}