using CarParkingSystem.Models;
using CarParkingSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarParkingSystem.Controllers
{
    public class CheckInController : Controller
    {
        private DataBaseContext db=new DataBaseContext();
        // GET: CheckIn

        public ActionResult CheckIn(int? RUid)
        {

            var ps = db.parkingSpace.ToList();
            //storing the Registered UserId into a tempdata for passing it to to CheckInFinal Action
            TempData["RUid"] = RUid;


            //returning the list to the view
            return View(ps);
        }

        public ActionResult CheckInFinal(int? SId)
        {
            int a= (int)TempData["RUid"];

            //intantiating an object of RegisteredUser Class
            var RegisteredUser = db.RegisteredUsers.Where(r => r.Id == a).FirstOrDefault();

            //finding out the selected parking space and changing the status of the space all allocated(False)
            var ParkingSpace = db.parkingSpace.Where(t => t.Id == SId).FirstOrDefault();
            ParkingSpace.Status = false;
            db.SaveChanges();
            

            //generate token
            string Token = GetToken();

            //save data to the check in table
            CheckIn ci = new CheckIn()
            {
                CheckInTime = DateTime.Now,
                PSpaceId=ParkingSpace.Id,
                UserCode=RegisteredUser.UserCode,
                CarId=RegisteredUser.CarId,
                TokenNo=Token
                
            };
            db.CheckIns.Add(ci);
            db.SaveChanges();


            ViewBag.Token = Token;
            return View();
        }


        //generation Random OTP for the Car CheckIn
        public string GetToken()
        {
            string num = "0123456789";
            int len = num.Length;
            string OTP = string.Empty;

            int otpdigit = 4;
            string FinalOTP;
            int getIndex;

           for(int i=0;i<otpdigit;i++)
            {
                do
                {
                    getIndex = new Random().Next(0, len);
                    FinalOTP = num.ToCharArray()[getIndex].ToString();
                }
                while (OTP.IndexOf(FinalOTP) != -1);
                OTP = OTP + FinalOTP;
            }
            return OTP;
        }
    }
}