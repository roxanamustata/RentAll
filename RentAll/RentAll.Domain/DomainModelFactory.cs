using RentAll.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentAll.Domain
{
    public class DomainModelFactory
    {

        public static Center GetShoppingCenter(int id, string name)
        {

            var shoppingCenter = new Center
            {
                Id = id,
                Name = name,
                Floors = new List<Floor>() { new Floor { Name = "Ground Floor" }, new Floor { Name = "First Floor" } },
                Premises = new List<Unit>()

            };

            return shoppingCenter;

        }

        public static Unit GetUnitOnGroundfloor(int unitId, double area)
        {
            var unit = new Unit
            {
                Id = unitId,
                Area = area,
                MonthlyRentSqm = 10,
                MonthlyMaintenanceCostSqm = 5,
                MonthlyMarketingFeeSqm = 2,
                Leases = new List<Lease>(),
                Floor = new Floor { Name = "Ground Floor" },
                Code = "G" + area,
                Type = UnitType.Retail,

            };
            return unit;
        }

        public static Unit GetUnitOnFirstfloor(int unitId, double area)
        {
            var unit = new Unit
            {
                Id = unitId,
                Area = area,
                MonthlyRentSqm = 10,
                MonthlyMaintenanceCostSqm = 5,
                MonthlyMarketingFeeSqm = 2,
                Leases = new List<Lease>(),
                Floor = new Floor { Name = "First Floor" },
                Code = "F" + area,
                Type = UnitType.Retail,

            };
            return unit;
        }


        public static Lease GetLease(int leaseId)
        {

            var lease = new Lease
            {
                Id = leaseId,
                Valid = true,
                TermInMonths = 60,
                StartDate = DateTime.Now,
                Activity = new Activity
                {
                    Name = "Apparel",
                    ActivityCategory = new ActivityCategory { Name = "Non-Food" },
                },
                Premises = new List<Unit>()
            };


            return lease;
        }

    }
}
