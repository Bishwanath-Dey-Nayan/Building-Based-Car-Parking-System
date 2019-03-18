using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarParkingSystem.Models
{
    public class RegisteredUser
    {
        [Key]
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public string UserType { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }


    }
}