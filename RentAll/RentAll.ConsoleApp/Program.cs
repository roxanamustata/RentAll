using RentAll.Domain;
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
            Center shoppingCenter = DomainModelFactory.GetShoppingCenter(new int[] { 200, 20, 50 });
            Lease lease = DomainModelFactory.GetLease(new int[] { 20, 50 });
            shoppingCenter.Premises[1].Leases.Add(lease);
            shoppingCenter.Premises[2].Leases.Add(lease);

            // Use string interpolation
            Console.WriteLine($"Gross leasable area of shopping center is: {shoppingCenter.CalculateGrossLeasableArea()} sqm");
            Console.WriteLine($"Occupancy degree of the shopping center is: {Math.Round(shoppingCenter.CalculateOcupancyDegree(), 2)}%");


            // Use culture info to display currency and format date and time 
            CultureInfo invariant = CultureInfo.InvariantCulture;
            var totalLeaseCosts = lease.CalculateCostsPerLease();
            Console.WriteLine($"On {DateTime.Now.ToString(invariant)} total costs in current culture per current lease are : {totalLeaseCosts.ToString("C", CultureInfo.CurrentCulture)} ");
            CultureInfo uk = CultureInfo.GetCultureInfo("en-GB");
            Console.WriteLine($"On {DateTime.Now.ToString(uk)} total costs in GB culture per current lease are : {totalLeaseCosts.ToString("C", uk)} ");


            // Use DateTime, TimeSpan, DateTimeOffSet
            DateTime leaseEndDate = lease.CalculateLeaseEndDate();

            DateTime leaseEndDateLocalTime = DateTime.SpecifyKind(leaseEndDate, DateTimeKind.Local);
            DateTimeOffset offset = leaseEndDateLocalTime;
            Console.WriteLine($"Lease ends on: {offset} local time");

            DateTime leaseEndDateUtc = DateTime.SpecifyKind(leaseEndDate, DateTimeKind.Utc);
            offset = leaseEndDateUtc;
            Console.WriteLine($"Lease ends on: {offset} utc");




        }


    }
}
