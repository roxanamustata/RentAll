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
            //var connectionString = "Data Source=RALU\\SQLEXPRESS;Initial Catalog=RentAllDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;" +
            //    "ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            //using (var dbContext = new RentAllDbContext(connectionString))
            //{
            //    dbContext.Database.EnsureCreated();
            //}


            //CenterRepository centerRepository = new CenterRepository();
            //ICenterService centerService = new CenterService(centerRepository);

            //var center1 = centerRepository.FindCenterById(1);
            //var unit1 = centerRepository.FindUnitById(1);
            //var unit2 = centerRepository.FindUnitById(2);
            //var unit3 = centerRepository.FindUnitById(3);
            //center1.Premises.Add(unit1);
            //center1.Premises.Add(unit2);
            //center1.Premises.Add(unit3);
            //var lease1 = centerRepository.FindLeaseById(1);
            //lease1.Premises.Add(unit1);
            //lease1.Premises.Add(unit2);
            //unit1.Leases.Add(lease1);
            //unit2.Leases.Add(lease1);


            //Console.WriteLine($"Gross leasable area of {centerRepository.FindCenterById(1).CenterName} is: {centerService.CalculateGrossLeasableAreaPerCenter(1)} sqm");

            //Console.WriteLine($"Occupancy degree of {centerRepository.FindCenterById(1).CenterName} is: {Math.Round(centerService.CalculateOcupancyDegreePerCenter(1), 2)}%");
            //Console.WriteLine($"Average rent of {centerRepository.FindCenterById(1).CenterName} is: {Math.Round(centerService.CalculateAverageRentPerSQMPerCenter(1), 2)} EUR/SQM");

            //Console.WriteLine($"Gross leasable area of groundfloor is: {centerService.CalculateGrossLeasableAreaPerFloor(1, "Ground Floor")} sqm");
            //Console.WriteLine($"Occupancy degree on the groundfloor is: {Math.Round(centerService.CalculateOcupancyDegreePerFloor(1, "Ground Floor"), 2)}%");

            //Console.WriteLine($"Leased area and total rent on Apparel activity are: {centerService.CalculateLeasedAreaAndTotalRentPerActivity(1, "Apparel")} EUR SQM");
            //Console.WriteLine($"Average rent on Apparel activity is: {Math.Round(centerService.CalculateAverageRentPerSQMPerActivity(1, "Apparel"), 2)} EUR/SQM");

            //Console.WriteLine($"Total monthly costs per lease with id {lease1.Id} are: {centerService.CalculateCostsPerLease(lease1.Id)} EUR");



        }


    }
}
