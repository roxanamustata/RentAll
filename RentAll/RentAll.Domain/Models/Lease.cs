using RentAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RentAll.Domain
{
    public class Lease
    {
        #region properties

        public int Id { get; set; }
        public Company Landlord { get; set; }
        public Company Tenant { get; set; }
        public List<Unit> Premises { get; set; }
        public User LeasingManager { get; set; }
        public DateTime SigningDate { get; set; }
        public DateTime StartDate { get; set; }
        public int TermInMonths { get; set; }

        public int CenterId { get; set; }

        public double TotalMonthlyRent { get
            {
                double total = 0;
                foreach(var unit in Premises)
                {
                    total += unit.Area * unit.MonthlyRentSqm;
                }
                return total;
            }
        }
        public double TotalMonthlyMaintenanceCost { get
            {
                double total = 0;
                foreach (var unit in Premises)
                {
                    total += unit.Area * unit.MonthlyMaintenanceCostSqm;
                }
                return total;
            }
        }
        public double TotalMarketingFee { get
            {
                double total = 0;
                foreach (var unit in Premises)
                {
                    total += unit.Area * unit.MonthlyMarketingFeeSqm;
                }
                return total;
            }
        }

        public bool Valid { get; set; }
        public Activity Activity { get; set; }

        #endregion


        #region public methods
        
        #endregion


    }
}
