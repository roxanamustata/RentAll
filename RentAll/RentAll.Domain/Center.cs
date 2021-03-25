using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain
{
    public class Center
    {
        public int Id { get; }
        public string Name { get; set; }
        public Company Owner { get; set; }
        public List<Floor> Floors { get; set; }
        public int ParkingCapacity { get; set; }
        public List<Unit> Premises { get; set; }





    }
}
