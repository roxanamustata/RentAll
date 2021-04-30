using RentAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace RentAll.Domain
{
    public class Lease
    {
        #region properties

        public int Id { get; set; }
        public string LeaseNumber { get; set; }
        //public int LandlordId { get; set; }
        //public Company Landlord { get; set; }
        public int TenantId { get; set; }
        public Company Tenant { get; set; }
        public ICollection<Unit> Premises { get; set; }
        public int UserId { get; set; }
        public User LeasingManager { get; set; }
        public DateTime SigningDate { get; set; }
        public DateTime StartDate { get; set; }
        public int TermInMonths { get; set; }

        public DateTime EndDate { get; set; }

        public int CenterId { get; set; }

        public bool Valid { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        [NotMapped]
        public double TotalMonthlyRent
        {
            get
            {
                double total = 0;
                foreach (var unit in Premises)
                {
                    total += unit.Area * unit.MonthlyRentSqm;
                }
                return total;
            }
        }
        [NotMapped]
        public double TotalMonthlyMaintenanceCost
        {
            get
            {
                double total = 0;
                foreach (var unit in Premises)
                {
                    total += unit.Area * unit.MonthlyMaintenanceCostSqm;
                }
                return total;
            }
        }
        [NotMapped]
        public double TotalMarketingFee
        {
            get
            {
                double total = 0;
                foreach (var unit in Premises)
                {
                    total += unit.Area * unit.MonthlyMarketingFeeSqm;
                }
                return total;
            }
        }

        #endregion


        #region public methods

        #endregion


    }
}
