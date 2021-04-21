using RentAll.Domain;
using RentAll.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentAll.Infrastructure.Repositories
{


    public class CenterRepository : ICenterRepository
    {

        private List<Center> centers = new List<Center>();

        public CenterRepository()
        {
            centers.Add(DomainModelFactory.GetShoppingCenter(1, new int[] { 200, 50, 100, 500 }));
            centers.Add(DomainModelFactory.GetShoppingCenter(2, new int[] { 200, 50, 150, 500 }));
            centers.Add(DomainModelFactory.GetShoppingCenter(3, new int[] { 200, 50, 10, 5000 }));
        }

        public Center FindCenterById(int centerId)
        {
            Center center = null;
            foreach (var item in centers)
            {
                if (item.Id == centerId)
                {
                    center = item;
                }

            }
            if (center == null)
            {
                throw new InvalidOperationException($"Center with id {centerId} not found");

            }
            return center;
        }

        public Unit FindUnitInCenterByCode(int centerId, string unitCode)
        {
            Center center = FindCenterById(centerId);
            Unit unit = null;
            foreach (var item in center.Premises)
            {
                if (item.Code == unitCode)
                {
                    unit = item;
                }

            }
            if (unit == null)
            {
                throw new InvalidOperationException($"Unit with code {unitCode} not found");

            }
            return unit;
        }

        public void AddLeaseToUnitInCenter(int centerId, Unit unit, Lease lease)
        {
            Unit foundUnit = FindUnitInCenterByCode(centerId, unit.Code);
            foundUnit.Leases.Add(lease);
        }

        public double CalculateGrossLeasableAreaPerCenter(int centerId)
        {
            var center = FindCenterById(centerId);
            double GrossLeasableArea = 0;
            center.Premises.ForEach(p => GrossLeasableArea += p.Area);

            return GrossLeasableArea;
        }

        public double CalculateLeasedAreaPerCenter(int centerId)
        {
            var center = FindCenterById(centerId);
            double leasedArea = 0;
            foreach (var unit in center.Premises)
            {
                if (unit.IsLeased())
                {
                    leasedArea += unit.Area;
                }
            }
            return leasedArea;

        }

        public double CalculateGrossLeasableAreaPerFloor(int centerId, string floorName)
        {
            var center = FindCenterById(centerId);
            double GrossLeasableArea = 0;
            center.Premises.Where(p => p.Floor.Name == floorName).Sum(p => GrossLeasableArea += p.Area);

            return GrossLeasableArea;
        }

        public double CalculateLeasedAreaPerFloor(int centerId, string floorName)
        {
            var center = FindCenterById(centerId);
            double leasedArea = 0;
            foreach (Unit unit in center.Premises)
            {
                if (unit.IsLeased() && unit.Floor.Name == floorName)
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
            var center = FindCenterById(centerId);
            double totalRent = 0;

            foreach (Unit unit in center.Premises)
            {
                if (unit.IsLeased())
                {
                    totalRent += unit.GetValidLease().RentSqm * unit.Area;
                }
            }

            return Math.Round(totalRent / CalculateLeasedAreaPerCenter(centerId), 2);
        }

        public List<Lease> FindLeasesByActivity(int centerId, string activityName)
        {
            var center = FindCenterById(centerId);
            var listOfLeases = new List<Lease>();
            foreach (var item in center.Premises)
            {
                if (item.IsLeased() && item.GetValidLease().Activity.Name == activityName)
                {
                    listOfLeases.Add(item.GetValidLease());
                }
            }
            return listOfLeases;
        }
        public List<Lease> FindLeasesByActivityRange(int centerId, string activityRangeName)
        {
            var center = FindCenterById(centerId);
            var listOfLeases = new List<Lease>();
            foreach (var item in center.Premises)
            {
                if (item.IsLeased())
                {
                    Lease lease = item.GetValidLease();
                    if (lease.Activity.ActivityRange.Name.Equals(activityRangeName))
                    {
                        listOfLeases.Add(lease);
                    }
                }
            }
            return listOfLeases;
        }
        public (double, double) CalculateLeasedAreaAndTotalRentPerActivity(int centerId, string activityName)
        {
            var leaseRepository = new LeaseRepository();
            var leases = leaseRepository.FindValidLeasesInCenter(centerId);
            double leasedAreaPerActivity = 0;
            double totalRentPerActivity = 0;
            
            foreach (var item in leases)
            {
                if (item.Activity.Name == activityName)
                {
                    leasedAreaPerActivity += leaseRepository.GetAreaByUnitType(item,UnitType.Retail);
                    totalRentPerActivity += leaseRepository.GetAreaByUnitType(item,UnitType.Retail) * item.RentSqm;
                }
                }
            return (leasedAreaPerActivity, totalRentPerActivity);
        }
        public (double, double) CalculateLeasedAreaAndTotalRentPerActivityRange(int centerId, string activityRangeName)
        {
            var leaseRepository = new LeaseRepository();
            var leases = leaseRepository.FindValidLeasesInCenter(centerId);

            double leasedAreaPerActivityRange = 0;
            double totalRentPerActivityRange = 0;
            
            foreach (var item in leases)
            {
                leasedAreaPerActivityRange += leaseRepository.GetAreaByUnitType(item, UnitType.Retail);
                totalRentPerActivityRange += leaseRepository.GetAreaByUnitType(item, UnitType.Retail) * item.RentSqm;
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
    }
}
