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
        private RentAllDbContext _rentAllDbContext;
        #endregion

        #region constructors
        public CenterRepository(RentAllDbContext rentAllDbContext)
        {
            _rentAllDbContext = rentAllDbContext;
        }
        #endregion


        #region public methods

        public void Save()
        {
            _rentAllDbContext.SaveChanges();
        }

        #region CRUD center

        public List<Center> GetCenters()
        {
            return _rentAllDbContext.Centers.ToList();
        }
        public Center GetCenterById(int centerId)
        {
            return _rentAllDbContext.Centers.Find(centerId);
        }

        public void InsertCenter(Center center)
        {
            _rentAllDbContext.Centers.Add(center);
            Save();
        }

        public void DeleteCenter(int centerId)
        {
            var center = GetCenterById(centerId);
            _rentAllDbContext.Centers.Remove(center);
            Save();
        }
        public void UpdateCenter(Center center)
        {
            _rentAllDbContext.Centers.Attach(center);
            var entry = _rentAllDbContext.Entry(center);
            entry.State = EntityState.Modified;

            Save();
        }
        #endregion

        #region CRUD unit

        public Unit GetUnitById(int unitId)
        {
            return _rentAllDbContext.Units.Find(unitId);

        }
        public Unit GetUnitFromCenterByUnitCode(int centerId, string unitCode)
        {
            return _rentAllDbContext.Units
                   .Include(u => u.Center)
                   .Where(u => u.CenterId == centerId)
                   .Where(u => u.UnitCode == unitCode)
                   .Single();

        }

        public async void InsertUnit(Unit unit)
        {

            var center = await _rentAllDbContext.Centers
                .Include(c => c.Units)
                .ThenInclude(u => u.Leases)
                .FirstOrDefaultAsync(c => c.Id == unit.CenterId);

            center.Units.Add(unit);

            Save();
        }
        public void DeleteUnit(int unitId)
        {
            var unit = GetUnitById(unitId);
            _rentAllDbContext.Units.Remove(unit);
            Save();
        }
        public void UpdateUnit(Unit unit)
        {
            _rentAllDbContext.Units.Attach(unit);
            var entry = _rentAllDbContext.Entry(unit);
            entry.State = EntityState.Modified;
            Save();
        }
        #endregion

        #region CRUD lease
        public Lease GetLeaseById(int leaseId)
        {
            return _rentAllDbContext.Leases.Find(leaseId);
        }

        public void InsertLease(Lease lease)
        {
            _rentAllDbContext.Leases.Add(lease);
            Save();
        }
        public void DeleteLease(int leaseId)
        {
            var lease = GetLeaseById(leaseId);
            _rentAllDbContext.Leases.Remove(lease);
            Save();

        }
        public void UpdateLease(Lease lease)
        {
            _rentAllDbContext.Leases.Attach(lease);
            var entry = _rentAllDbContext.Entry(lease);
            entry.State = EntityState.Modified;
            Save();
        }

        #endregion

        #region CRUD category


        #endregion



        #region CRUD activity


        #endregion



        #region CRUD Floor


        #endregion





        public IEnumerable<Unit> FindUnitsByLeaseId(int leaseId)
        {
            return _rentAllDbContext.Units
                .Include(u => u.Leases)
                .Where(u => u.Leases.All(l => l.Id == leaseId));


        }

        public IEnumerable<Unit> FindAllUnitsInCenter(int centerId)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Where(u => u.CenterId == centerId);

        }
        public IEnumerable<Unit> FindAllLeasedUnitsInCenter(int centerId)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Leases.Any(l => l.Valid == true));

                    }
        public IEnumerable<Unit> FindAllUnitsInCenterOnFloor(int centerId, string floorName)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Floor)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Floor.FloorName == floorName);

        }

        public IEnumerable<Unit> FindAllLeasedUnitsInCenterOnFloor(int centerId, string floorName)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Floor)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Floor.FloorName == floorName)
                        .Where(u => u.Leases.Any(l => l.Valid == true));

        }

        public IEnumerable<Unit> FindAllLeasedRetailUnitsInCenterByActivity(int centerId, string activityName)
        {
            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Leases.Any(l => l.Valid == true))
                        .Where(u => u.Type == UnitType.Retail)
                        .Where(u => u.Leases.Any(l => l.Activity.ActivityName == activityName));

        }

        public IEnumerable<Unit> FindAllLeasedRetailUnitsInCenterByActivityCategory(int centerId, string categoryName)
        {
            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Leases.Any(l => l.Valid == true))
                        .Where(u => u.Type == UnitType.Retail)
                        .Where(u => u.Leases.Any(l => l.Activity.Category.CategoryName == categoryName));

        }

        public Lease GetValidLeaseOnUnit(int unitId)
        {
            return _rentAllDbContext.Leases
                 .Include(l => l.Units)
                 .Where(l => l.Valid == true)
                 .Where(l => l.Units.Any(u => u.Id == unitId))
                 .Single();


        }

        public IEnumerable<Lease> GetValidLeasesOnCenter(int centerId)
        {
            return _rentAllDbContext.Leases
                 .Include(l => l.Center)
                 .Where(l => l.CenterId == centerId)
                 .Where(l => l.Valid == true);


        }

        public bool IsUnitLeased(int unitId)
        {

            return _rentAllDbContext.Units
                .Include(u => u.Leases)
                .Where(u => u.Id == unitId).Single()
                .Leases.Any(l => l.Valid);

        }

        public IEnumerable<Lease> FindLeasesInCenterByActivity(int centerId, string activityName)
        {
            return _rentAllDbContext.Leases
                .Include(l => l.Center)
                .Include(l => l.Activity)
                .Where(l => l.CenterId == centerId)
                .Where(l => l.Activity.ActivityName == activityName);

        }

        public IEnumerable<Lease> FindLeasesInCenterByActivityCategory(int centerId, string categoryName)
        {
            return _rentAllDbContext.Leases
                 .Include(l => l.Center)
                 .Include(l => l.Activity)
                 .Include(l => l.Activity.Category)
                 .Where(l => l.CenterId == centerId)
                 .Where(l => l.Activity.Category.CategoryName == categoryName);

        }
        public IEnumerable<Lease> FindValidLeasesInCenter(int centerId)
        {
            return _rentAllDbContext.Leases
                 .Include(l => l.Center)
                 .Where(l => l.CenterId == centerId)
                 .Where(l => l.Valid == true);


        }

        #endregion

    }
}
