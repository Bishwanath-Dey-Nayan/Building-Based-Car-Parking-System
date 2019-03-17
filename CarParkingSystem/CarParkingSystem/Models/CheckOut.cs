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
        public virtual CheckIn CheckIn { get; set; }

        public DateTime CheckOutTime { get; set; }
        public string UserCode { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
        
        
    }
}