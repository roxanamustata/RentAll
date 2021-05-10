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



        List<Unit> FindAllUnitsInCenter(int centerId);
        List<Unit> FindAllLeasedUnitsInCenter(int centerId);

        List<Unit> FindUnitsByLeaseId(int leaseId);
        List<Unit> FindAllUnitsInCenterOnFloor(int centerId, string floorName);
        List<Unit> FindAllLeasedUnitsInCenterOnFloor(int centerId, string floorName);
        List<Unit> FindAllLeasedRetailUnitsInCenterByActivity(int centerId, string activityName);
        List<Unit> FindAllLeasedRetailUnitsInCenterByActivityCategory(int centerId, string categoryName);
        Lease GetValidLeaseOnUnit(int unitId);
        List<Lease> GetValidLeasesOnCenter(int centerId);
        bool IsUnitLeased(int unitId);

        
        List<Lease> FindLeasesInCenterByActivity(int centerId, string activityName);
        List<Lease> FindLeasesInCenterByActivityCategory(int centerId, string activityRangeName);
        List<Lease> FindValidLeasesInCenter(int centerId);


    }
}
