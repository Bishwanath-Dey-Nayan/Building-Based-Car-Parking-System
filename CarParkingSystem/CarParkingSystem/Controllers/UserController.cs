using CarParkingSystem.Models;
using CarParkingSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarParkingSystem.Controllers
{
    public class UserController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        // GET: Registration
        public ActionResult Registration()
        {
            return View();
        }


        //Post:Registration
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Registration(RegistrationVM user)
        {

            bool status=false;
            string message="";
            //validate Antiforgery token
            if(ModelState.IsValid)
            {
                    #region //Check Wheater the Email Exists or not
                    var isExists = IsEmailExists(user.Email);
                    if (isExists)
                    {
                        ModelState.AddModelError("EmailExits","Email already Exists");
                        return View(user);
                    }
          

                #endregion

                #region
                //Hashing Password
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassWord = Crypto.Hash(user.ConfirmPassWord);
                #endregion

                
                

                

                using(DataBaseContext db=new DataBaseContext())
                {

                    
                    Car c = new Car()
                    {
                        CarNo=user.CarNo,
                        CarName=user.CarName,
                        LicenseNo=user.LicenseNo
                    };
                    db.Cars.Add(c);
                    db.SaveChanges();

                    RegisteredUser ru = new RegisteredUser() {
                    
                        Name=user.Name,
                        Contact=user.Contact,
                        DOB=user.DOB,
                        Address=user.Address,
                        Email=user.Email,
                        RegistrationDate=DateTime.Now.Date,
                        UserType="U",
                        Password=user.Password,
                        CarId=c.Id,
                        
                     
                    };
                    db.RegisteredUsers.Add(ru);
                    db.SaveChanges();

                    Account ac = new Account() {
                        RUId = ru.Id,
                        DepositeTime = DateTime.Now.Date,
                        DepositedAmount=user.Deposite

                    };
                    db.Accounts.Add(ac);
                    db.SaveChanges();

                }


            }
            else
            {
                message = "Invalid Request";
            }

           

            //
            return View(user);
        }


        //method for checking Email Exists or not
        [NonAction]
        public bool IsEmailExists( string EmailId)
        {
            using (DataBaseContext dc = new DataBaseContext())
            {
                var v = dc.RegisteredUsers.Where(u => u.Email == EmailId).FirstOrDefault();
                return v != null;//v==null?false:true;
            }
                

        }


        //method for creating usercode in a specific pattern
        [NonAction]
        public string usercode()
        {
            string code="";
            var lastUser = db.RegisteredUsers.OrderByDescending(s => s.Id).FirstOrDefault();
            if(lastUser==null)
            {
               code = "RU001";
            }
            else
            {
                code = "RU0"+((Convert.ToInt32(lastUser.Id))+1).ToString();
            }
            return code;
        }
    }
}