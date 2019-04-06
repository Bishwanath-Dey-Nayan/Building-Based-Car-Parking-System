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
            string CheckIn_UserCode = "";
            int CheckIn_CarId = 0;

            if (TempData["RUid"] != null)
            {
                int a = (int)TempData["RUid"];

                //intantiating an object of RegisteredUser Class
                var RegisteredUser = db.RegisteredUsers.Where(r => r.Id == a).FirstOrDefault();
                CheckIn_UserCode = RegisteredUser.UserCode;
                CheckIn_CarId = RegisteredUser.CarId;
            }
            else
            {
                int GeneralUserId = Convert.ToInt32(TempData["GuId"]);

                var GeneralUser = db.Users.Where(generaluser => generaluser.Id == GeneralUserId).FirstOrDefault();

                CheckIn_UserCode = GeneralUser.UCode;
                CheckIn_CarId = GeneralUser.CarId;
            }


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
                    PSpaceId = ParkingSpace.Id,
                    UserCode = CheckIn_UserCode,
                    CarId = CheckIn_CarId,
                    TokenNo = Token,
                    status = true

                };

                db.CheckIns.Add(ci);
                db.SaveChanges();


                ViewBag.Token = Token;
                return View();
       
        }

        //action for showing the current checkin user
        public ActionResult Index(string Token)
        {
            var CheckInList = db.CheckIns.Where(checkin => checkin.TokenNo == Token || Token == " ");
            return View(CheckInList.ToList());
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