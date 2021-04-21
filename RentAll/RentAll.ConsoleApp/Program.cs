﻿using RentAll.Domain;
using RentAll.Domain.Interfaces;
using RentAll.Infrastructure.Repositories;
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
            ICenterRepository centerRepository = new CenterRepository();
            Console.WriteLine($"Gross leasable area of shopping center is: {centerRepository.CalculateGrossLeasableAreaPerCenter(1)} sqm");

            Lease lease = DomainModelFactory.GetLease(new int[] { 200, 50 });
            centerRepository.AddLeaseToPremises(1,DomainModelFactory.GetUnitOnGroundfloor(50), lease);
            centerRepository.AddLeaseToPremises(1, DomainModelFactory.GetUnitOnGroundfloor(200), lease);

            Console.WriteLine($"Occupancy degree of the shopping center is: {Math.Round(centerRepository.CalculateOcupancyDegreePerCenter(1), 2)}%");
            Console.WriteLine($"Average rent of shopping center is: {Math.Round(centerRepository.CalculateAverageRentPerSQMPerCenter(1), 2)} EUR/SQM");

            Console.WriteLine($"Gross leasable area of groundfloor is: {centerRepository.CalculateGrossLeasableAreaPerFloor(1,"Ground Floor")} sqm");
            Console.WriteLine($"Occupancy degree on the groundfloor is: {Math.Round(centerRepository.CalculateOcupancyDegreePerFloor(1,"Ground Floor"), 2)}%");
                                  
            Console.WriteLine($"Leased area and total rent on Apparel activity are: {centerRepository.CalculateLeasedAreaAndTotalRentPerActivity(1, "Apparel")} EUR SQM");
            Console.WriteLine($"Average rent on Apparel activity is: {Math.Round(centerRepository.CalculateAverageRentPerSQMPerActivity(1, "Apparel"),2)} EUR/SQM");

           

            //// Use culture info to display currency and format date and time 
            //CultureInfo invariant = CultureInfo.InvariantCulture;
            //var totalLeaseCosts = lease.CalculateCostsPerLease();
            //Console.WriteLine($"On {DateTime.Now.ToString(invariant)} total costs in current culture per current lease are : {totalLeaseCosts.ToString("C", CultureInfo.CurrentCulture)} ");
            //CultureInfo uk = CultureInfo.GetCultureInfo("en-GB");
            //Console.WriteLine($"On {DateTime.Now.ToString(uk)} total costs in GB culture per current lease are : {totalLeaseCosts.ToString("C", uk)} ");


            //// Use DateTime, TimeSpan, DateTimeOffSet
            //DateTime leaseEndDate = lease.CalculateLeaseEndDate();

            //DateTime leaseEndDateLocalTime = DateTime.SpecifyKind(leaseEndDate, DateTimeKind.Local);
            //DateTimeOffset offset = leaseEndDateLocalTime;
            //Console.WriteLine($"Lease ends on: {offset} local time");

            //DateTime leaseEndDateUtc = DateTime.SpecifyKind(leaseEndDate, DateTimeKind.Utc);
            //offset = leaseEndDateUtc;
            //Console.WriteLine($"Lease ends on: {offset} utc");




        }


    }
}
