using RentAll.Domain;
using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Infrastructure.Repositories
{
    public class LeaseRepository : ILeaseRepository
    {
        #region fields
        private List<Lease> leases = new List<Lease>();
        #endregion


        #region constructors
        public LeaseRepository()
        {
            leases.Add(DomainModelFactory.GetLease(1, 1, new int[] { 200, 50 }));
            leases.Add(DomainModelFactory.GetLease(2, 2, new int[] { 150, 500 }));
            leases.Add(DomainModelFactory.GetLease(3, 3, new int[] { 10, 5000 }));
        }
        #endregion



        #region public methods

        public Lease FindLeaseById(int leaseId)
        {
            Lease lease = null;
            foreach (var item in leases)
            {
                if (item.Id == leaseId)
                {
                    lease = item;
                }

            }
            if (lease == null)
            {
                throw new InvalidOperationException($"Center with id {leaseId} not found");

            }
            return lease;
        }

        public List<Lease> FindValidLeasesInCenter(int centerId)
        {
            var foundLeases = new List<Lease>();

            foreach (var item in leases)
            {
                if (item.CenterId == centerId)
                {
                    if (item.Valid == true)
                    {
                        foundLeases.Add(item);
                    }
                }

            }
            if (foundLeases == null)
            {
                throw new InvalidOperationException($"No valid leases were found for center with id {centerId}");

            }
            return leases;
        }




        public double CalculateCostsPerLease(int leaseId)
        {
            Lease lease = FindLeaseById(leaseId);
            double TotalCosts = 0;
            foreach (Unit Unit in lease.Premises)
            {
                TotalCosts += (lease.RentSqm + lease.MaintenanceCostSqm + lease.MarketingFeeSqm) * Unit.Area;
            }
            return TotalCosts;
        }

        public DateTime CalculateLeaseEndDate(int leaseId)
        {
            Lease lease = FindLeaseById(leaseId);
            TimeSpan duration = new TimeSpan(lease.TermInMonths * 30, 0, 0, 0);
            DateTime endDate = lease.StartDate.Add(duration);

            return endDate;
        }

        public double CalculateRentPerLease(int leaseId)
        {
            Lease lease = FindLeaseById(leaseId);
            double totalRent = 0;
            lease.Premises.ForEach(u => totalRent += u.Area * lease.RentSqm);
            return totalRent;
        }



        public double GetAreaByUnitType(Lease lease, UnitType unitType)
        {

            double totalAreaByUnitType = 0;
            foreach (var item in lease.Premises)
            {
                if (item.Type == unitType)
                {
                    totalAreaByUnitType += item.Area;
                }
            }
            return totalAreaByUnitType;
        }
        #endregion
    }
}
