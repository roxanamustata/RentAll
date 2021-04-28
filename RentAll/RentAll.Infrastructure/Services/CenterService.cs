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
        private ICenterRepository _centerRepository;

        public CenterService(CenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }

        public ICenterRepository CenterRepository
        {
            get
            {
                return _centerRepository;
            }
        }

        #region public methods
        public double CalculateGrossLeasableAreaPerCenter(int centerId)
        {
            var center = CenterRepository.FindCenterById(centerId);
            double GrossLeasableArea = 0;
            center.Premises.ForEach(p => GrossLeasableArea += p.Area);

            return GrossLeasableArea;
        }

        public double CalculateLeasedAreaPerCenter(int centerId)
        {
            var center = CenterRepository.FindCenterById(centerId);

            double leasedArea = 0;
            foreach (var unit in center.Premises)
            {
                if (CenterRepository.IsLeased(unit.Id))
                {
                    leasedArea += unit.Area;
                }
            }
            return leasedArea;

        }

        public double CalculateGrossLeasableAreaPerFloor(int centerId, string floorName)
        {
            var center = CenterRepository.FindCenterById(centerId);
            double GrossLeasableArea = 0;
            center.Premises.Where(p => p.Floor.Name == floorName).Sum(p => GrossLeasableArea += p.Area);

            return GrossLeasableArea;
        }

        public double CalculateLeasedAreaPerFloor(int centerId, string floorName)
        {
            var center = CenterRepository.FindCenterById(centerId);

            double leasedArea = 0;
            foreach (Unit unit in center.Premises)
            {
                if (CenterRepository.IsLeased(unit.Id) && unit.Floor.Name == floorName)
                {
                    leasedArea += unit.Area;
                }
            }
            return leasedArea;
        }

        public double CalculateOcupancyDegreePerCenter(int centerId)
        {
            return CalculateLeasedAreaPerCenter(centerId) / CalculateGrossLeasableAreaPerCenter(centerId) * 100;
        }

        public double CalculateOcupancyDegreePerFloor(int centerId, string floorName)
        {
            return Math.Round(CalculateLeasedAreaPerFloor(centerId, floorName) / CalculateGrossLeasableAreaPerFloor(centerId, floorName) * 100, 2);
        }

        public double CalculateAverageRentPerSQMPerCenter(int centerId)
        {
            var center = CenterRepository.FindCenterById(centerId);

            double totalRent = 0;

            foreach (Unit unit in center.Premises)
            {
                if (CenterRepository.IsLeased(unit.Id))
                {
                    totalRent += CenterRepository.GetValidLease(unit).TotalMonthlyRent;
                }
            }

            return Math.Round(totalRent / CalculateLeasedAreaPerCenter(centerId), 2);
        }

        public (double, double) CalculateLeasedAreaAndTotalRentPerActivity(int centerId, string activityName)
        {

            var leases = CenterRepository.FindValidLeasesInCenter(centerId);
            double leasedAreaPerActivity = 0;
            double totalRentPerActivity = 0;

            foreach (var item in leases)
            {
                if (item.Activity.Name == activityName)
                {
                    leasedAreaPerActivity += CenterRepository.GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item1;
                    totalRentPerActivity += CenterRepository.GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item2;
                }
            }
            return (leasedAreaPerActivity, totalRentPerActivity);
        }
        public (double, double) CalculateLeasedAreaAndTotalRentPerActivityRange(int centerId, string activityRangeName)
        {

            var leases = CenterRepository.FindValidLeasesInCenter(centerId);

            double leasedAreaPerActivityRange = 0;
            double totalRentPerActivityRange = 0;

            foreach (var item in leases)
            {
                leasedAreaPerActivityRange += CenterRepository.GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item1;
                totalRentPerActivityRange += CenterRepository.GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item2;
            }
            return (leasedAreaPerActivityRange, totalRentPerActivityRange);
        }

        public double CalculateAverageRentPerSQMPerActivity(int centerId, string activityName)
        {
            return CalculateLeasedAreaAndTotalRentPerActivityRange(centerId, activityName).Item2 / CalculateLeasedAreaAndTotalRentPerActivity(centerId, activityName).Item1;
        }
        public double CalculateAverageRentPerSQMPerActivityRange(int centerId, string activityRangeName)
        {
            return CalculateLeasedAreaAndTotalRentPerActivityRange(centerId, activityRangeName).Item2 / CalculateLeasedAreaAndTotalRentPerActivityRange(centerId, activityRangeName).Item1;

        }

        public double CalculateCostsPerLease(int leaseId)
        {
            Lease lease = CenterRepository.FindLeaseById(leaseId);

            return lease.TotalMonthlyRent + lease.TotalMonthlyMaintenanceCost + lease.TotalMarketingFee;


        }
        public DateTime CalculateLeaseEndDate(int leaseId)
        {
            Lease lease = CenterRepository.FindLeaseById(leaseId);
            TimeSpan duration = new TimeSpan(lease.TermInMonths * 30, 0, 0, 0);
            DateTime endDate = lease.StartDate.Add(duration);

            return endDate;
        }
        public double CalculateRentPerLease(int leaseId)
        {
            Lease lease = CenterRepository.FindLeaseById(leaseId);
            double totalRent = 0;
            lease.Premises.ForEach(u => totalRent += lease.TotalMonthlyRent);
            return totalRent;
        }
        #endregion
    }
}
