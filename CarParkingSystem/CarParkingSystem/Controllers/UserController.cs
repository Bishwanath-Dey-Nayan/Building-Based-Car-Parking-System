using CarParkingSystem.Models;
using CarParkingSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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




                string code = usercode();

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
                        UserCode=code
                        
                     
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

                    status = true;
                    message = "RegisTration Successfull";

                }


            }
            else
            {
                message = "Invalid Request";
            }



            ViewBag.Message = message;
            ViewBag.Status = status;
            return View(user);
        }

        //General User Registration Process
        //Get method
        public ActionResult GeneralUserRegistration()
        {
            return View();
        }

        //post Method
        [HttpPost]
        public ActionResult GeneralUserRegistration(GeneralUserVM gu)
        {
            if(ModelState.IsValid)
            {
                //saving the data to the Car table
                #region
                Car car = new Car()
                {
                    CarNo=gu.CarNo,
                    CarName=gu.CarName,
                    LicenseNo=gu.LicenseNo
                };
                db.Cars.Add(car);
                db.SaveChanges();
                #endregion

                string UserCode = GeneralUserCode();

                //saving the data to the User Table 
                //thats refers to the general user of the system
                #region

                User user = new User()
                {
                    Name = gu.Name,
                    Contact = gu.Contact,
                    UCode = UserCode,
                    Address = gu.Address,
                    CarId=car.Id 
                };
                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction();

                #endregion

            }
            return View();
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


        //method for creating GeneralUserCode
        public string GeneralUserCode()
        {
            string code = "";
            var lastUser = db.Users.OrderByDescending(s => s.Id).FirstOrDefault();
            if (lastUser == null)
            {
                code = "GU001";
            }
            else
            {
                code = "GU00" + ((Convert.ToInt32(lastUser.Id)) + 1).ToString();
            }
            return code;
        }


        //get method for login 
        public ActionResult Login()
        {
            return View();
        }

       //Post method for login
       [HttpPost]
        public ActionResult Login(LoginVM log,string ReturnUrl)
        {
            string message = "";
            if(ModelState.IsValid)
            {
                var l = db.RegisteredUsers.Where(t => t.Email == log.Email).FirstOrDefault();
                if(l!=null)
                {
                    if(string.Compare(Crypto.Hash(log.Password),l.Password)==0)
                    {
                        int timeout = log.Remember ? 525600 : 10;
                        var ticket = new FormsAuthenticationTicket(log.Email,log.Remember,timeout);
                        string enc = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, enc);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if(Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }

                    }
                    else
                    {
                        message = "Invalid Credentials.Check wheather the Id or password is correctly written.";

                    }
                }
                else
                {
                    message = "Invalid Credentials.Check wheather the Id or password is correctly written.";
                }
            }
            ViewBag.Message = message;
            return View(log);
        }

        //method for logout
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","User");
        }

        //method for showing the list of registered User
        public ActionResult Index1()
        {
            var list = db.RegisteredUsers.ToList();
            return View(list);
        }
    }
}