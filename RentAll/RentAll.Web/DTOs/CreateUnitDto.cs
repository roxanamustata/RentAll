using RentAll.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.DTOs
{
    public class CreateUnitDto
    {
       
        public string UnitCode { get; set; }
        public double Area { get; set; }
        public int Type { get; set; }

        public int FloorId { get; set; }

        public int CenterId { get; set; }

        public double MonthlyRentSqm { get; set; }
        public double MonthlyMaintenanceCostSqm { get; set; }
        public double MonthlyMarketingFeeSqm { get; set; }
    }
}
