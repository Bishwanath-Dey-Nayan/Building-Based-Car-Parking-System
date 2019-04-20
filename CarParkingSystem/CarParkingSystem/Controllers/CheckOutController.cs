using CarParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarParkingSystem.Controllers
{
    [Authorize]
    public class CheckOutController : Controller
    {
        string message = "";
        private CarParkingSystem.Models.DataBaseContext db = new Models.DataBaseContext();
        // GET: CheckOut
        public ActionResult CheckOut(int? id,int?SId,string UsrCode)
        {
            int CheckOut_CarId = 0;

            //Checking wheather the UserCode exists in RegisterUser list or
            //generalUser list and assigning the value to CheckOut_CarId
            #region
            var CheckOutUsr = db.RegisteredUsers.Where(t => t.UserCode == UsrCode).FirstOrDefault();
            if (CheckOutUsr != null)
            {
                CheckOut_CarId = CheckOutUsr.CarId;
            }
            else
            {
                var UserData = db.Users.Where(userdata => userdata.UCode == UsrCode).FirstOrDefault();
                CheckOut_CarId = UserData.CarId;
            }
            #endregion

            //deallocate the parking Space
            var del = db.parkingSpace.Where(t => t.Id == SId).FirstOrDefault();
            del.Status = true;
            db.SaveChanges();

            //saving the data to the Checkout model
            CheckOut c = new CheckOut()
            {
                CheckInId = Convert.ToInt32(id),
                UserCode = UsrCode,
                CarId = CheckOut_CarId,
                CheckOutTime = DateTime.Now
            };
            db.CheckOuts.Add(c);
            db.SaveChanges();
            //deleting the record form the checkin
            var delcheckin = db.CheckIns.Where(t => t.Id == id).FirstOrDefault();
            delcheckin.status = false;
            db.SaveChanges();

            //sending data to the Bill method using tempdata
            TempData["CheckOutId"] = c.Id;

            //Redirecting to the Bill action method
            //to generate the bill after the checkOut
            return RedirectToAction("Bill","CheckOut");
        }

        public ActionResult Bill()
        {
            int Bill_CarId = 0;
            double Bill = 0;
            int Discount;
            //initializing the CheckOutSearchData with TempData["CheckOutId"] for quering the CheckOut Table Value
            int CheckOutSearchData = Convert.ToInt32(TempData["CheckOutId"]);

            //Finding Out the Specific CheckOut
            var CheckOutData = db.CheckOuts.Where(checkout => checkout.Id == CheckOutSearchData).FirstOrDefault();
            DateTime CheckOutTime = CheckOutData.CheckOutTime;
            var UserSearchData = CheckOutData.UserCode;

            //Initializing CheckIn Id
            int CheckInSearchData = CheckOutData.CheckInId;

            //finding the CheckIn for the Current CheckOut
            var CheckInData = db.CheckIns.Where(checkin => checkin.Id == CheckInSearchData).FirstOrDefault();
            DateTime CheckInTime = CheckInData.CheckInTime;

            //Finding Out the total Parked Hour
            //and checking the condition of minimum time
            TimeSpan Span = CheckOutTime.Subtract(CheckInTime);
            double TotalHour = Span.TotalHours;
            if(TotalHour<1 && TotalHour>.8)
            {
                TotalHour = 1;
            }
            else if(TotalHour<.4 && TotalHour>0)
            {
                TotalHour = .5;
            }

            //checking wherther the user is registered or not
            var UserExists = db.RegisteredUsers.Where(registereduser => registereduser.UserCode == UserSearchData).FirstOrDefault();
            if(UserExists!=null)
            {
                Bill_CarId = UserExists.CarId;
                Discount = 10;
                int UserId = UserExists.Id;
                //if the user is regitered then we will provide him 10% discount
                Bill = (TotalHour * 50) - (((TotalHour * 50) * 10) / 100);

                //Updating the account of the Registered User
                if (!UpdateAccount(Bill, UserId))
                {
                    return View("Error");
                }

            }
            else
            {
                var GeneralUserExists = db.Users.Where(generaluser => generaluser.UCode == UserSearchData).FirstOrDefault();
                Bill_CarId = GeneralUserExists.CarId;
                Discount = 0;
                Bill = (TotalHour * 50);
            }

            //Save the Data to the Bill Table
            Bill bill = new Bill()
            {
                CheckInId = CheckInData.Id,
                CheckOutId = CheckOutData.Id,
                //User searchData holds the UserCode
                UserCode = UserSearchData,
                CarId = Bill_CarId,
                SpaceId = CheckInData.PSpaceId,
                TotalHour = TotalHour,
                Total = Bill,
                Discount=Discount

            };

            //Saving the data to the Bill table
            db.Bills.Add(bill);
            db.SaveChanges();

            //holding the billId to the tempdata
            TempData["BillId"] = bill.Id;

           

            return RedirectToAction("ShowBill" , "CheckOut"); 
        }

        public ActionResult ShowBill()
        {
            int BillId = Convert.ToInt32(TempData["BillId"]);

            //Fetch the Bill Info of the Specific BillId
            var bill = db.Bills.Where(bills => bills.Id == BillId).FirstOrDefault();

            return View(bill);
        }

        //Updating the account of the Registered User
        [NonAction]
        public bool UpdateAccount(double bill, int UserId)
        {

            var accountlist = db.Accounts.Where(accounts => accounts.RUId == UserId).ToList();
            var account = accountlist.Last();
            double BalanceAmount = account.Balance - bill;

            //Saving the data to the account table
            if (bill < account.Balance)
            {
                Account accountentry = new Account()
                {
                    RUId = UserId,
                    DepositedAmount = account.DepositedAmount,
                    Cost = bill,
                    Balance = BalanceAmount,
                    DepositeTime=account.DepositeTime

                };
                db.Accounts.Add(accountentry);
                db.SaveChanges();
                return true;
            }
            else
            {
                message = "Recharge your account";
                return false;
            }

        }


    }
}