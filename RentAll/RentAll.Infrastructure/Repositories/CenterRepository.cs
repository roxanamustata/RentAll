using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #region CRUD center

        public async Task<IEnumerable<Center>> GetCentersAsync()
        {
            try
            {
                return await _rentAllDbContext.Centers.Include(c=>c.Owner).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public async Task<Center> GetCenterByIdAsync(int centerId)
        {
            return await _rentAllDbContext.Centers.Include(c => c.Owner).FirstOrDefaultAsync(c => c.Id == centerId);
        }

        public async Task<Center> CreateCenterAsync(Center center)
        {
            if (center == null)
            {
                throw new ArgumentNullException($"{nameof(CreateCenterAsync)} entity must not be null");
            }

            try
            {
                await _rentAllDbContext.Centers.AddAsync(center);
                await _rentAllDbContext.SaveChangesAsync();

                return center;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(center)} could not be saved: {ex.Message}");
            }


        }

        public async Task UpdateCenterAsync(Center center)
        {
            if (center == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateCenterAsync)} entity must not be null");
            }

            try
            {
                _rentAllDbContext.Centers.Update(center);
                await _rentAllDbContext.SaveChangesAsync();
               

            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(center)} could not be updated: {ex.Message}");
            }


        }


        public async Task DeleteCenterAsync(int centerId)
        {
            var center = _rentAllDbContext.Centers.Find(centerId);
       
            
            if (center != null)
            {
                _rentAllDbContext.Centers.Remove(center);
                await _rentAllDbContext.SaveChangesAsync();
            }


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

        public async Task<IEnumerable<Lease>> GetLeasesByCenterId(int centerId)
        {
            return await _rentAllDbContext.Leases
                        .Include(l => l.Center)
                        .Include(l => l.Units)
                        .Where(u => u.CenterId == centerId).ToListAsync();
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


        public void Save()
        {
            _rentAllDbContext.SaveChanges();
        }




        #region filters
        public IQueryable<Unit> FindUnitsByLeaseId(int leaseId)
        {
            return _rentAllDbContext.Units
                .Include(u => u.Leases)
                .Where(u => u.Leases.All(l => l.Id == leaseId));


        }

        public IQueryable<Unit> FindAllUnitsInCenter(int centerId)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Where(u => u.CenterId == centerId);

        }
        public IQueryable<Unit> FindAllLeasedUnitsInCenter(int centerId)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Leases.Any(l => l.Valid == true));

        }
        public IQueryable<Unit> FindAllUnitsInCenterOnFloor(int centerId, string floorName)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Floor)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Floor.FloorName == floorName);

        }

        public IQueryable<Unit> FindAllLeasedUnitsInCenterOnFloor(int centerId, string floorName)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Floor)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Floor.FloorName == floorName)
                        .Where(u => u.Leases.Any(l => l.Valid == true));

        }

        public IQueryable<Unit> FindAllLeasedRetailUnitsInCenterByActivity(int centerId, string activityName)
        {
            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Leases.Any(l => l.Valid == true))
                        .Where(u => u.Type == UnitType.Retail)
                        .Where(u => u.Leases.Any(l => l.Activity.ActivityName == activityName));

        }

        public IQueryable<Unit> FindAllLeasedRetailUnitsInCenterByActivityCategory(int centerId, string categoryName)
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

        public IQueryable<Lease> GetValidLeasesOnCenter(int centerId)
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

        public IQueryable<Lease> FindLeasesInCenterByActivity(int centerId, string activityName)
        {
            return _rentAllDbContext.Leases
                .Include(l => l.Center)
                .Include(l => l.Activity)
                .Where(l => l.CenterId == centerId)
                .Where(l => l.Activity.ActivityName == activityName);

        }

        public IQueryable<Lease> FindLeasesInCenterByActivityCategory(int centerId, string categoryName)
        {
            return _rentAllDbContext.Leases
                 .Include(l => l.Center)
                 .Include(l => l.Activity)
                 .Include(l => l.Activity.Category)
                 .Where(l => l.CenterId == centerId)
                 .Where(l => l.Activity.Category.CategoryName == categoryName);

        }
        public IQueryable<Lease> FindValidLeasesInCenter(int centerId)
        {
            return _rentAllDbContext.Leases
                 .Include(l => l.Center)
                 .Where(l => l.CenterId == centerId)
                 .Where(l => l.Valid == true);


        }

        #endregion


        #endregion

    }
}
