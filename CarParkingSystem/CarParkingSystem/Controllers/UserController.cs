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
                    }
                    else
                    {
                        return View(user);
                    }

                #endregion

                #region
                    //Hashing Password

                #endregion


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
    }
}