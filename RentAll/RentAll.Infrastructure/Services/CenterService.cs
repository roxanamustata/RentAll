using RentAll.Domain;
using RentAll.Domain.Interfaces;

using RentAll.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentAll.Infrastructure.Services
{
    public class CenterService : ICenterService
    {
        #region fields
        private CenterRepository _centerRepository;
        #endregion

        #region constructors
        public CenterService(CenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }
        #endregion

        #region public methods
        public double CalculateGrossLeasableAreaOnCenter(int centerId)
        {
            return _centerRepository.FindAllUnitsInCenter(centerId)
                    .Sum(u => u.Area);

        }

        public double CalculateLeasedAreaOnCenter(int centerId)
        {
            return _centerRepository.FindAllLeasedUnitsInCenter(centerId)
                    .Sum(u => u.Area);

        }

        public double CalculateOcupancyDegreeOnCenter(int centerId)
        {
            return Math.Round(CalculateLeasedAreaOnCenter(centerId)
                / CalculateGrossLeasableAreaOnCenter(centerId) * 100, 2);
        }

        public double CalculateGrossLeasableAreaInCenterOnFloor(int centerId, string floorName)
        {
            return _centerRepository.FindAllUnitsInCenterOnFloor(centerId, floorName)
                    .Sum(u => u.Area);
        }

        public double CalculateLeasedAreaInCenterOnFloor(int centerId, string floorName)
        {
            return _centerRepository.FindAllLeasedUnitsInCenterOnFloor(centerId, floorName)
                    .Sum(u => u.Area);
        }


        public double CalculateOcupancyDegreeInCenterOnFloor(int centerId, string floorName)
        {
            return Math.Round(CalculateLeasedAreaInCenterOnFloor(centerId, floorName)
                / CalculateGrossLeasableAreaInCenterOnFloor(centerId, floorName) * 100, 2);
        }

        public double CalculateTotalRentOnCenter(int centerId)
        {
            return _centerRepository.FindAllLeasedUnitsInCenter(centerId)
                       .Sum(u => u.Area * u.MonthlyRentSqm);

        }

        public double CalculateAverageRentPerSqmOnCenter(int centerId)
        {
            return Math.Round(CalculateTotalRentOnCenter(centerId)
                / CalculateLeasedAreaOnCenter(centerId), 2);
        }

        public double CalculateLeasedAreaInCenterOnActivity(int centerId, string activityName)
        {

            return _centerRepository.FindAllLeasedRetailUnitsInCenterByActivity(centerId, activityName)
                     .Sum(u => u.Area);
        }

        public double CalculateTotalRentInCenterOnActivity(int centerId, string activityName)
        {

            return _centerRepository.FindAllLeasedRetailUnitsInCenterByActivity(centerId, activityName)
                    .Sum(u => u.Area * u.MonthlyRentSqm);
        }

        public double CalculateAverageRentPerSqmInCenterOnActivity(int centerId, string activityName)
        {
            return Math.Round(CalculateTotalRentInCenterOnActivity(centerId, activityName)
                              / CalculateLeasedAreaInCenterOnActivity(centerId, activityName), 2);
        }

        public double CalculateLeasedAreaInCenterOnActivityCategory(int centerId, string categoryName)
        {
            return _centerRepository.FindAllLeasedRetailUnitsInCenterByActivityCategory(centerId, categoryName)
                    .Sum(u => u.Area);
        }
        public double CalculateTotalRentInCenterOnActivityCategory(int centerId, string categoryName)
        {
            return _centerRepository.FindAllLeasedRetailUnitsInCenterByActivityCategory(centerId, categoryName)
                    .Sum(u => u.Area * u.MonthlyRentSqm);
        }
        public double CalculateAverageRentPerSqmInCenterOnActivityCategory(int centerId, string categoryName)
        {
            return Math.Round(CalculateTotalRentInCenterOnActivityCategory(centerId, categoryName)
                              / CalculateLeasedAreaInCenterOnActivityCategory(centerId, categoryName), 2);
        }



        public double CalculateTotalCostsPerLease(int leaseId)
        {
            return _centerRepository.FindUnitsByLeaseId(leaseId)
                    .Sum(u => u.Area * (u.MonthlyRentSqm + u.MonthlyMaintenanceCostSqm + u.MonthlyMarketingFeeSqm));


        }

        #endregion
    }
}
