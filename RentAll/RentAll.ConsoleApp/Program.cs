using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Data;
using RentAll.Infrastructure.Repositories;
using RentAll.Infrastructure.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace RentAll.ConsoleApp
{
    class Program
    {



        static void Main(string[] args)
        {

            var rentAllDbContext = new RentAllDbContext();
            var centerRepository = new CenterRepository(rentAllDbContext);
            var centerService = new CenterService(centerRepository);


            //Unit unit = centerRepository.FindUnitById(2);

            //Console.WriteLine(unit.Area);

            //Center center = centerRepository.FindCenterById(2);
            //Console.WriteLine(center.CenterName);


            //List<Unit> unitsInCenter = centerRepository.FindAllUnitsInCenter(2);
            //foreach (var item in unitsInCenter)
            //{
            //    Console.WriteLine(item.Area);
            //}
            //Lease lease = centerRepository.GetValidLease(2);
            //Console.WriteLine(lease.LeaseNumber);

            //Console.WriteLine(centerRepository.IsLeased(2));

            //Console.WriteLine(centerRepository.FindUnitInCenterByCode(2, "A1").Area);
            //Console.WriteLine(centerRepository.FindLeaseById(2).LeaseNumber);
            //List<Lease> leasesWithApparelActivity = centerRepository.FindLeasesInCenterByActivity(2, "Apparel");
            //foreach (var item in leasesWithApparelActivity)
            //{
            //    Console.WriteLine(item.LeaseNumber);
            //}

            //List<Lease> leasesInNonFoodCategory = centerRepository.FindLeasesInCenterByActivityCategory(2, "Non-Food");
            //foreach (var item in leasesInNonFoodCategory)
            //{
            //    Console.WriteLine(item.LeaseNumber);
            //}

            //List<Lease> validLeasesInCenter = centerRepository.FindValidLeasesInCenter(2);
            //foreach(var item in validLeasesInCenter)
            //{
            //    Console.WriteLine(item.LeaseNumber);
            //}
            //Console.WriteLine(centerService.CalculateGrossLeasableAreaOnCenter(2));
            //Console.WriteLine(centerService.CalculateLeasedAreaOnCenter(2));
            //Console.WriteLine(centerService.CalculateOcupancyDegreeOnCenter(2));
            //Console.WriteLine(centerService.CalculateGrossLeasableAreaInCenterOnFloor(2, "Ground Floor"));
            //Console.WriteLine(centerService.CalculateLeasedAreaInCenterOnFloor(2, "Ground Floor"));
            //Console.WriteLine(centerService.CalculateOcupancyDegreeInCenterOnFloor(2, "Ground Floor"));
            //Console.WriteLine(centerRepository.GetTotalRentOnCenter(2));
            //Console.WriteLine(centerService.CalculateTotalRentOnCenter(2));
            //Console.WriteLine(centerService.CalculateAverageRentPerSqmOnCenter(2));
            //var leasedUnitsByActivity = centerRepository.FindAllLeasedRetailUnitsInCenterByActivityCategory(2, "Non-Food");
            //foreach (var item in leasedUnitsByActivity)
            //{
            //    Console.WriteLine(item.Area);
            //}

            //Console.WriteLine(centerService.CalculateAverageRentPerSqmInCenterOnActivity(2, "Apparel"));
            //Console.WriteLine(centerService.CalculateAverageRentPerSqmInCenterOnActivityCategory(2, "Non-Food"));
            //Console.WriteLine(centerService.CalculateTotalCostsPerLease(2));

            //var center = new Center
            //{
            //    Id=4,
            //   CompanyId=1,
            //   CenterName="Iulius Mall Cluj",
            //    ParkingCapacity = 500
            //};
            //centerRepository.UpdateCenter(center);

            //centerRepository.DeleteCenter(3);

            //var unit = new Unit
            //{
            //    Id=3,
            //    CenterId = 4,
            //    Area = 100,
            //    Type = UnitType.Storage,
            //    UnitCode = "B2",
            //    MonthlyRentSqm = 10,
            //    MonthlyMaintenanceCostSqm = 0,
            //    MonthlyMarketingFeeSqm = 0,
            //    FloorId=1

            //};

            //centerRepository.UpdateUnit(unit);

            //centerRepository.DeleteUnit(4);

            var lease = new Lease
            {
                Id=5,
                ActivityId = 1,
                CenterId = 4,
                LeaseNumber = "120",
                SigningDate = DateTime.Now,
                StartDate = DateTime.Now,
                TermInMonths = 120,
                Units = new List<Unit> { centerRepository.GetUnitById(3) },
                TenantId = 2,
                UserId = 1

            };

            centerRepository.UpdateLease(lease);
            //centerRepository.DeleteLease(4);

        }


    }
}
