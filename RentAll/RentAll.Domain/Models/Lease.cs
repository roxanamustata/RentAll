using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain
{
    public class Lease
    {
        public int Id { get; }
        public Company Landlord { get; set; }
        public Company Tenant { get; set; }
        public List<Unit> Premises { get; set; }
        public User LeasingManager { get; set; }
        public DateTime SigningDate { get; set; }
        public DateTime StartDate { get; set; }
        public int Term { get; set; }
        public double RentSqm { get; set; }
        public double MaintenanceCostSqm { get; set; }
        public double MarketingFeeSqm { get; set; }
        public bool Valid { get; set; }
    }
}
