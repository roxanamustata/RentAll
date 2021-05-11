
using System.Collections.Generic;


namespace RentAll.Domain
{
    public class Unit
    {

        #region properties

        public int Id { get; set; }
        public string UnitCode { get; set; }
        public double Area { get; set; }
        public UnitType Type { get; set; }

        public int CenterId { get; set; }
        public Center Center { get; set; }
        public Floor Floor { get; set; }

        public double MonthlyRentSqm { get; set; }
        public double MonthlyMaintenanceCostSqm { get; set; }
        public double MonthlyMarketingFeeSqm { get; set; }
        public ICollection<Lease> Leases { get; set; }

        #endregion

        

    }
}
