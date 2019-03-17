using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarParkingSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UCode { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}