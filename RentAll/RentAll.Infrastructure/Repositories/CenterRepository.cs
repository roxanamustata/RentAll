using Microsoft.EntityFrameworkCore;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentAll.Infrastructure.Repositories
{

    public class CenterRepository : ICenterRepository
    {
        #region fields
        private readonly RentAllDbContext _rentAllDbContext;
        #endregion

        #region constructors
        public CenterRepository(RentAllDbContext rentAllDbContext)
        {
            _rentAllDbContext = rentAllDbContext;
        }
        #endregion


        #region public methods

        public Center FindCenterById(int centerId)
        {
            return _rentAllDbContext.Centers.Find(centerId);

        }

        public Unit FindUnitById(int unitId)
        {
            return _rentAllDbContext.Units.Find(unitId);
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
            foreach (var item in center.Units)
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
            return _rentAllDbContext.Leases.Find(leaseId);

        }
        public List<Lease> FindLeasesByActivity(int centerId, string activityName)
        {
            var center = FindCenterById(centerId);

            var listOfLeases = new List<Lease>();
            foreach (var item in center.Units)
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
            foreach (var item in center.Units)
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
            return _rentAllDbContext.Leases.Where(l => l.Valid == true).ToList();

        }



        #endregion

    }
}
