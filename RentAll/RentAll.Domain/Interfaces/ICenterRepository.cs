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


        Task<IEnumerable<Unit>> GetUnitsInCenterAsync(int centerId);
        Task<Unit> GetUnitByIdAsync(int centerId,int unitId);
        Task<Unit> GetUnitFromCenterByUnitCodeAsync(int centerId, string unitCode);
        Task<Unit> CreateUnitInCenterAsync(int centerId, Unit unit);
        Task DeleteUnitAsync(int centerId, int unitId);
        Task UpdateUnitAsync(int centerId,Unit unit);


        Task<IEnumerable<Lease>> GetLeasesInCenterAsync(int centerId);
        Task<IEnumerable<Lease>> GetAllLeasesAsync();
        Task<Lease> GetLeaseByIdAsync(int centerId, int leaseId);
        Task<Lease> GetValidLeaseByUnitIdAsync(int centerId, int unitId);
        Task<Lease> CreateLeaseAsync(int centerId, int unitId, Lease lease);
        Task DeleteLeaseAsync(int centerId, int leaseId);
        Task UpdateLeaseAsync(int centerId, Lease lease);



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
