﻿using Microsoft.AspNetCore.Mvc;
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

        Task<IEnumerable<Unit>> GetUnitsInCenterAsync(int centerId);
        Task<Unit> GetUnitByIdAsync(int centerId,int unitId);
        Task<Unit> GetUnitFromCenterByUnitCodeAsync(int centerId, string unitCode);
        Task<Unit> CreateUnitInCenterAsync(int centerId, Unit unit);
        Task DeleteUnitAsync(int centerId, int unitId);
        Task UpdateUnitAsync(int centerId, Unit unit);


        Task<IEnumerable<Lease>> GetLeasesInCenterAsync(int centerId);
        Task<Lease> GetLeaseByIdAsync(int centerId, int leaseId);
        Task<Lease> GetValidLeaseByUnitCodeAsync(int centerId, string unitCode);
        Task<Lease> CreateLeaseInCenterAsync(int centerId,int unitId,Lease lease);
        Task DeleteLeaseAsync(int centerId, int leaseId);
        Task UpdateLeaseAsync(int centerId,Lease lease);


    }
}
