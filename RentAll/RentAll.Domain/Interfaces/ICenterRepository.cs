using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterRepository
    {
        #region center methods
        Center FindCenterById(int centerId);

        Unit FindUnitInCenterByCode(int centerId, string unitCode);

        void AddLeaseToUnitInCenter(int centerId, Unit unit, Lease lease);

        double CalculateGrossLeasableAreaPerCenter(int centerId);

        double CalculateLeasedAreaPerCenter(int centerId);

        double CalculateGrossLeasableAreaPerFloor(int centerId, string floorName);

        double CalculateLeasedAreaPerFloor(int centerId, string floorName);

        double CalculateOcupancyDegreePerCenter(int centerId);

        double CalculateOcupancyDegreePerFloor(int centerId, string floorName);

        double CalculateAverageRentPerSQMPerCenter(int centerId);

        (double, double) CalculateLeasedAreaAndTotalRentPerActivity(int centerId, string activityName);
        (double, double) CalculateLeasedAreaAndTotalRentPerActivityRange(int centerId, string activityRangeName);
        double CalculateAverageRentPerSQMPerActivity(int centerId, string activityName);
        double CalculateAverageRentPerSQMPerActivityRange(int centerId, string activityRangeName);

        List<Lease> FindLeasesByActivity(int centerId, string activityName);
        List<Lease> FindLeasesByActivityRange(int centerId, string activityRangeName);

        #endregion

        #region unit methods
        Unit FindUnitById(int unitId);
        Lease GetValidLease(Unit unit);
        bool IsLeased(Unit unit);

        #endregion



        #region lease methods
        Lease FindLeaseById(int leaseId);
        List<Lease> FindValidLeasesInCenter(int centerId);
        double CalculateCostsPerLease(int leaseId);
        DateTime CalculateLeaseEndDate(int leaseId);
        double CalculateRentPerLease(int leaseId);
        (double, double) GetLeaseAreaAndRentByUnitType(Lease lease, UnitType unitType);

        #endregion



    }
}
