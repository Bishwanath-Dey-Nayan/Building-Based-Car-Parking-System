using CarParkingSystem.Models;
using System.Linq;
using System.Web.Mvc;


namespace CarParkingSystem.Controllers
{
   
    public class ReportController : Controller
    {
        private DataBaseContext db = new DataBaseContext();

        public ActionResult Report()
        {
            return View();
        }

        public ActionResult ReportGenerate(string SearchBy , int Select)
        {
            int month = Select;

            if (SearchBy != "" && Select !=null)
            {
                //Income Report Generatation
                #region
                if (SearchBy == "Income")
                {
                    var IncomeReportList = db.Bills.Where(bill => bill.CheckOut.CheckOutTime.Month == month).ToList();
                    return View("IncomeReport", IncomeReportList);
                }
                #endregion

                else if (SearchBy == "Car")
                {
                    var CarReportList = db.CheckOuts.Where(checkout => checkout.CheckOutTime.Month == month);
                    return View("CarReportList", CarReportList.ToList());
                }
                
                else if(SearchBy == "User")
                {
                    var UserReportList = db.CheckOuts.Where(checkout => checkout.CheckOutTime.Month == month).ToList();
                    return View("UserReport", UserReportList);
                }
            }
            return View();
        }

    }
}