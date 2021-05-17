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
    }
}
