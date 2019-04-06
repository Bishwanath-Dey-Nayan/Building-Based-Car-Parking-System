using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarParkingSystem.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult Report()
        {
            return View();
        }
        public ActionResult IncomeReport()
        {
            return View();
        }
    }
}