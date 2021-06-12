
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentAll.Domain
{
    public class Unit
    {
        public Unit()
        {
            Leases = new List<Lease>();
        }


        #region properties

        public int Id { get; set; }
        public string UnitCode { get; set; }
        public double Area { get; set; }
        public UnitType Type { get; set; }

        public int CenterId { get; set; }
        public Center Center { get; set; }
        
        public int FloorId { get; set; }
        public Floor Floor { get; set; }

        public double MonthlyRentSqm { get; set; }
        public double MonthlyMaintenanceCostSqm { get; set; }
        public double MonthlyMarketingFeeSqm { get; set; }
        public ICollection<Lease> Leases { get; set; }
        
        
        [NotMapped]
       public Lease ValidLease { get; set; }

        //public override string ToString()
        //{
        //    return $"{UnitCode}, {Area}" ;
        //}

        #endregion



    }
}
