using RentAll.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Domain.DTOs
{
    public class GetCenterDto
    {

        public int Id { get; set; }
        public string CenterName { get; set; }
        public string Owner { get; set; }
        public int ParkingCapacity { get; set; }

        public string Description { get; set; }
        public string Opening { get; set; }

    }
}
