using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarParkingSystem.Models.ViewModel
{
    public class CheckInVM
    {

        public DateTime CheckInTime { get; set; }
        public string UserCode { get; set; }
        public int CarId { get; set; }

    }
}