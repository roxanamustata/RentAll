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
                return await _rentAllDbContext.Centers.Include(c => c.Owner).ToListAsync();
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

        public async Task<Unit> GetUnitByIdAsync(int centerId, int unitId)
        {
            try
            {
                return await _rentAllDbContext.Units
                .Include(u => u.Center)
                .ThenInclude(u => u.Floors)
                .Where(u => u.CenterId == centerId)
                .FirstOrDefaultAsync(u => u.Id == unitId);


            }

            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve unit: {ex.Message}");
            }
        }


        public async Task<IEnumerable<Unit>> GetUnitsInCenterAsync(int centerId)
        {
            try
            {
                return await _rentAllDbContext.Units
                    .Include(u => u.Center)
                    .Include(u => u.Floor)
                    .Where(u => u.CenterId == centerId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<Unit> GetUnitFromCenterByUnitCodeAsync(int centerId, string unitCode)
        {
            try
            {
                return await _rentAllDbContext.Units
                       .Include(u => u.Center)
                       .ThenInclude(u => u.Floors)
                       .Where(u => u.CenterId == centerId)
                       .Where(u => u.UnitCode == unitCode)
                       .SingleAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        public async Task<Unit> CreateUnitInCenterAsync(int centerId, Unit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException($"{nameof(CreateUnitInCenterAsync)} entity must not be null");
            }

            try
            {
                var center = await _rentAllDbContext.Centers
                .Include(c => c.Units)
                .ThenInclude(u => u.Leases)
                .FirstOrDefaultAsync(c => c.Id == centerId);


                center.Units.Add(unit);
                _rentAllDbContext.Centers.Update(center);

                await _rentAllDbContext.SaveChangesAsync();

                return unit;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(unit)} could not be saved: {ex.Message}");
            }
        }


        public async Task DeleteUnitAsync(int centerId, int unitId)
        {
            var unit = await _rentAllDbContext.Units
                 .Include(u => u.Center)
                 .Where(u => u.CenterId == centerId)
                 .FirstOrDefaultAsync(u => u.Id == unitId);


            if (unit != null)
            {
                _rentAllDbContext.Units.Remove(unit);
                await _rentAllDbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateUnitAsync(int centerId, Unit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateUnitAsync)} entity must not be null");
            }

            try
            {
                var center = await _rentAllDbContext.Centers
                                .Include(c => c.Units)
                                .ThenInclude(u => u.Leases)
                                .FirstOrDefaultAsync(c => c.Id == centerId);

                _rentAllDbContext.Units.Update(unit);
                await _rentAllDbContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(unit)} could not be updated: {ex.Message}");
            }
        }
        #endregion


        #region CRUD lease
        public async Task<Lease> GetLeaseByIdAsync(int centerId, int leaseId)
        {
            try
            {
                return await _rentAllDbContext.Leases
                .Include(l => l.Center)
                .Include(l => l.Units)
                .Include(l => l.Tenant)
                .Include(l => l.Activity)
                .Where(l => l.CenterId == centerId)
                .FirstOrDefaultAsync(l => l.Id == leaseId);

            }

            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve unit: {ex.Message}");
            }
        }

        public async Task<Lease> GetValidLeaseByUnitIdAsync(int centerId, int unitId)
        {
            try
            {
                return await _rentAllDbContext.Leases
                 .Include(l => l.Center)
                 .ThenInclude(l => l.Units.Where(u => u.CenterId == centerId))
                 .Include(l => l.Tenant)
                 .Include(l => l.Activity)
                 .Where(l => l.Valid == true)
                 .Where(l => l.Units.Any(u => u.Id == unitId))
                 .SingleAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Lease>> GetLeasesInCenterAsync(int centerId)
        {
            return await _rentAllDbContext.Leases
                        .Include(l => l.Center)
                        .ThenInclude(l => l.Units)
                        .Include(l => l.Tenant)
                        .Include(l => l.Activity)
                        .Where(u => u.CenterId == centerId).ToListAsync();
        }
        public async Task<IEnumerable<Lease>> GetAllLeasesAsync()
        {
            return await _rentAllDbContext.Leases
                        .Include(l => l.Center)
                        .Include(l => l.Tenant)
                        .Include(l => l.Activity)

                .ToListAsync();
        }

        public async Task<Lease> CreateLeaseAsync(int centerId, int unitId, Lease lease)
        {

            if (lease == null)
            {
                throw new ArgumentNullException($"{nameof(CreateLeaseAsync)} entity must not be null");
            }

            try
            {
                var center = await _rentAllDbContext.Centers
                .Include(c => c.Units)
                .ThenInclude(u => u.Leases)
                .FirstOrDefaultAsync(c => c.Id == centerId);

                var foundUnit = center.Units.FirstOrDefault(u => u.Id == unitId);
                foundUnit.Leases.Add(lease);

                _rentAllDbContext.Centers.Update(center);
                await _rentAllDbContext.SaveChangesAsync();

                return lease;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(lease)} could not be saved: {ex.Message}");
            }
        }
        public async Task DeleteLeaseAsync(int centerId, int leaseId)
        {
            var lease = await _rentAllDbContext.Leases
                 .Include(l => l.Center)
                 .Where(l => l.CenterId == centerId)
                 .FirstOrDefaultAsync(l => l.Id == leaseId);


            if (lease != null)
            {
                _rentAllDbContext.Leases.Remove(lease);
                await _rentAllDbContext.SaveChangesAsync();
            }

        }
        public async Task UpdateLeaseAsync(int centerId, Lease lease)
        {
            if (lease == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateLeaseAsync)} entity must not be null");
            }

            try
            {
                var center = await _rentAllDbContext.Centers
                            .Include(c => c.Units)
                            .ThenInclude(u => u.Leases)
                            .FirstOrDefaultAsync(c => c.Id == centerId);



                _rentAllDbContext.Leases.Update(lease);
                await _rentAllDbContext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(lease)} could not be updated: {ex.Message}");
            }
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
