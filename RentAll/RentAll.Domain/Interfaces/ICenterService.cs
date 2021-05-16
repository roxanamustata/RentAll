using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterService
    {
        Task<IEnumerable<Center>> GetCenters();
        Task<Center> GetCenterById(int id);
        Task<Center> CreateCenter(Center center);
        Task UpdateCenter(Center center);
        void DeleteCenter(int centerId);






    }
}
