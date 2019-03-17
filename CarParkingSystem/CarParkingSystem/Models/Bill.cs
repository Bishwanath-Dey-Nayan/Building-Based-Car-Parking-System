using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarParkingSystem.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public int CheckInId { get; set; }
        public int CheckOutId { get; set; }
        public string UserCode { get; set; }
        public int CarId { get; set; }
        public int SpaceId { get; set; }
        public int Discount { get; set; }
        public double TotalHour { get; set; }
        public double Total { get; set; }
    }
}