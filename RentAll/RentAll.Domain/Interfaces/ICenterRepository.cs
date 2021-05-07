using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterRepository
    {
        IList<Center> FindAll();

        Center FindByName(string productName);

        bool Save(Center center);
        Center FindCenterById(int centerId);
        Unit FindUnitById(int unitId);
        Lease GetValidLease(Unit unit);
        bool IsLeased(int unitId);
        Unit FindUnitInCenterByCode(int centerId, string unitCode);
        void AddLeaseToUnitInCenter(int centerId, Unit unit, Lease lease);
        Lease FindLeaseById(int leaseId);
        List<Lease> FindLeasesByActivity(int centerId, string activityName);
        List<Lease> FindLeasesByActivityRange(int centerId, string activityRangeName);
        List<Lease> FindValidLeasesInCenter(int centerId);
        (double, double) GetLeaseAreaAndRentByUnitType(Lease lease, UnitType unitType);

    }
}
