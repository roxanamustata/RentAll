using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterService
    {
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
        double CalculateCostsPerLease(int leaseId);
        DateTime CalculateLeaseEndDate(int leaseId);
        double CalculateRentPerLease(int leaseId);
    }
}
