using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterRepository
    {
        Center FindCenterById(int centerId);

        Unit FindUnit(int centerId, string unitCode);

        void AddLeaseToPremises(int centerId, Unit unit, Lease lease);

        double CalculateGrossLeasableAreaPerCenter(int centerId);

        double CalculateLeasedAreaPerCenter(int centerId);

        double CalculateGrossLeasableAreaPerFloor(int centerId, string floorName);

        double CalculateLeasedAreaPerFloor(int centerId, string floorName);

        double CalculateOcupancyDegreePerCenter(int centerId);

        double CalculateOcupancyDegreePerFloor(int centerId, string floorName);

        double CalculateAverageRentPerSQMPerCenter(int centerId);
        List<Lease> FindLeasesByActivity(int centerId, string activityName);
        List<Lease> FindLeasesByActivityRange(int centerId, string activityRangeName);

        (double,double) CalculateLeasedAreaAndTotalRentPerActivity(int centerId, string activityName);
        (double, double) CalculateLeasedAreaAndTotalRentPerActivityRange(int centerId, string activityRangeName);
        double CalculateAverageRentPerSQMPerActivity(int centerId, string activityName);
        double CalculateAverageRentPerSQMPerActivityRange(int centerId, string activityRangeName);



    }
}
