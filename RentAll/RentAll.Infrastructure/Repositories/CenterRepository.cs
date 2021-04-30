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
        private ICollection<Center> centers = new List<Center>();
        private ICollection<Unit> units = new List<Unit>();
        private ICollection<Lease> leases = new List<Lease>();
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


        #region public methods

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
            return unit.Leases.FirstOrDefault(l => l.Valid == true);
        }
        public bool IsLeased(int unitId)
        {
            var unit = FindUnitById(unitId);
            foreach (Lease Lease in unit.Leases)
            {
                if (Lease.Valid)
                {
                    return true;
                }
            }
            return false;
        }
        public Unit FindUnitInCenterByCode(int centerId, string unitCode)
        {
            Center center = FindCenterById(centerId);
            Unit unit = null;
            foreach (var item in center.Premises)
            {
                if (item.UnitCode == unitCode)
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
            Unit foundUnit = FindUnitInCenterByCode(centerId, unit.UnitCode);
            foundUnit.Leases.Add(lease);
        }

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
        public List<Lease> FindLeasesByActivity(int centerId, string activityName)
        {
            var center = FindCenterById(centerId);

            var listOfLeases = new List<Lease>();
            foreach (var item in center.Premises)
            {
                if (IsLeased(item.Id) && GetValidLease(item).Activity.ActivityName == activityName)
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
                if (IsLeased(item.Id))
                {
                    Lease lease = GetValidLease(item);
                    if (lease.Activity.Category.CategoryName.Equals(activityRangeName))
                    {
                        listOfLeases.Add(lease);
                    }
                }
            }
            return listOfLeases;
        }
        public ICollection<Lease> FindValidLeasesInCenter(int centerId)
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
