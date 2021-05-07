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
            //centers.Add(DomainModelFactory.GetShoppingCenter(1, "Iulius Mall Timisoara"));
            //centers.Add(DomainModelFactory.GetShoppingCenter(2, "Iulius Mall Cluj"));
            //centers.Add(DomainModelFactory.GetShoppingCenter(3, "Iulius Mall Iasi"));
            //units.Add(DomainModelFactory.GetUnitOnFirstfloor(1, 50));
            //units.Add(DomainModelFactory.GetUnitOnGroundfloor(2, 500));
            //units.Add(DomainModelFactory.GetUnitOnFirstfloor(3, 150));
            //units.Add(DomainModelFactory.GetUnitOnGroundfloor(4, 250));
            //units.Add(DomainModelFactory.GetUnitOnFirstfloor(5, 750));
            //units.Add(DomainModelFactory.GetUnitOnFirstfloor(6, 2750));
            //leases.Add(DomainModelFactory.GetLease(1));
            //leases.Add(DomainModelFactory.GetLease(2));
            //leases.Add(DomainModelFactory.GetLease(3));
        }
        #endregion


        #region public methods

        public Center FindCenterById(int centerId)
        {
            return centers.FirstOrDefault(c => c.Id == centerId);
        }

        public IList<Center> FindAll()
        {
            return centers;
        }

        public Center FindByName(string productName)
        {
            throw new NotImplementedException();
        }

        public bool Save(Center center)
        {
            if (centers.FirstOrDefault(c => c.Id == center.Id) == null)
            {
                centers.Add(center);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Unit FindUnitById(int unitId)
        {
            return units.FirstOrDefault(u => u.Id == unitId);
        }
        public Lease GetValidLease(Unit unit)
        {
            return unit.Leases.Find(l => l.Valid == true);
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
            return FindCenterById(centerId).Premises.FirstOrDefault(p=>p.Code==unitCode);
         
        }
        public void AddLeaseToUnitInCenter(int centerId, Unit unit, Lease lease)
        {
            Unit foundUnit = FindUnitInCenterByCode(centerId, unit.Code);
            foundUnit.Leases.Add(lease);
        }

        public Lease FindLeaseById(int leaseId)
        {
            return leases.FirstOrDefault(l=>l.Id==leaseId);
        }
        public List<Lease> FindLeasesByActivity(int centerId, string activityName)
        {
            var center = FindCenterById(centerId);

            var listOfLeases = new List<Lease>();
            foreach (var item in center.Premises)
            {
                if (IsLeased(item.Id) && GetValidLease(item).Activity.Name == activityName)
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
                    if (lease.Activity.ActivityCategory.Name.Equals(activityRangeName))
                    {
                        listOfLeases.Add(lease);
                    }
                }
            }
            return listOfLeases;
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
