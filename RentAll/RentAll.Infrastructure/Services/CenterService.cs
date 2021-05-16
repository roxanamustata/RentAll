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

        public async Task<IEnumerable<Center>> GetCenters()
        {
           return await _centerRepository.GetCenters();
        }

        public async Task<Center> GetCenterById(int id)
        {
            return await _centerRepository.GetCenterById(id);
        }

        public async Task<Center> CreateCenter(Center center)
        {
     
            return await _centerRepository.CreateCenter(center);
        }

        public async Task UpdateCenter(Center center)
        {
            await _centerRepository.UpdateCenter(center);
        }

        public void DeleteCenter(int centerId)
        {
           _centerRepository.DeleteCenter(centerId);
        }







        #endregion
    }
}
