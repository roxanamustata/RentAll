using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.DTOs
{
    public class UpdateUnitDto
    {

        public double Area { get; set; }
        public double MonthlyRentSqm { get; set; }
        public double MonthlyMaintenanceCostSqm { get; set; }
        public double MonthlyMarketingFeeSqm { get; set; }
    }
}
