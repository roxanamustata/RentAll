using RentAll.Domain;
using RentAll.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentAll.Web.DTOs
{
    public class GetUnitDto
    {

        public int Id { get; set; }
        public string UnitCode { get; set; }
        public double Area { get; set; }
        public string Type { get; set; }
        public string Center { get; set; }
        public string Floor { get; set; }
        public double MonthlyRentSqm { get; set; }
        public double MonthlyMaintenanceCostSqm { get; set; }
        public double MonthlyMarketingFeeSqm { get; set; }

        public ICollection<GetLeaseDto> Leases { get; set; }
       
        public GetLeaseDto ValidLease { get; set; }


    }
}
