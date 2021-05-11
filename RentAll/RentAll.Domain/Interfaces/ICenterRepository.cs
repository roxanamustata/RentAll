using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterRepository
    {
        void Save();

        List<Center> GetCenters();
        Center GetCenterById(int centerId);
        void InsertCenter(Center center);
        void DeleteCenter(int centerId);
        void UpdateCenter(Center center);


        Unit GetUnitById(int unitId);
        Unit GetUnitFromCenterByUnitCode(int centerId, string unitCode);
        void InsertUnit(Unit unit);
        void DeleteUnit(int unitId);
        void UpdateUnit(Unit unit);


        Lease GetLeaseById(int leaseId);
        void InsertLease(Lease lease);
        void DeleteLease(int leaseId);
        void UpdateLease(Lease lease);



        IEnumerable<Unit> FindAllUnitsInCenter(int centerId);
        IEnumerable<Unit> FindAllLeasedUnitsInCenter(int centerId);
        IEnumerable<Unit> FindUnitsByLeaseId(int leaseId);
        IEnumerable<Unit> FindAllUnitsInCenterOnFloor(int centerId, string floorName);
        IEnumerable<Unit> FindAllLeasedUnitsInCenterOnFloor(int centerId, string floorName);
        IEnumerable<Unit> FindAllLeasedRetailUnitsInCenterByActivity(int centerId, string activityName);
        IEnumerable<Unit> FindAllLeasedRetailUnitsInCenterByActivityCategory(int centerId, string categoryName);
        IEnumerable<Lease> GetValidLeasesOnCenter(int centerId);
        IEnumerable<Lease> FindLeasesInCenterByActivity(int centerId, string activityName);
        IEnumerable<Lease> FindLeasesInCenterByActivityCategory(int centerId, string activityRangeName);
        IEnumerable<Lease> FindValidLeasesInCenter(int centerId);

        bool IsUnitLeased(int unitId);
        Lease GetValidLeaseOnUnit(int unitId);
    }
}
