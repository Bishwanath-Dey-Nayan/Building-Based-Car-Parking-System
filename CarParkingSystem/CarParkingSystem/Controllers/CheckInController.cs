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
            //creating a list of parking space for allocation
            #region
            List<ParkingSpaceList> ps = new List<ParkingSpaceList>();
            ps.Add(new ParkingSpaceList { Id = 1, Name = "A1", Status = true });
            ps.Add(new ParkingSpaceList { Id = 2, Name = "A2", Status = true });
            ps.Add(new ParkingSpaceList { Id = 3, Name = "A3", Status = true });
            ps.Add(new ParkingSpaceList { Id = 4, Name = "A4", Status = true });
            ps.Add(new ParkingSpaceList { Id = 5, Name = "A5", Status = true });
            ps.Add(new ParkingSpaceList { Id = 6, Name = "B1", Status = false });
            ps.Add(new ParkingSpaceList { Id = 7, Name = "B2", Status = false });
            ps.Add(new ParkingSpaceList { Id = 8, Name = "B3", Status = true });
            ps.Add(new ParkingSpaceList { Id = 9, Name = "B4", Status = true });
            ps.Add(new ParkingSpaceList { Id = 10, Name = "B5", Status = true });
            ps.Add(new ParkingSpaceList { Id = 11, Name = "C1", Status = true });
            ps.Add(new ParkingSpaceList { Id = 12, Name = "C2", Status = true });
            ps.Add(new ParkingSpaceList { Id = 13, Name = "C3", Status = true });
            ps.Add(new ParkingSpaceList { Id = 14, Name = "C4", Status = true });
            ps.Add(new ParkingSpaceList { Id = 14, Name = "C5", Status = true });

            #endregion

            //storing the Registered UserId into a tempdata for passing it to to CheckInFinal Action
            TempData["RUid"] = RUid;

            TempData["list"] = ps;

            //returning the list to the view
            return View(ps);
        }

        public ActionResult CheckInFinal(int? SId)
        {
            int a= (int)TempData["RUid"];

            //intantiating an object of RegisteredUser Class
            var RegisteredUser = db.RegisteredUsers.Where(r => r.Id == a).FirstOrDefault();

            var ParkingSpace = TempData["list"] as List<ParkingSpaceList>;

            //finding out the selected space of the car
            var SelectedSpace = ParkingSpace.Where(t => t.Id==SId).FirstOrDefault();

            //changing the status of the space
            SelectedSpace.Status =false;
            

            //generate token
            string Token = GetToken();

            //save data to the check in table
            CheckIn ci = new CheckIn()
            {
                CheckInTime = DateTime.Now,
                PSpaceId=SelectedSpace.Id,
                UserCode=RegisteredUser.UserCode,
                CarId=RegisteredUser.CarId,
                TokenNo=Token
                
            };


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