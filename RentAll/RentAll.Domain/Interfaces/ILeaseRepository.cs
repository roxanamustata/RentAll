using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Interfaces
{
    public interface ILeaseRepository
    {
        public Lease FindLeaseById(int leaseId);


        public double CalculateCostsPerLease(int leaseId);

        public DateTime CalculateLeaseEndDate(int leaseId);

        public double CalculateRentPerLease(int leaseId);

        public double GetAreaByUnitType(Lease lease, UnitType unitType);
    }
}
