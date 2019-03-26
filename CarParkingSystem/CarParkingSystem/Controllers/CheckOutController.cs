using CarParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarParkingSystem.Controllers
{
    public class CheckOutController : Controller
    {
        private CarParkingSystem.Models.DataBaseContext db = new Models.DataBaseContext();
        // GET: CheckOut
        public ActionResult CheckOut(int? id,int?SId,string UsrCode)
        {


            var CheckOutUsr = db.RegisteredUsers.Where(t => t.UserCode == UsrCode).FirstOrDefault();
            var carid = CheckOutUsr.CarId;
            //deallocate the parking Space
            var del = db.parkingSpace.Where(t => t.Id == SId).FirstOrDefault();
            del.Status = true;
            db.SaveChanges();

            CheckOut c = new CheckOut()
            {
                CheckInId = Convert.ToInt32(id),
                UserCode = UsrCode,
                CarId = carid,
                CheckOutTime = DateTime.Now
            };
            db.CheckOuts.Add(c);
            db.SaveChanges();
            
            return View();
        }
    }
}