using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarParkingSystem.Models
{
    public class ParkingSpace
    {
        [Key]
        public int Id { get; set; }
        public string PSName { get; set; }
        public string Floor { get; set; }
        public double Cost { get; set; }
        public bool Status { get; set; }


        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<CheckIn> Checkins { get; set; }

    }
}