using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarParkingSystem.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public int RUserId { get; set; }
        public DateTime DepositeTime { get; set; }
        public double DepositedAmount { get; set; }
        public double Balance { get; set; }
    }
}