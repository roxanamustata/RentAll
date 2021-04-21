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

        public int Id { get; private set; }
        public Company Landlord { get; set; }
        public Company Tenant { get; set; }
        public List<Unit> Premises { get; set; }
        public User LeasingManager { get; set; }
        public DateTime SigningDate { get; set; }
        public DateTime StartDate { get; set; }
        public int TermInMonths { get; set; }
        
        //TODO each unit from Premises may have different rent and costs on sqm
        public double RentSqm { get; set; }
        public double MaintenanceCostSqm { get; set; }
        public double MarketingFeeSqm { get; set; }
        public bool Valid { get; set; }
        public Activity Activity { get; set; }

        #endregion


        #region public methods
        public double CalculateCostsPerLease()
        {

            double TotalCosts = 0;
            foreach (Unit Unit in this.Premises)
            {
                TotalCosts += (this.RentSqm + this.MaintenanceCostSqm + this.MarketingFeeSqm) * Unit.Area;
            }
            return TotalCosts;
        }

        public DateTime CalculateLeaseEndDate()
        {
            TimeSpan duration = new TimeSpan(TermInMonths * 30, 0, 0, 0);
            DateTime endDate = StartDate.Add(duration);

            return endDate;
        }

        public double CalculateRentPerLease()
        {
            double totalRent = 0;
            Premises.ForEach(u => totalRent += u.Area * RentSqm);
            return totalRent;
        }


        public double getAreaByUnitType (UnitType unitType)
        {
            double totalAreaByUnitType = 0;
            foreach(var item in Premises)
            {
                if (item.Type==unitType)
                {
                    totalAreaByUnitType += item.Area;
                }
            }
            return totalAreaByUnitType;
        }
        #endregion


    }
}
