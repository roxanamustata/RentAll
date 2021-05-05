using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterRepository
    {
        Center FindCenterById(int centerId);
        Unit FindUnitById(int unitId);
        Lease GetValidLease(Unit unit);
        bool IsLeased(int unitId);
        Unit FindUnitInCenterByCode(int centerId, string unitCode);
        void AddLeaseToUnitInCenter(int centerId, Unit unit, Lease lease);
        Lease FindLeaseById(int leaseId);
        List<Lease> FindLeasesByActivity(int centerId, string activityName);
        List<Lease> FindLeasesByActivityRange(int centerId, string activityRangeName);
        ICollection<Lease> FindValidLeasesInCenter(int centerId);
       

    }
}
