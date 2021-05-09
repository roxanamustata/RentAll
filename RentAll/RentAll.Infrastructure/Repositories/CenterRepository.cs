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

        public Center FindCenterById(int centerId)
        {
            return _rentAllDbContext.Centers.Find(centerId);
        }

        public List<Center> GetAllCenters()
        {
            return _rentAllDbContext.Centers.ToList();
        }



        public Unit FindUnitById(int unitId)
        {
            return _rentAllDbContext.Units.Find(unitId);

        }

        public List<Unit> FindUnitsByLeaseId(int leaseId)
        {
            return _rentAllDbContext.Units
                .Include(u => u.Leases)
                .Where(u => u.Leases.All(l => l.Id == leaseId))
                .ToList();

        }

        public List<Unit> FindAllUnitsInCenter(int centerId)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Where(u => u.CenterId == centerId)
                        .ToList();

        }
        public List<Unit> FindAllLeasedUnitsInCenter(int centerId)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Leases.Any(l => l.Valid == true))
                        .ToList();

        }
        public List<Unit> FindAllUnitsInCenterOnFloor(int centerId, string floorName)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Floor)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Floor.FloorName == floorName)
                        .ToList();

        }

        public List<Unit> FindAllLeasedUnitsInCenterOnFloor(int centerId, string floorName)
        {

            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Floor)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Floor.FloorName == floorName)
                        .Where(u => u.Leases.Any(l => l.Valid == true))
                        .ToList();

        }

        public List<Unit> FindAllLeasedRetailUnitsInCenterByActivity(int centerId, string activityName)
        {
            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Leases.Any(l => l.Valid == true))
                        .Where(u => u.Type == UnitType.Retail)
                        .Where(u => u.Leases.Any(l => l.Activity.ActivityName == activityName))
                        .ToList();
        }

        public List<Unit> FindAllLeasedRetailUnitsInCenterByActivityCategory(int centerId, string categoryName)
        {
            return _rentAllDbContext.Units
                        .Include(u => u.Center)
                        .Include(u => u.Leases)
                        .Where(u => u.CenterId == centerId)
                        .Where(u => u.Leases.Any(l => l.Valid == true))
                        .Where(u => u.Type == UnitType.Retail)
                        .Where(u => u.Leases.Any(l => l.Activity.Category.CategoryName == categoryName))
                        .ToList();
        }


        public Lease GetValidLeaseOnUnit(int unitId)
        {
            return _rentAllDbContext.Leases
                 .Include(l => l.Units)
                 .Where(l => l.Valid == true)
                 .Where(l => l.Units.Any(u => u.Id == unitId))
                 .Single();


        }

        public List<Lease> GetValidLeasesOnCenter(int centerId)
        {
            return _rentAllDbContext.Leases
                 .Include(l => l.Center)
                 .Where(l => l.CenterId == centerId)
                 .Where(l => l.Valid == true)
                 .ToList();

        }


        public bool IsUnitLeased(int unitId)
        {

            return _rentAllDbContext.Units
                .Include(u => u.Leases)
                .Where(u => u.Id == unitId).Single()
                .Leases.Any(l => l.Valid);

        }

        public Unit FindUnitInCenterByCode(int centerId, string unitCode)
        {
            return _rentAllDbContext.Units
                   .Include(u => u.Center)
                   .Where(u => u.CenterId == centerId)
                   .Where(u => u.UnitCode == unitCode)
                   .Single();

        }

        public Lease FindLeaseById(int leaseId)
        {
            return _rentAllDbContext.Leases.Find(leaseId);
        }


        public List<Lease> FindLeasesInCenterByActivity(int centerId, string activityName)
        {
            return _rentAllDbContext.Leases
                .Include(l => l.Center)
                .Include(l => l.Activity)
                .Where(l => l.CenterId == centerId)
                .Where(l => l.Activity.ActivityName == activityName)
                .ToList();
        }


        public List<Lease> FindLeasesInCenterByActivityCategory(int centerId, string categoryName)
        {
            return _rentAllDbContext.Leases
                 .Include(l => l.Center)
                 .Include(l => l.Activity)
                 .Include(l => l.Activity.Category)
                 .Where(l => l.CenterId == centerId)
                 .Where(l => l.Activity.Category.CategoryName == categoryName)
                 .ToList();
        }
        public List<Lease> FindValidLeasesInCenter(int centerId)
        {
            return _rentAllDbContext.Leases
                 .Include(l => l.Center)
                 .Where(l => l.CenterId == centerId)
                 .Where(l => l.Valid == true)
                 .ToList();

        }

        #endregion

    }
}
