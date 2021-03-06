using RentAll.Domain.Interfaces;
using RentAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Infrastructure.Services
{
    public class ReportsService : IReportsService

    {

        #region fields
        private ICenterRepository _centerRepository;
        #endregion

        #region constructors
        public ReportsService(ICenterRepository centerRepository)
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
            var leasedArea = CalculateLeasedAreaOnCenter(centerId);
            var grossArea = CalculateGrossLeasableAreaOnCenter(centerId);
            return Math.Round(leasedArea / grossArea * 100, 2);
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


        public Report GetCenterSummary(int centerId)
        {
            var centerReport = new Report
            {
                CenterId = centerId,
                CenterName = _centerRepository.GetCenterByIdAsync(centerId).Result.CenterName,
                LeasableArea = CalculateGrossLeasableAreaOnCenter(centerId),
                LeasedArea = CalculateLeasedAreaOnCenter(centerId),
                OccupancyDegree = CalculateOcupancyDegreeOnCenter(centerId),
                AverageRent = CalculateAverageRentPerSqmOnCenter(centerId),
                TotalRentIncome = CalculateTotalRentOnCenter(centerId),

                AverageRentOnNonFood = CalculateAverageRentPerSqmInCenterOnActivityCategory(centerId, "Non Food"),
                AverageRentOnFood = CalculateAverageRentPerSqmInCenterOnActivityCategory(centerId, "Food"),
                AverageRentEntertainment = CalculateAverageRentPerSqmInCenterOnActivityCategory(centerId, "Entertainment"),
                AverageRentOnServices = CalculateAverageRentPerSqmInCenterOnActivityCategory(centerId, "Services"),

                TotalRentIncomeOnNonFood = CalculateTotalRentInCenterOnActivityCategory(centerId, "Non Food"),
                TotalRentIncomeOnFood = CalculateTotalRentInCenterOnActivityCategory(centerId, "Food"),
                TotalRentIncomeOnEntertainment = CalculateTotalRentInCenterOnActivityCategory(centerId, "Entertainment"),
                TotalRentIncomeOnServices = CalculateTotalRentInCenterOnActivityCategory(centerId, "Services"),


            };
            return centerReport;

        }

        public IEnumerable<Report> GetCentersReports()
        {
            var centers = _centerRepository.GetCentersAsync().Result;
            var centersReport = new List<Report>();

            foreach (var center in centers)
            {
                var report = GetCenterSummary(center.Id);
                centersReport.Add(report);
            }

            return centersReport;
        }






        #endregion
    }
}
