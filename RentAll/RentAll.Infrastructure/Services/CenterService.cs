﻿using RentAll.Domain;
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
        private readonly ICenterRepository _centerRepository;

        public CenterService(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }

        #region public methods
        public double CalculateGrossLeasableAreaPerCenter(int centerId)
        {
            var center = _centerRepository.FindCenterById(centerId);
            return center.Units.Sum(p => p.Area);
            
        }

        public double CalculateLeasedAreaPerCenter(int centerId)
        {
            var center = _centerRepository.FindCenterById(centerId);

            double leasedArea = 0;
            foreach (var unit in center.Units)
            {
                if (_centerRepository.IsLeased(unit.Id))
                {
                    leasedArea += unit.Area;
                }
            }
            return leasedArea;

        }

        public double CalculateGrossLeasableAreaPerFloor(int centerId, string floorName)
        {
            var center = _centerRepository.FindCenterById(centerId);
            double GrossLeasableArea = 0;
            center.Units.Where(p => p.Floor.FloorName == floorName).Sum(p=>p.Area);

            return GrossLeasableArea;
        }

        public double CalculateLeasedAreaPerFloor(int centerId, string floorName)
        {
            var center = _centerRepository.FindCenterById(centerId);

            double leasedArea = 0;
            foreach (Unit unit in center.Units)
            {
                if (_centerRepository.IsLeased(unit.Id) && unit.Floor.FloorName == floorName)
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
            var center = _centerRepository.FindCenterById(centerId);

            double totalRent = 0;

            foreach (Unit unit in center.Units)
            {
                if (_centerRepository.IsLeased(unit.Id))
                {
                    totalRent += _centerRepository.GetValidLease(unit).TotalMonthlyRent;
                }
            }

            return Math.Round(totalRent / CalculateLeasedAreaPerCenter(centerId), 2);
        }

        public (double, double) CalculateLeasedAreaAndTotalRentPerActivity(int centerId, string activityName)
        {

            var leases = _centerRepository.FindValidLeasesInCenter(centerId);
            double leasedAreaPerActivity = 0;
            double totalRentPerActivity = 0;

            foreach (var item in leases)
            {
                if (item.Activity.ActivityName == activityName)
                {
                    leasedAreaPerActivity += GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item1;
                    totalRentPerActivity += GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item2;
                }
            }
            return (leasedAreaPerActivity, totalRentPerActivity);
        }
        public (double, double) CalculateLeasedAreaAndTotalRentPerActivityRange(int centerId, string activityRangeName)
        {

            var leases = _centerRepository.FindValidLeasesInCenter(centerId);

            double leasedAreaPerCategory = 0;
            double totalRentPerCategory = 0;

            
            foreach (var item in leases)
            {
                leasedAreaPerCategory +=GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item1;
                totalRentPerCategory += GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item2;
            }
            return (leasedAreaPerCategory, totalRentPerCategory);
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
            Lease lease = _centerRepository.FindLeaseById(leaseId);

            return lease.TotalMonthlyRent + lease.TotalMonthlyMaintenanceCost + lease.TotalMarketingFee;


        }
        public DateTime CalculateLeaseEndDate(int leaseId)
        {
            Lease lease = _centerRepository.FindLeaseById(leaseId);
            TimeSpan duration = new TimeSpan(lease.TermInMonths * 30, 0, 0, 0);
            DateTime endDate = lease.StartDate.Add(duration);

            return endDate;
        }
        public double CalculateRentPerLease(int leaseId)
        {
            Lease lease = _centerRepository.FindLeaseById(leaseId);
           
            return lease.Units.Sum(u => lease.TotalMonthlyRent);
                              
           
        }
        public (double, double) GetLeaseAreaAndRentByUnitType(Lease lease, UnitType unitType)
        {
            double totalAreaByUnitType = 0;
            double totalRentByUnitType = 0;
            foreach (var item in lease.Units)
            {
                if (item.Type == unitType)
                {
                    totalAreaByUnitType += item.Area;
                    totalRentByUnitType += item.MonthlyRentSqm * item.Area;
                }
            }
            return (totalAreaByUnitType, totalRentByUnitType);
        }



        #endregion
    }
}