using RentAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Domain.Interfaces
{
   public interface IReportsService
    {

        double CalculateTotalCostsPerLease(int leaseId);
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

        Report GetCenterSummary(int centerId);

        IEnumerable<Report> GetCentersReports();

    }
}
