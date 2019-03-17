using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarParkingSystem.Models
{
    public class CheckIn
    {
        [Key]
        public int Id { get; set; }
        public DateTime CheckInTime { get; set; }
        public int PSpaceId { get; set; }
        public string TokenNo { get; set; }
        public string UserCode { get; set; }
        public int CarId { get; set; }
    }
}