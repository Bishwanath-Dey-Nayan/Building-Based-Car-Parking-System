using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CarParkingSystem.Models
{
    public class CheckOut
    {
        [Key]
        public int Id { get; set; }
        public int CheckInId { get; set; }
        public DateTime CheckOutTime { get; set; }
        public string UserCode { get; set; }
        public int CarId { get; set; }
        
    }
}