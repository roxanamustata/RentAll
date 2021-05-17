using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentAll.Domain.Interfaces
{
    public interface ICenterService
    {
        Task<IEnumerable<Center>> GetCentersAsync();
        Task<Center> GetCenterByIdAsync(int id);
        Task<Center> CreateCenterAsync(Center center);
        Task UpdateCenterAsync(Center center);
        Task DeleteCenterAsync(int centerId);






    }
}
