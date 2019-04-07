using CarParkingSystem.Models;
using System.Web.Mvc;


namespace CarParkingSystem.Controllers
{
   
    public class ReportController : Controller
    {
        public ActionResult Report(string SearchBy , int Select)
        {
            int month = Select;

            if(SearchBy == "Income")
            {
                
            }
            return View();
        }

        public ActionResult IncomeReport(int month)
        {
               
            return View();
        }
    }
}