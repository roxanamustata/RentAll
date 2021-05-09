using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterRepository
    {
        Center FindCenterById(int centerId);
        List<Center> GetAllCenters();

        List<Unit> FindAllUnitsInCenter(int centerId);
        List<Unit> FindAllLeasedUnitsInCenter(int centerId);

        Unit FindUnitById(int unitId);
        List<Unit> FindUnitsByLeaseId(int leaseId);
        List<Unit> FindAllUnitsInCenterOnFloor(int centerId, string floorName);
        List<Unit> FindAllLeasedUnitsInCenterOnFloor(int centerId, string floorName);
        List<Unit> FindAllLeasedRetailUnitsInCenterByActivity(int centerId, string activityName);
        List<Unit> FindAllLeasedRetailUnitsInCenterByActivityCategory(int centerId, string categoryName);
        Lease GetValidLeaseOnUnit(int unitId);
        List<Lease> GetValidLeasesOnCenter(int centerId);
        bool IsUnitLeased(int unitId);
        Unit FindUnitInCenterByCode(int centerId, string unitCode);

        Lease FindLeaseById(int leaseId);
        
        List<Lease> FindLeasesInCenterByActivity(int centerId, string activityName);
        List<Lease> FindLeasesInCenterByActivityCategory(int centerId, string activityRangeName);
        List<Lease> FindValidLeasesInCenter(int centerId);


    }
}
