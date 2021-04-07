using RentAll.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RentAll.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Center shoppingCenter = new Center
            {
                Premises = new List<Unit>()
            };

            Unit Unit1 = new Unit
            {
                Area = 100,
                Leases = new List<Lease>()
            };

            Unit Unit2 = new Unit
            {
                Area = 150,
                Leases = new List<Lease>()
            };
            Unit Unit3 = new Unit
            {
                Area = 1000,
                Leases = new List<Lease>()
            };
            shoppingCenter.Premises.Add(Unit1);
            shoppingCenter.Premises.Add(Unit2);
            shoppingCenter.Premises.Add(Unit3);

            Console.WriteLine($"Gross leasable area of shopping center is: {shoppingCenter.CalculateGrossLeasableArea()} sqm");

            Lease Lease = new Lease
            {
                RentSqm = 10,
                MaintenanceCostSqm = 5,
                MarketingFeeSqm = 2,
                Valid=true
            };
            Lease.Premises = new List<Unit>{
                Unit1,
                Unit2
            };

            Unit1.Leases.Add(Lease);
            Unit2.Leases.Add(Lease);

            Console.WriteLine($"Total costs per current lease are: {Lease.CalculateCostsPerLease()} EUR");


            Console.WriteLine($"Occupancy degree of the shopping center is: {shoppingCenter.CalculateOcupancyDegree()}%");




        }

        
    }
}
