using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterRepository
    {
        void Save();
       

        Task<IEnumerable<Center>> GetCentersAsync();
        Task<Center> GetCenterByIdAsync(int centerId);
        Task<Center> CreateCenterAsync(Center center);
        Task DeleteCenterAsync(int centerId);
        Task UpdateCenterAsync(Center center);


        Unit GetUnitById(int unitId);
        Unit GetUnitFromCenterByUnitCode(int centerId, string unitCode);
        void InsertUnit(Unit unit);
        void DeleteUnit(int unitId);
        void UpdateUnit(Unit unit);


        Task<IEnumerable<Lease>> GetLeasesByCenterId(int centerId);
        Lease GetLeaseById(int leaseId);
        void InsertLease(Lease lease);
        void DeleteLease(int leaseId);
        void UpdateLease(Lease lease);



        IQueryable<Unit> FindAllUnitsInCenter(int centerId);
        IQueryable<Unit> FindAllLeasedUnitsInCenter(int centerId);
        IQueryable<Unit> FindUnitsByLeaseId(int leaseId);
        IQueryable<Unit> FindAllUnitsInCenterOnFloor(int centerId, string floorName);
        IQueryable<Unit> FindAllLeasedUnitsInCenterOnFloor(int centerId, string floorName);
        IQueryable<Unit> FindAllLeasedRetailUnitsInCenterByActivity(int centerId, string activityName);
        IQueryable<Unit> FindAllLeasedRetailUnitsInCenterByActivityCategory(int centerId, string categoryName);
        IQueryable<Lease> GetValidLeasesOnCenter(int centerId);
        IQueryable<Lease> FindLeasesInCenterByActivity(int centerId, string activityName);
        IQueryable<Lease> FindLeasesInCenterByActivityCategory(int centerId, string activityRangeName);
        IQueryable<Lease> FindValidLeasesInCenter(int centerId);

        bool IsUnitLeased(int unitId);
        Lease GetValidLeaseOnUnit(int unitId);
    }
}
