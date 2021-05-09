using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterService
    {
        double CalculateGrossLeasableAreaOnCenter(int centerId);
        double CalculateLeasedAreaOnCenter(int centerId);
        double CalculateOcupancyDegreeOnCenter(int centerId);
        double CalculateGrossLeasableAreaInCenterOnFloor(int centerId, string floorName);
        double CalculateLeasedAreaInCenterOnFloor(int centerId, string floorName);
        double CalculateOcupancyDegreeInCenterOnFloor(int centerId, string floorName);
        double CalculateTotalRentOnCenter(int centerId);
        double CalculateAverageRentPerSqmOnCenter(int centerId);
        double CalculateLeasedAreaInCenterOnActivity(int centerId, string activityName);
        double CalculateTotalRentInCenterOnActivity(int centerId, string activityName);
        double CalculateAverageRentPerSqmInCenterOnActivity(int centerId, string activityName);
        double CalculateLeasedAreaInCenterOnActivityCategory(int centerId, string categoryName);
        double CalculateTotalRentInCenterOnActivityCategory(int centerId, string categoryName);
        double CalculateAverageRentPerSqmInCenterOnActivityCategory(int centerId, string categoryName);
        double CalculateTotalCostsPerLease(int leaseId);
        
    }
}
