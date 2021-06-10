using Microsoft.AspNetCore.Mvc;
using RentAll.Domain;
using RentAll.Domain.Interfaces;

using RentAll.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Infrastructure.Services
{
    public class CenterService : ICenterService
    {
        #region fields
        private readonly ICenterRepository _centerRepository;
        #endregion

        #region constructors
        public CenterService(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }
        #endregion


        #region public methods
        #region centers
        public async Task<IEnumerable<Center>> GetCentersAsync()
        {
            return await _centerRepository.GetCentersAsync();
        }

        public async Task<Center> GetCenterByIdAsync(int id)
        {
            return await _centerRepository.GetCenterByIdAsync(id);
        }

        public async Task<Center> CreateCenterAsync(Center center)
        {

            return await _centerRepository.CreateCenterAsync(center);
        }

        public async Task UpdateCenterAsync(Center center)
        {
            await _centerRepository.UpdateCenterAsync(center);
        }

        public async Task DeleteCenterAsync(int centerId)
        {
            await _centerRepository.DeleteCenterAsync(centerId);
        }
        #endregion

        #region units

        public async Task<IEnumerable<Unit>> GetUnitsInCenterAsync(int centerId)
        {
            var items = await _centerRepository
                              .GetUnitsInCenterAsync(centerId);

            foreach (var item in items)
            {
                item.ValidLease = item.Leases.FirstOrDefault(i => i.Valid == true);
                
            }
            return items;
        }

        public async Task<Unit> GetUnitByIdAsync(int centerId, int unitId)
        {
            return await _centerRepository.GetUnitByIdAsync(centerId, unitId);
        }

        public async Task<Unit> GetUnitFromCenterByUnitCodeAsync(int centerId, string unitCode)
        {
            return await _centerRepository.GetUnitFromCenterByUnitCodeAsync(centerId, unitCode);
        }

        public async Task<Unit> CreateUnitInCenterAsync(int centerId, Unit unit)
        {
            return await _centerRepository.CreateUnitInCenterAsync(centerId, unit);
        }

        public async Task DeleteUnitAsync(int centerId, int unitId)
        {
            await _centerRepository.DeleteUnitAsync(centerId, unitId);
        }

        public async Task UpdateUnitAsync(int centerId, Unit unit)
        {
            await _centerRepository.UpdateUnitAsync(centerId, unit);
        }

        #endregion

        #region leases

        public async Task<Lease> GetLeaseByIdAsync(int centerId, int leaseId)
        {
            return await _centerRepository.GetLeaseByIdAsync(centerId, leaseId);
        }

        public async Task<Lease> GetValidLeaseByUnitIdAsync(int centerId, int unitId)
        {
            return await _centerRepository.GetValidLeaseByUnitIdAsync(centerId, unitId);
        }

        public async Task<Lease> GetValidLeaseByUnitIdAsync(int unitId)
        {
            return await _centerRepository.GetValidLeaseByUnitIdAsync(unitId);
        }

        public async Task<IEnumerable<Lease>> GetLeasesInCenterAsync(int centerId)
        {
            return await _centerRepository.GetLeasesInCenterAsync(centerId);
        }

        public async Task<IEnumerable<Lease>> GetAllLeasesAsync()
        {
            return await _centerRepository.GetAllLeasesAsync();
        }

        public async Task<Lease> CreateLeaseInCenterAsync(int centerId, int unitId, Lease lease)
        {
            return await _centerRepository.CreateLeaseAsync(centerId, unitId, lease);
        }

        public async Task DeleteLeaseAsync(int centerId, int leaseId)
        {
            await _centerRepository.DeleteLeaseAsync(centerId, leaseId);
        }

        public async Task UpdateLeaseAsync(int centerId, Lease lease)
        {
            await _centerRepository.UpdateLeaseAsync(centerId, lease);
        }
        #endregion



        #endregion
    }
}
