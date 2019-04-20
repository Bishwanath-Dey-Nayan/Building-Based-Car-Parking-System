using CarParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarParkingSystem.Controllers
{

    public class HomeController : Controller
    {
        private DataBaseContext db = new DataBaseContext(); 

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Profile()
        {
            int UserId = Convert.ToInt32(Session["UserId"]);
            var PorfileData = db.RegisteredUsers.Where(ru => ru.Id == UserId).FirstOrDefault();
            return View(PorfileData);
        }
    }
}