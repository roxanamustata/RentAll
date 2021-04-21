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
        
        //TODO each unit from Premises may have different rent and costs on sqm
        public double RentSqm { get; set; }
        public double MaintenanceCostSqm { get; set; }
        public double MarketingFeeSqm { get; set; }
        public bool Valid { get; set; }
        public Activity Activity { get; set; }

        #endregion


        #region public methods
        
        #endregion


    }
}
