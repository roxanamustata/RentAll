using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.DTOs
{
    public class UpdateCenterDto
    {

        public string CenterName { get; set; }
        public int CompanyId { get; set; }
        public int ParkingCapacity { get; set; }
    }
}
