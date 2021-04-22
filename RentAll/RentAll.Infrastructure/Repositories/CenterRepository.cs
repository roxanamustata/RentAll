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
        #region fields
        private List<Center> centers = new List<Center>();
        private List<Unit> units = new List<Unit>();
        private List<Lease> leases = new List<Lease>();
        #endregion

        #region constructors
        public CenterRepository()
        {
            centers.Add(DomainModelFactory.GetShoppingCenter(1, "Iulius Mall Timisoara"));
            centers.Add(DomainModelFactory.GetShoppingCenter(2, "Iulius Mall Cluj"));
            centers.Add(DomainModelFactory.GetShoppingCenter(3, "Iulius Mall Iasi"));
            units.Add(DomainModelFactory.GetUnitOnFirstfloor(1, 50));
            units.Add(DomainModelFactory.GetUnitOnGroundfloor(2, 500));
            units.Add(DomainModelFactory.GetUnitOnFirstfloor(3, 150));
            units.Add(DomainModelFactory.GetUnitOnGroundfloor(4, 250));
            units.Add(DomainModelFactory.GetUnitOnFirstfloor(5, 750));
            units.Add(DomainModelFactory.GetUnitOnFirstfloor(6, 2750));
            leases.Add(DomainModelFactory.GetLease(1));
            leases.Add(DomainModelFactory.GetLease(2));
            leases.Add(DomainModelFactory.GetLease(3));
        }
        #endregion


        #region public center methods

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
                if (IsLeased(unit))
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
                if (IsLeased(unit) && unit.Floor.Name == floorName)
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
                if (IsLeased(unit))
                {
                    totalRent += GetValidLease(unit).TotalMonthlyRent;
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
                if (IsLeased(item) && GetValidLease(item).Activity.Name == activityName)
                {
                    listOfLeases.Add(GetValidLease(item));
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
                if (IsLeased(item))
                {
                    Lease lease = GetValidLease(item);
                    if (lease.Activity.ActivityCategory.Name.Equals(activityRangeName))
                    {
                        listOfLeases.Add(lease);
                    }
                }
            }
            return listOfLeases;
        }
        public (double, double) CalculateLeasedAreaAndTotalRentPerActivity(int centerId, string activityName)
        {

            var leases = FindValidLeasesInCenter(centerId);
            double leasedAreaPerActivity = 0;
            double totalRentPerActivity = 0;

            foreach (var item in leases)
            {
                if (item.Activity.Name == activityName)
                {
                    leasedAreaPerActivity += GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item1;
                    totalRentPerActivity += GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item2;
                }
            }
            return (leasedAreaPerActivity, totalRentPerActivity);
        }
        public (double, double) CalculateLeasedAreaAndTotalRentPerActivityRange(int centerId, string activityRangeName)
        {

            var leases = FindValidLeasesInCenter(centerId);

            double leasedAreaPerActivityRange = 0;
            double totalRentPerActivityRange = 0;

            foreach (var item in leases)
            {
                leasedAreaPerActivityRange += GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item1;
                totalRentPerActivityRange += GetLeaseAreaAndRentByUnitType(item, UnitType.Retail).Item2;
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
        #endregion

        #region public unit methods
        public Unit FindUnitById(int unitId)
        {
            Unit unit = null;
            foreach (var item in units)
            {
                if (item.Id == unitId)
                {
                    unit = item;
                }

            }
            if (unit == null)
            {
                throw new InvalidOperationException($"Unit with id {unitId} not found");

            }
            return unit;
        }
        public Lease GetValidLease(Unit unit)
        {
            return unit.Leases.Find(l => l.Valid == true);
        }
        public bool IsLeased(Unit unit)
        {
            foreach (Lease Lease in unit.Leases)
            {
                if (Lease.Valid)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region public lease methods
        public Lease FindLeaseById(int leaseId)
        {
            Lease lease = null;
            foreach (var item in leases)
            {
                if (item.Id == leaseId)
                {
                    lease = item;
                }

            }
            if (lease == null)
            {
                throw new InvalidOperationException($"Center with id {leaseId} not found");

            }
            return lease;
        }
        public List<Lease> FindValidLeasesInCenter(int centerId)
        {
            var foundLeases = new List<Lease>();

            foreach (var item in leases)
            {
                if (item.CenterId == centerId)
                {
                    if (item.Valid == true)
                    {
                        foundLeases.Add(item);
                    }
                }

            }
            if (foundLeases == null)
            {
                throw new InvalidOperationException($"No valid leases were found for center with id {centerId}");

            }
            return leases;
        }
        public double CalculateCostsPerLease(int leaseId)
        {
            Lease lease = FindLeaseById(leaseId);
            double TotalCosts = 0;
            foreach (Unit Unit in lease.Premises)
            {
                TotalCosts += lease.TotalMonthlyRent + lease.TotalMonthlyMaintenanceCost + lease.TotalMarketingFee;
            }
            return TotalCosts;
        }
        public DateTime CalculateLeaseEndDate(int leaseId)
        {
            Lease lease = FindLeaseById(leaseId);
            TimeSpan duration = new TimeSpan(lease.TermInMonths * 30, 0, 0, 0);
            DateTime endDate = lease.StartDate.Add(duration);

            return endDate;
        }
        public double CalculateRentPerLease(int leaseId)
        {
            Lease lease = FindLeaseById(leaseId);
            double totalRent = 0;
            lease.Premises.ForEach(u => totalRent += lease.TotalMonthlyRent);
            return totalRent;
        }
        public (double, double) GetLeaseAreaAndRentByUnitType(Lease lease, UnitType unitType)
        {
            double totalAreaByUnitType = 0;
            double totalRentByUnitType = 0;
            foreach (var item in lease.Premises)
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
